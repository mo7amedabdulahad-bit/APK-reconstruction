// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageDTO
	{
		// Fields
		public int? id;
		public string objectId;
		public RemovablePlayerDTO senderData;
		public SenderType? senderType;
		public RemovablePlayerDTO recipientData;
		public MessageState? state;
		public string subject;
		public MessageType? type;
		[Obsolete("Is part of metadata now")]
		public MessageTopic? topic;
		public int? sentAt;
		public string message;
		public List<NameValueContainerDTO> metadata;
		public bool? isSpam;
		public string spamReason;
		[Obsolete("Freshdesk specific functionality that is no longer in use")]
		public int? ticketId;
	
		// Constructors
		public MessageDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
