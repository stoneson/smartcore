using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Util.Internal.PlatformServices
{
    public class EnvironmentInfo : IEnvironmentInfo
    {
        public EnvironmentInfo()
        {
            this.Platform = "Windows Phone";
            this.PlatformVersion = InternalSDKUtils.UnknownVersion;
            this.Model = InternalSDKUtils.UnknownVersion;
            this.Make = InternalSDKUtils.UnknownVersion;
            this.Locale = CultureInfo.CurrentCulture.DisplayName;
            this.FrameworkUserAgent = InternalSDKUtils.UnknownNetFrameworkVersion;
            this.PclPlatform = "PCL/WindowsPhone8.1";
            this.PlatformUserAgent = InternalSDKUtils.UnknownVersion;
        }

        public string Platform { get; private set; }

        public string Model { get; private set; }

        public string Make { get; private set; }

        public string PlatformVersion { get; private set; }

        public string Locale { get; private set; }

        public string FrameworkUserAgent { get; private set; }

        public string PclPlatform { get; private set; }

        public string PlatformUserAgent { get; private set; }
    }
}
