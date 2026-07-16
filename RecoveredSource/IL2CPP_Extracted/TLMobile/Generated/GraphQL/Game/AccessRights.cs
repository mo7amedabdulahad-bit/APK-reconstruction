// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AccessRights : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private bool _sendRaids;
		[ObservableValue]
		private bool _sendReinforcement;
		[ObservableValue]
		private bool _sendResources;
		[ObservableValue]
		private bool _buySpendGold;
		[ObservableValue]
		private bool _readWriteMessages;
		[ObservableValue]
		private bool _deleteReportsMessages;
		[ObservableValue]
		private bool _donateResources;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool sendRaids { get => default; set {} }
		[ObservableValue]
		public bool sendReinforcement { get => default; set {} }
		[ObservableValue]
		public bool sendResources { get => default; set {} }
		[ObservableValue]
		public bool buySpendGold { get => default; set {} }
		[ObservableValue]
		public bool readWriteMessages { get => default; set {} }
		[ObservableValue]
		public bool deleteReportsMessages { get => default; set {} }
		[ObservableValue]
		public bool donateResources { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AccessRights() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AccessRightsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AccessRightsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static AccessRights DefaultAccessRights() => default;
		[UICallable]
		public void ToggleSendRaids() {}
		[UICallable]
		public void ToggleSendReinforcement() {}
		[UICallable]
		public void ToggleSendResources() {}
		[UICallable]
		public void ToggleBuySpendGold() {}
		[UICallable]
		public void ToggleReadWriteMessages() {}
		[UICallable]
		public void ToggleDeleteReportsMessages() {}
		[UICallable]
		public void ToggleDonateResources() {}
	}
