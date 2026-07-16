// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SitterPermissionsDTO
	{
		// Fields
		[Obsolete("Use ownPlayer->AccessRights->sendRaids instead")]
		public bool? sendRaids;
		[Obsolete("Use ownPlayer->AccessRights->sendReinforcement instead")]
		public bool? sendReinforcements;
		[Obsolete("Use ownPlayer->AccessRights->sendResources instead")]
		public bool? sendResources;
		[Obsolete("Use ownPlayer->AccessRights->buySpendGold instead")]
		public bool? buyAndSpendGold;
		[Obsolete("Use ownPlayer->AccessRights->readWriteMessages instead")]
		public bool? readAndSendMessages;
		[Obsolete("Use ownPlayer->AccessRights->deleteReportsMessages instead")]
		public bool? deleteMessagesAndReports;
		[Obsolete("Use ownPlayer->AccessRights->donateResources instead")]
		public bool? contributeResources;
	
		// Constructors
		public SitterPermissionsDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
