/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Core.Utils;
using Aliyun.Acs.Dysmsapi.Transform;
using Aliyun.Acs.Dysmsapi.Transform.V20170525;
using System.Collections.Generic;

namespace Aliyun.Acs.Dysmsapi.Model.V20170525
{
    public class SendSmsRequest : RpcAcsRequest<SendSmsResponse>
    {
        public SendSmsRequest()
            : base("Dysmsapi", "2017-05-25", "SendSms")
        {
        }

        private string templateCode;

        private string phoneNumbers;

        private string accessKeyId;

        private string signName;

        private string resourceOwnerAccount;

        private string templateParam;

        private string action;

        private long? resourceOwnerId;

        private long? ownerId;

        private string smsUpExtendCode;

        private string outId;

            //必填:短信模板-可在短信控制台中找到
        public string TemplateCode
        {
            get
            {
                return templateCode;
            }
            set
            {
                templateCode = value;
                DictionaryUtil.Add(QueryParameters, "TemplateCode", value);
            }
        }
        /// <summary>
        /// //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
        /// </summary>
		public string PhoneNumbers
        {
            get
            {
                return phoneNumbers;
            }
            set
            {
                phoneNumbers = value;
                DictionaryUtil.Add(QueryParameters, "PhoneNumbers", value);
            }
        }

        public string AccessKeyId
        {
            get
            {
                return accessKeyId;
            }
            set
            {
                accessKeyId = value;
                DictionaryUtil.Add(QueryParameters, "AccessKeyId", value);
            }
        }

        //必填:短信签名-可在短信控制台中找到
        public string SignName
        {
            get
            {
                return signName;
            }
            set
            {
                signName = value;
                DictionaryUtil.Add(QueryParameters, "SignName", value);
            }
        }

        public string ResourceOwnerAccount
        {
            get
            {
                return resourceOwnerAccount;
            }
            set
            {
                resourceOwnerAccount = value;
                DictionaryUtil.Add(QueryParameters, "ResourceOwnerAccount", value);
            }
        }

        public string TemplateParam
        {
            get
            {
                return templateParam;
            }
            set
            {
                templateParam = value;
                DictionaryUtil.Add(QueryParameters, "TemplateParam", value);
            }
        }

        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
                DictionaryUtil.Add(QueryParameters, "Action", value);
            }
        }

        public long? ResourceOwnerId
        {
            get
            {
                return resourceOwnerId;
            }
            set
            {
                resourceOwnerId = value;
                DictionaryUtil.Add(QueryParameters, "ResourceOwnerId", value.ToString());
            }
        }

        public long? OwnerId
        {
            get
            {
                return ownerId;
            }
            set
            {
                ownerId = value;
                DictionaryUtil.Add(QueryParameters, "OwnerId", value.ToString());
            }
        }

        public string SmsUpExtendCode
        {
            get
            {
                return smsUpExtendCode;
            }
            set
            {
                smsUpExtendCode = value;
                DictionaryUtil.Add(QueryParameters, "SmsUpExtendCode", value);
            }
        }

        public string OutId
        {
            get
            {
                return outId;
            }
            set
            {
                outId = value;
                DictionaryUtil.Add(QueryParameters, "OutId", value);
            }
        }

        public override SendSmsResponse GetResponse(Core.Transform.UnmarshallerContext unmarshallerContext)
        {
            return SendSmsResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }
}