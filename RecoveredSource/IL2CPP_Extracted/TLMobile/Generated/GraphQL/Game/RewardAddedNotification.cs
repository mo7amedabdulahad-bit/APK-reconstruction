// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RewardAddedNotification : TLMobile.Generated.GraphQL.Game.NotificationInterface
	{
		// Fields
		[ObservableValue]
		private RemovablePlayer _invitedPlayer;
		[ObservableValue]
		private int _villageSlot;
		[ObservableValue]
		private int _reward;
		[ObservableValue]
		private string _notificationText;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public RemovablePlayer invitedPlayer { get => default; set {} }
		[ObservableValue]
		public int villageSlot { get => default; set {} }
		[ObservableValue]
		public int reward { get => default; set {} }
		[ObservableValue]
		public string notificationText { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public RewardAddedNotification() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RewardAddedNotificationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RewardAddedNotificationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		[UICallable]
		public void OpenReferralOverview() {}
	}
