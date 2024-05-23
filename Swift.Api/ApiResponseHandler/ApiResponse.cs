using System.Runtime.Serialization;

namespace Swift.Api.ApiResponseHandler
{
	//[DataContract]
	//public class ApiResponse(int StausCode,string Message="",object Result=null)
	//{
	//	[DataMember]
	//	public int StatusCode { get; set; } = StausCode;
	//	[DataMember]
	//	public string Message { get; set; } = Message;
	//	[DataMember] public object Result { get; set; } = Result;
	//}
	public class ApiResponse
	{
		public int StatusCode { get; set; }
		public string Status { get; set; }
		public string Message { get; set; }
		public object Result { get; set; }
		public string ExceptionMessage { get; set; }
		public ApiResponse(int statusCode, string status, string message = null, object result = null, string exceptionMessage = null)
		{
			StatusCode = statusCode;
			Status = status;
			Message = message;
			Result = result;
			ExceptionMessage = exceptionMessage;
			//ExceptionMessage = exceptionMessage ?? GetDefaultMessageStatusCode(statusCode);
		}

		
		private string GetDefaultMessageStatusCode(int statusCode)
		{
			return statusCode switch
			{
				200 => "Success",
				400 => "Bad Request",
				401 => "Unauthorized",
				403 => "Forbidden",
				404 => "Not found",
				405 => "Not allowe",
				406 => "Not acceptable",
				500 => "An internal server error occurred.",
				_ => null
			};
		}
	}
}
