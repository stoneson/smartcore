/*
 * Copyright 2010-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amazon.Util
{
    #region Basic sections

    /// <summary>
    /// Proxy configuration is not implemented in Unity SDK.
    /// </summary>
    public partial class ProxyConfig
    {
        internal void Configure(ProxySection section)
        {

        }
    }

    /// <summary>
    /// CSM configuration is not implemented in Unity SDK.
    /// </summary>
    public partial class CSMConfig
    {
        internal void Configure(CSMSection section)
        {

        }
    }

    /// <summary>
    /// Settings for logging in the SDK.
    /// </summary>
    public partial class LoggingConfig
    {
        internal void Configure(LoggingSection section)
        {
            if (section != null)
            {
                LogTo = section.LogTo;
                LogResponses = section.LogResponses;
                LogMetrics = section.LogMetrics.GetValueOrDefault(false);
                LogMetricsFormat = section.LogMetricsFormat;
                LogResponsesSizeLimit = section.LogResponsesSizeLimit.HasValue ? section.LogResponsesSizeLimit.Value : 1024;
                if (section.LogMetricsCustomFormatter != null
                    && typeof(IMetricsFormatter).IsAssignableFrom(section.LogMetricsCustomFormatter))
                {
                    LogMetricsCustomFormatter = Activator.CreateInstance(section.LogMetricsCustomFormatter) as IMetricsFormatter;
                }
            }
        }
    }

    #endregion
}
