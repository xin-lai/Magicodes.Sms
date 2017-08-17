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
using System.Collections.Generic;

namespace Aliyun.Acs.Dysmsapi.Model.V20170525
{
	public class QueryInterSmsIsoInfoResponse : AcsResponse
	{

		private string requestId;

		private string code;

		private string message;

		private string totalCount;

		private List<QueryInterSmsIsoInfo_IsoSupportDTO> isoSupportDTOs;

		public string RequestId
		{
			get
			{
				return requestId;
			}
			set	
			{
				requestId = value;
			}
		}

		public string Code
		{
			get
			{
				return code;
			}
			set	
			{
				code = value;
			}
		}

		public string Message
		{
			get
			{
				return message;
			}
			set	
			{
				message = value;
			}
		}

		public string TotalCount
		{
			get
			{
				return totalCount;
			}
			set	
			{
				totalCount = value;
			}
		}

		public List<QueryInterSmsIsoInfo_IsoSupportDTO> IsoSupportDTOs
		{
			get
			{
				return isoSupportDTOs;
			}
			set	
			{
				isoSupportDTOs = value;
			}
		}

		public class QueryInterSmsIsoInfo_IsoSupportDTO
		{

			private string countryName;

			private string countryCode;

			private string isoCode;

			public string CountryName
			{
				get
				{
					return countryName;
				}
				set	
				{
					countryName = value;
				}
			}

			public string CountryCode
			{
				get
				{
					return countryCode;
				}
				set	
				{
					countryCode = value;
				}
			}

			public string IsoCode
			{
				get
				{
					return isoCode;
				}
				set	
				{
					isoCode = value;
				}
			}
		}
	}
}