using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Models
{
	public class MemberModel
	{
		public string ENTITY_UID { get; set; }
		public string ENTITY_CLIENT_ID { get; set; }
		public string ENTITY_DESCRIPTION { get; set; }
		public string INSURANCE_UID { get; set; }
		public string INSURANCE_CLIENT_ID { get; set; }
		public string INSURANCE_DESCRIPTION { get; set; }
		public string OPTION_CLIENT_ID { get; set; }
		public string OPTION_DESCRIPTION { get; set; }
		public string MEMBER_UID { get; set; }
		public string MEMBER_CLIENT_ID { get; set; }
		public string MEMBER_FIRST_NAME { get; set; }
		public string MEMBER_LAST_NAME { get; set; }
		public string MEMBER_FULLNAME { get; set; }
		public DateOnly MEMBER_DOB { get; set; }
		public string MEMBER_GENDER { get; set; }
		public string MEMBER_INSURANCE_EFF_DATE { get; set; }
		public string MEMBER_OPTION_EFF_DATE { get; set; }
		public string MEMBER_OPTION_TERM_DATE { get; set; }
		public string MEMBER_SUBSCRIBER_ID { get; set; }
		public string MEMBER_RELATIONSHIP { get; set; }
		public string TIN_NAME { get; set; }
		public string PROVIDER_UID { get; set; }
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

	}
}
