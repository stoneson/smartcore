/*
 * Copyright 2010-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amazon.Runtime.Internal
{
    public class CSMConfiguration
    {
        // Host that the Agent Monitoring connects. Defaults to 127.0.0.1
        public string Host { get; internal set; } = Amazon.Util.CSMConfig.DEFAULT_HOST;
        // Port number that the Agent Monitoring Listener writes to. Defaults to 31000
        public int Port { get; internal set; } = Amazon.Util.CSMConfig.DEFAULT_PORT;
        // Determines whether or not the Agent Monitoring Listener is enabled
        public bool Enabled { get; internal set; }
        // Contains the clientId to all monitoring events generated by the SDK
        public string ClientId { get; internal set; } = string.Empty;
    }
}
