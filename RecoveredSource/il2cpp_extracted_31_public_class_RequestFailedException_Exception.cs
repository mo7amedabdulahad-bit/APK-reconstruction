	public class RequestFailedException : Exception
	{
		// Properties
		public int ErrorCode { get; }
	
		// Constructors
		public RequestFailedException() {} // Dummy constructor
		public RequestFailedException(int errorCode, string message, Exception innerException) {}
	}
