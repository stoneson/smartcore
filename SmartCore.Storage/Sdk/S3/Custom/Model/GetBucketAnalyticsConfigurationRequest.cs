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
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
    /// <summary>
    /// Container for the parameters to the GetBucketAnalyticsConfiguration operation.
    /// <para>Gets an analytics configuration for the bucket (specified by the analytics configuration ID).</para>
    /// </summary>
    public partial class GetBucketAnalyticsConfigurationRequest : AmazonWebServiceRequest
    {
        private string bucketName;
        private string analyticsId;

        /// <summary>
        /// The name of the bucket from which an analytics configuration is retrieved.
        /// </summary>
        public string BucketName
        {
            get { return this.bucketName; }
            set { this.bucketName = value; }
        }

        // Check to see if BucketName property is set
        internal bool IsSetBucketName()
        {
            return !(string.IsNullOrEmpty(this.bucketName));
        }

        /// <summary>
        /// The identifier used to represent an analytics configuration.
        /// </summary>
        public string AnalyticsId
        {
            get { return this.analyticsId; }
            set { this.analyticsId = value; }
        }

        // Check to see if InventoryId property is set
        internal bool IsSetAnalyticsId()
        {
            return !(string.IsNullOrEmpty(this.analyticsId));
        }
    }
}
