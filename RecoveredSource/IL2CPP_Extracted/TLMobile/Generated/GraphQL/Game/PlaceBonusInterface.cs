// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlaceBonusInterface : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		protected int? _id;
		[ObservableValue]
		protected string _objectId;
		[ObservableValue]
		protected string _name;
		[ObservableValue]
		protected int _type;
		[ObservableValue]
		protected bool _isFool;
		[ObservableValue]
		protected bool _isUnique;
		[ObservableValue]
		protected ArtefactScope _scope;
		[ObservableValue]
		protected float _bonus;
		[ObservableValue]
		protected int _requiredLevel;
		protected string thisTypeName;
		private string placeBonusObjectId;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private Type _iconType;
		[ObservableValue]
		private Type _typeEnum;
		[ObservableValue]
		private RequiredLevel _requiredTreasuryLevel;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private string _placeBonusScopeTranslationKey;
		[ObservableValue]
		private string _descriptionTranslationKey;
		[ObservableValue]
		private EffectValueDirection _effectValueDirection;
		[ObservableValue]
		private ScopeType _scopeType;
		[ObservableValue]
		private ErrorState _errorState;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public PlaceBonusInterfaceSource Source { get; set; }
		[ObservableValue]
		public int? id { get => default; set {} }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public bool isFool { get => default; set {} }
		[ObservableValue]
		public bool isUnique { get => default; set {} }
		[ObservableValue]
		public ArtefactScope scope { get => default; set {} }
		[ObservableValue]
		public float bonus { get => default; set {} }
		[ObservableValue]
		public int requiredLevel { get => default; set {} }
		[ObservableValue]
		public Type iconType { get => default; set {} }
		[ObservableValue]
		public Type typeEnum { get => default; set {} }
		[ObservableValue]
		public RequiredLevel requiredTreasuryLevel { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public string placeBonusScopeTranslationKey { get => default; set {} }
		[ObservableValue]
		public string descriptionTranslationKey { get => default; set {} }
		[ObservableValue]
		public EffectValueDirection effectValueDirection { get => default; set {} }
		[ObservableValue]
		public ScopeType scopeType { get => default; set {} }
		[ObservableValue]
		public ErrorState errorState { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum PlaceBonusInterfaceSource
		{
			RootLevel = 0
		}
	
		public enum EffectValueDirection
		{
			None = 0,
			Highest = 1,
			Lowest = 2
		}
	
		public enum ErrorState
		{
			None = 0,
			RequiredLevelMissing = 1,
			NotAllowed = 2,
			NotEnoughPopulation = 3,
			AlreadyOccupied = 4,
			AlreadyActive = 5
		}
	
		public enum RequiredLevel
		{
			Unique = 0,
			Small = 10,
			Large = 20
		}
	
		[Flags]
		public enum ScopeType
		{
			None = 0,
			Account = 1,
			Village = 2
		}
	
		public enum Type
		{
			Fool = 0,
			WonderWorldConstructionPlan = 1,
			Architect = 2,
			TradesmanDream = 3,
			TitanBoots = 4,
			EagleEyes = 5,
			DietControl = 6,
			ObserverOracle = 7,
			TrainerTalent = 8,
			StorageMasterplan = 9,
			RivalsConfusion = 10,
			IncreasedVpProduction = 50,
			Other = 99
		}
	
		// Constructors
		public PlaceBonusInterface() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PlaceBonusInterfaceDTO dtoValue) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PlaceBonusInterfaceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public static string GetInterfaceType(JObject dtoData) => default;
		public static PlaceBonusInterface CreateInstance(string typename) => default;
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent) => default;
		public bool CopyValuesFromDTO(JObject newValues, Query query = Query.All, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(JObject dtoValue, Query query = Query.All) => default;
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<PlaceBonusInterface> PromiseGet(string placeBonusObjectId, Query query = Query.All, bool forceFetch = true) => default;
		public static PlaceBonusInterface GetNoFetch(string typeName, string placeBonusObjectId, Query query = Query.All) => default;
		private static PlaceBonusInterface Fetch(string typeName, PlaceBonusInterfaceSource origin, string placeBonusObjectId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string placeBonusObjectId, object dummy = null) => default;
		public override void AfterServerDataCallback(object data = null) {}
		public virtual void CalculateDistance(int x, int y) {}
	}
