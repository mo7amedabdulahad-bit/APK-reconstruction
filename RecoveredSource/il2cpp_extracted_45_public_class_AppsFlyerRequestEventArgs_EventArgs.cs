	public class AppsFlyerRequestEventArgs : EventArgs
	{
		// Properties
		public int statusCode { get; }
		public string errorDescription { get; }
	
		// Constructors
		public AppsFlyerRequestEventArgs() {} // Dummy constructor
		public AppsFlyerRequestEventArgs(int code, string description) {}
	}
