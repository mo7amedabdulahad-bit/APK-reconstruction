// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ExternalURLsDTO
	{
		// Fields
		public string support;
		[Obsolete("Please use \'support\' key")]
		public string freshdesk;
		[Obsolete("Please use \'support\' key. The result of this key is the same - link to support page.")]
		public string knowledgeBase;
		public string news;
		public string gameRules;
		public string discord;
		public string rightOfWithdrawalUrl;
	
		// Constructors
		public ExternalURLsDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
