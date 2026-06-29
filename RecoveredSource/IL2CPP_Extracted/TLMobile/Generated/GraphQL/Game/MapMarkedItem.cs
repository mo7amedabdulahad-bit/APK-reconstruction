// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapMarkedItem : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _listDisplayName;
		[ObservableValue]
		private int _id;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public string TypeName { get; }
		public Alliance Alliance { get; }
		public TLMobile.Generated.GraphQL.Game.Player Player { get; }
		public override bool isFilled { get => default; set {} }
		[ObservableValue]
		public string listDisplayName { get => default; set {} }
		[ObservableValue]
		public int id { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public MapMarkedItem(Alliance value) {}
		public MapMarkedItem(TLMobile.Generated.GraphQL.Game.Player value) {}
		public MapMarkedItem() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override bool EqualToDTO(object dtoValue, int query) => default;
		public static string GetUnionType(JObject jObject) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(JObject newValues, int query = 0, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public static MapMarkedItem CreateInstance(string typename) => default;
		public static string GetInterfaceType(JObject dtoValue) => default;
		public static MapMarkedItem FromAlliance(Alliance value) => default;
		public static MapMarkedItem FromPlayer(TLMobile.Generated.GraphQL.Game.Player value) => default;
		public bool Is<T>()
			where T : class => default;
		public bool Is<T>(out ref T value)
			where T : class {
			value = default;
			return default;
		}
		public T As<T>()
			where T : class => default;
		private object GetValue() => default;
		public override void AfterServerDataCallback() {}
	}
