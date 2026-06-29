// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageTemplateDTO
	{
		// Fields
		public int? id;
		public string subject;
		public string message;
		public List<MessageRecipientDTO> recipients;
		public MessageTopic? topic;
	
		// Constructors
		public MessageTemplateDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
