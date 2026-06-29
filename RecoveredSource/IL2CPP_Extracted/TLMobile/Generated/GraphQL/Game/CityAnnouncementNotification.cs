// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CityAnnouncementNotification : TLMobile.Generated.GraphQL.Game.NotificationInterface
	{
		// Fields
		[ObservableValue]
		private int _pointsNeeded;
		[ObservableValue]
		private int _townHallLevelNeeded;
		[ObservableValue]
		private int _cityResourceFieldsMaxLevel;
		[ObservableValue]
		private bool _hasTownHall;
		private Building townHall;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int pointsNeeded { get => default; set {} }
		[ObservableValue]
		public int townHallLevelNeeded { get => default; set {} }
		[ObservableValue]
		public int cityResourceFieldsMaxLevel { get => default; set {} }
		[ObservableValue]
		public bool hasTownHall { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public CityAnnouncementNotification() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CityAnnouncementNotificationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CityAnnouncementNotificationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		[UICallable]
		public void OpenTownHall() {}
	}
