	public class ResourceManagerException : Exception
	{
		// Constructors
		public ResourceManagerException() {}
		public ResourceManagerException(string message) {}
		public ResourceManagerException(string message, Exception innerException) {}
		protected ResourceManagerException(SerializationInfo message, StreamingContext context) {}
	
		// Methods
		public override string ToString() => default;
	}
