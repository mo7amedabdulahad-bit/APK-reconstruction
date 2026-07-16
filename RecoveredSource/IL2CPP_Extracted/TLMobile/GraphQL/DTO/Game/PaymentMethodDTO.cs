// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PaymentMethodDTO
	{
		// Fields
		public string code;
		public string name;
		public string icon;
		public bool? iframeAllowed;
		public string status;
		public int? position;
		public List<int?> transactionDuration;
	
		// Constructors
		public PaymentMethodDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
