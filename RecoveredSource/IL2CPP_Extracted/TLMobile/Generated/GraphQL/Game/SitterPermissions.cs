// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SitterPermissions : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->sendRaids instead")]
		private bool _sendRaids;
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->sendReinforcement instead")]
		private bool _sendReinforcements;
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->sendResources instead")]
		private bool _sendResources;
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->buySpendGold instead")]
		private bool _buyAndSpendGold;
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->readWriteMessages instead")]
		private bool _readAndSendMessages;
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->deleteReportsMessages instead")]
		private bool _deleteMessagesAndReports;
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->donateResources instead")]
		private bool _contributeResources;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->sendRaids instead")]
		public bool sendRaids { get => default; set {} }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->sendReinforcement instead")]
		public bool sendReinforcements { get => default; set {} }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->sendResources instead")]
		public bool sendResources { get => default; set {} }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->buySpendGold instead")]
		public bool buyAndSpendGold { get => default; set {} }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->readWriteMessages instead")]
		public bool readAndSendMessages { get => default; set {} }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->deleteReportsMessages instead")]
		public bool deleteMessagesAndReports { get => default; set {} }
		[ObservableValue]
		[Obsolete("Use ownPlayer->AccessRights->donateResources instead")]
		public bool contributeResources { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public SitterPermissions() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SitterPermissionsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SitterPermissionsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
