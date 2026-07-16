// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TraderArrivedReportDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? readStatus;
		public string title;
		public int? ownerId;
		public RemovablePlayerDTO senderPlayer;
		public VillageDTO from;
		public RemovablePlayerDTO receiverPlayer;
		public VillageDTO to;
		public int? duration;
		public ResourcesAmountDTO broughtResources;
		public int? icon;
		public bool? ship;
	
		// Constructors
		public TraderArrivedReportDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
