	public class ResourceTypeDTO
	{
		// Fields
		public int? id;
		public string code;
	
		// Constructors
		public ResourceTypeDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
