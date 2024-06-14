using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Swift.Core.Models
{
	public class ProviderModel
	{
		public Guid ENTITY_UID { get; set; }
		public string ENTITY_CLIENT_ID { get; set; }
		public string ENTITY_DESCRIPTION { get; set; }
		public Guid PROVIDER_CONTACT_UID { get; set; }
		public Guid TIN_UID { get; set; }
		public string TIN_CLIENT_ID { get; set; }
		public string TIN { get; set; }
		public string TIN_NAME { get; set; }
		public Guid PROVIDER_UID { get; set; }
		public string PROVIDER_CLIENT_ID { get; set; }
		public string PROVIDER_NPI { get; set; }
		public string PROVIDER_FIRST_NAME { get; set; }
		public string PROVIDER_LAST_NAME { get; set; }
		public string PROVIDER_FULLNAME { get; set; }
		public string PROVIDER_FULLNAME_REVERSE { get; set; }
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
		public string PROVIDER_DEFAULT { get; set; }

	}
	public class ProviderDetailsModel
	{
		public Guid PROVIDER_UID { get; set; }
		public Guid ENTITY_UID { get; set; }
		public string ENTITY_CLIENT_ID { get; set; }
		public string ENTITY_DESCRIPTION { get; set; }
		public string PROVIDER_NPI { get; set; }
		public string PROVIDER_FIRST_NAME { get; set; }
		public string PROVIDER_LAST_NAME { get; set; }
		public string PROVIDER_FULLNAME { get; set; }
		public string TIN_CLIENT_ID { get; set; }
		public string TIN { get; set; }
		public string TIN_NAME { get; set; }
		public Guid PROVIDER_CONTACT_UID { get; set; }
		public string PROVIDER_ADDRESS_1 { get; set; }
		public string PROVIDER_ADDRESS_2 { get; set; }
		public string PROVIDER_CITY { get; set; }
		public string PROVIDER_STATE { get; set; }
		public string PROVIDER_ZIP { get; set; }
		public Guid INSURANCE_UID { get; set; }
		public string INSURANCE_CLIENT_ID { get; set; }
		public string TotalCount { get; set; }

	}
	public class ProviderSearchModel
	{
		public string ENTITY_ID { get; set; }
		public string INSURANCE { get; set; }
		public string TIN { get; set; }
		public string FIRST_NAME { get; set; }
		public string LAST_NAME { get; set; }
		public string NPI { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
		public string SortColumn { get; set; }
		public string Order { get; set; }
	}

	public class ProviderInfoModel
	{

		public string ENTITY_DESCRIPTION { get; set; }
		public Guid PROVIDER_UID { get; set; }
		public string PROVIDER_FULLNAME { get; set; }
		public string PROVIDER_NPI { get; set; }
		public string TIN_NAME { get; set; }
		public string PROVIDER_CLIENT_ADDRESS_TYPE { get; set; }
		public string PROVIDER_ADDRESS_1 { get; set; }
		public string PROVIDER_ADDRESS_2 { get; set; }
		public string PROVIDER_CITY { get; set; }
		public string PROVIDER_STATE { get; set; }
		public string PROVIDER_ZIP { get; set; }
		public string PROVIDER_PHONE { get; set; }
		public string PROVIDER_FAX { get; set; }
		public string PROVIDER_EMAIL { get; set; }
		public string PROVIDER_SPECIALTY_LIST { get; set; }
		public string PROVIDER_INSURANCE_LIST { get; set; }

	}
	public class ProviderSpecialtyModel
	{

		public string PROVIDER_SPECIALTY_TYPE { get; set; }
		public string PROVIDER_CLIENT_SPECIALTY_CODE { get; set; }
		public string PROVIDER_CLIENT_SPECIALTY_DESCRIPTION { get; set; }
	}
	public class ProviderEntitiesModel
	{
		public string ENTITY_CLIENT_ID { get; set; }
		public string ENTITY_DESCRIPTION { get; set; }

	}
	public class ProviderTINModel
	{
		public string TIN_ID { get; set; }
		public string TIN_NAME { get; set; }

	}
	public class ProviderInsuranceModel
	{
		public string INSURANCE_CLIENT_ID { get; set; }
		public string INSURANCE_DESCRIPTION { get; set; }

	}
}
