// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ShopTransactionDTO
	{
		// Fields
		public string paymentId;
		public string paymentMethod;
		public string price;
		public int? goldGrants;
		public string createdDate;
		public string createdDateTime;
		public ShopTransactionStateDTO state;
	
		// Constructors
		public ShopTransactionDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
