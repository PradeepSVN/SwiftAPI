using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Models
{
	public class MemberModel
	{
		public Guid ENTITY_UID { get; set; }
		public string ENTITY_CLIENT_ID { get; set; }
		public string ENTITY_DESCRIPTION { get; set; }
		public Guid INSURANCE_UID { get; set; }
		public string INSURANCE_CLIENT_ID { get; set; }
		public string INSURANCE_DESCRIPTION { get; set; }
		public string OPTION_CLIENT_ID { get; set; }
		public string OPTION_DESCRIPTION { get; set; }
		public Guid MEMBER_UID { get; set; }
		public string MEMBER_CLIENT_ID { get; set; }
		public string MEMBER_FIRST_NAME { get; set; }
		public string MEMBER_LAST_NAME { get; set; }
		public string MEMBER_FULLNAME { get; set; }
		public string MEMBER_DOB { get; set; }
		public string MEMBER_GENDER { get; set; }
		public string MEMBER_INSURANCE_EFF_DATE { get; set; }
		public string MEMBER_OPTION_EFF_DATE { get; set; }
		public string MEMBER_OPTION_TERM_DATE { get; set; }
		public string MEMBER_SUBSCRIBER_ID { get; set; }
		public string MEMBER_RELATIONSHIP { get; set; }
		public string TIN_NAME { get; set; }
		public Guid PROVIDER_UID { get; set; }
		public string PROVIDER_CLIENT_ID { get; set; }
		public string PROVIDER_FIRST_NAME { get; set; }
		public string PROVIDER_LAST_NAME { get; set; }
		public string PROVIDER_FULLNAME { get; set; }
	}
	public class MemberSearchModel
	{
		public string ENTITY_UID { get; set; }
		public string INSURANCE { get; set; }
		public string OPTION { get; set; }
		public string MEMBER_ID { get; set; }
		public string FIRST_NAME { get; set; }
		public string LAST_NAME { get; set; }
		public string DOB { get; set; }
		public string PCP { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
		public string SortColumn { get; set; }
		public string Order { get; set; }
		public int Totalrows { get; set; }
	}
	public class MemberSearchDetailsModel
	{
		public string ENTITY { get; set; }
		public string INSURANCE { get; set; }
		public string OPTIONCID { get; set; }
		public string EFFECTIVE { get; set; }
		public string TERM { get; set; }
		public string PCP { get; set; }
		public string MEMBERID { get; set; }
		public string FIRSTNAME { get; set; }
		public string LASTNAME { get; set; }
		public string DOB { get; set; }
		public string TotalCount { get; set; }

	}
	public class MemberInfoModel
	{
		public Guid MEMBER_UID { get; set; }
		public string MEMBER_CLIENT_ID { get; set; }
		public string MEMBER_DOB { get; set; }
		public string MEMBER_Age { get; set; }
		public string MEMBER_FULLNAME { get; set; }
		public string MEMBER_GENDER { get; set; }
		public string MEMBER_INSURANCE_EFF_DATE { get; set; }
		public string MEMBER_OPTION_EFF_DATE { get; set; }
		public string MEMBER_OPTION_TERM_DATE { get; set; }
		public string MEMBER_SUBSCRIBER_ID { get; set; }
		public string MEMBER_CLIENT_CONTACT_TYPE { get; set; }
		public string MEMBER_ADDRESS_1 { get; set; }
		public string MEMBER_ADDRESS_2 { get; set; }
		public string MEMBER_CITY { get; set; }
		public string MEMBER_STATE { get; set; }
		public string MEMBER_ZIP { get; set; }
		public string MEMBER_PHONE { get; set; }
		public string MEMBER_MOBILE { get; set; }
		public string MEMBER_WORK_PHONE { get; set; }
		public string MEMBER_WORK_PHONE_EXT { get; set; }
		public string MEMBER_EMAIL { get; set; }
		public Guid PROVIDER_UID { get; set; }
		public string PROVIDER_FULLNAME { get; set; }
		public string PROVIDER_CLIENT_ADDRESS_TYPE { get; set; }
		public Guid PROVIDER_CLIENT_CONTACT_UID { get; set; }
		public string PROVIDER_CLIENT_CONTACT_ID { get; set; }
		public string PROVIDER_ADDRESS_1 { get; set; }
		public string PROVIDER_ADDRESS_2 { get; set; }
		public string PROVIDER_CITY { get; set; }
		public string PROVIDER_STATE { get; set; }
		public string PROVIDER_ZIP { get; set; }
		public string PROVIDER_PHONE { get; set; }
		public string PROVIDER_PHONE_EXT { get; set; }
		public string PROVIDER_FAX { get; set; }
		public string PROVIDER_EMAIL { get; set; }
		public string TIN_NAME { get; set; }
		public string MEMBERSTATUS { get; set; }
		public string INSURANCE_DESCRIPTION { get; set; }
		public string MEMBER_RELATIONSHIP { get; set; }
		public string OPTION_CLIENT_ID { get; set; }
		public string AGE { get; set; }
	}
}
