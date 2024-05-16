using System.Runtime.Serialization;

namespace Swift.Api.ApiResponseHandler
{
	[DataContract]
	public class ApiResponse(int StausCode,string Message="",object Result=null)
	{
		[DataMember]
		public int StatusCode { get; set; } = StausCode;
		[DataMember]
		public string Message { get; set; } = Message;
		[DataMember] public object Result { get; set; } = Result;
	}
}
