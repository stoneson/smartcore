using SmartCore.ConfigCenter.Apollo.Core;
using SmartCore.ConfigCenter.Apollo.Core.Dto;
using SmartCore.ConfigCenter.Apollo.Exceptions;
using SmartCore.ConfigCenter.Apollo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartCore.ConfigCenter.Apollo.Internals
{
    public class ConfigServiceLocator : IDisposable
    {
        //private static readonly Func<Action<LogLevel, string, Exception?>> Logger = () => LogManager.CreateLogger(typeof(ConfigServiceLocator));

        private readonly HttpUtil _httpUtil;

        private readonly IApolloOptions _options;
        private volatile IList<ServiceDto> _configServices = new List<ServiceDto>();
        private Task? _updateConfigServicesTask;
        private readonly Timer? _timer;

        public ConfigServiceLocator(HttpUtil httpUtil, IApolloOptions configUtil)
        {
            _httpUtil = httpUtil;
            _options = configUtil;

            var serviceDtos = GetCustomizedConfigService(configUtil);

            if (serviceDtos == null)
                _timer = new Timer(SchedulePeriodicRefresh, null, 0, _options.RefreshInterval);
            else
                _configServices = serviceDtos;
        }

        private static IList<ServiceDto>? GetCustomizedConfigService(IApolloOptions configUtil) =>
            configUtil.ConfigServer?
                .Select(configServiceUrl => new ServiceDto
                {
                    HomepageUrl = configServiceUrl.Trim(),
                    InstanceId = configServiceUrl.Trim(),
                    AppName = ConfigConsts.ConfigService
                })
                .ToArray();

        /// <summary>
        /// Get the config service info from remote meta server.
        /// </summary>
        /// <returns> the services dto </returns>
        public async Task<IList<ServiceDto>> GetConfigServices()
        {
            var services = _configServices;
            if (services.Count == 0)
                await UpdateConfigServices().ConfigureAwait(false);

            services = _configServices;
            if (services.Count == 0)
                throw new ApolloConfigException("No available config service");

            return services;
        }

        private async void SchedulePeriodicRefresh(object _)
        {
            try
            {
               // Logger().Debug("refresh config services");

                await UpdateConfigServices().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //Logger().Warn(ex);
            }
        }

        private Task UpdateConfigServices()
        {
            Task? task;
            if ((task = _updateConfigServicesTask) != null) return task;

            lock (this)
                if ((task = _updateConfigServicesTask) == null)
                {
                    task = _updateConfigServicesTask = UpdateConfigServices(3);

                    _updateConfigServicesTask.ContinueWith(_ => _updateConfigServicesTask = null);
                }

            return task;
        }

        private async Task UpdateConfigServices(int times)
        {
            var url = AssembleMetaServiceUrl();

            Exception? exception = null;

            for (var i = 0; i < Math.Max(1, times); i++)
            {
                try
                {
                    var response = await _httpUtil.DoGetAsync<IList<ServiceDto>>(url, 2000).ConfigureAwait(false);
                    var services = response.Body;
                    if (services == null || services.Count == 0) continue;

                    _configServices = services;

                    return;
                }
                catch (Exception ex)
                {
                    //Logger().Warn(ex);
                    exception = ex;
                }
            }

            throw new ApolloConfigException($"Get config services failed from {url}", exception!);
        }

        private Uri AssembleMetaServiceUrl()
        {
            var domainName = _options.MetaServer;
            var appId = _options.AppId;
            var localIp = _options.LocalIp;

            var uriBuilder = new UriBuilder(domainName + "/services/config");
            var query = new Dictionary<string, string>();

            query["appId"] = appId;
            if (!string.IsNullOrEmpty(localIp))
            {
                query["ip"] = localIp;
            }

            uriBuilder.Query = QueryUtils.Build(query);

            return uriBuilder.Uri;
        }

        public void Dispose() => _timer?.Dispose();
    }
}
