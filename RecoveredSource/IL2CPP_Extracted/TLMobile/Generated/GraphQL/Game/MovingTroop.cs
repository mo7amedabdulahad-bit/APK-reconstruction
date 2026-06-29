// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MovingTroop : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private Village _originVillage;
		[ObservableValue]
		private Village _supplyVillage;
		[ObservableValue]
		private int? _tribeId;
		[ObservableValue]
		private int? _type;
		[ObservableValue]
		private int? _time;
		[ObservableValue]
		private int? _consumption;
		[ObservableValue]
		private int? _attackPower;
		[ObservableValue]
		private int? _defencePower;
		[ObservableValue]
		private int? _id;
		[ObservableValue]
		private int _lumber;
		[ObservableValue]
		private int _clay;
		[ObservableValue]
		private int _iron;
		[ObservableValue]
		private int _crop;
		[ObservableValue]
		private int? _catapultTarget1;
		[ObservableValue]
		private int? _catapultTarget2;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.ScoutingTarget? _scoutingTarget;
		[ObservableValue]
		private int _sourceUid;
		[ObservableValue]
		private int _sourceDid;
		[ObservableValue]
		private int _sourceKid;
		[ObservableValue]
		private TroopEvent _troopEvent;
		[ObservableValue]
		private UnitsAmount _units;
		[ObservableValue]
		private TroopFlag? _flag;
		[ObservableValue]
		private string _ship;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeIdEnum;
		[ObservableValue]
		private int _totalResources;
		[ObservableValue]
		private int _cancelUntil;
		[ObservableValue]
		private int? _shipIdUsed;
		[ObservableValue]
		private int? _genericShipIdUsed;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public Village originVillage { get => default; set {} }
		[ObservableValue]
		public Village supplyVillage { get => default; set {} }
		[ObservableValue]
		public int? tribeId { get => default; set {} }
		[ObservableValue]
		public int? type { get => default; set {} }
		[ObservableValue]
		public int? time { get => default; set {} }
		[ObservableValue]
		public int? consumption { get => default; set {} }
		[ObservableValue]
		public int? attackPower { get => default; set {} }
		[ObservableValue]
		public int? defencePower { get => default; set {} }
		[ObservableValue]
		public int? id { get => default; set {} }
		[ObservableValue]
		public int lumber { get => default; set {} }
		[ObservableValue]
		public int clay { get => default; set {} }
		[ObservableValue]
		public int iron { get => default; set {} }
		[ObservableValue]
		public int crop { get => default; set {} }
		[ObservableValue]
		public int? catapultTarget1 { get => default; set {} }
		[ObservableValue]
		public int? catapultTarget2 { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.ScoutingTarget? scoutingTarget { get => default; set {} }
		[ObservableValue]
		public int sourceUid { get => default; set {} }
		[ObservableValue]
		public int sourceDid { get => default; set {} }
		[ObservableValue]
		public int sourceKid { get => default; set {} }
		[ObservableValue]
		public TroopEvent troopEvent { get => default; set {} }
		[ObservableValue]
		public UnitsAmount units { get => default; set {} }
		[ObservableValue]
		public TroopFlag? flag { get => default; set {} }
		[ObservableValue]
		public string ship { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeIdEnum { get => default; set {} }
		[ObservableValue]
		public int totalResources { get => default; set {} }
		[ObservableValue]
		public int cancelUntil { get => default; set {} }
		[ObservableValue]
		public int? shipIdUsed { get => default; set {} }
		[ObservableValue]
		public int? genericShipIdUsed { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			MovingTroopEdgeMovingTroopConnectionOnlyTimeEdgesNode = 1
		}
	
		// Constructors
		public MovingTroop() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MovingTroopDTO dtoValue) => default;
		private bool EqualToDTOMovingTroopEdgeMovingTroopConnectionOnlyTimeEdgesNode(MovingTroopDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MovingTroopDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOMovingTroopEdgeMovingTroopConnectionOnlyTimeEdgesNode(MovingTroopDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback() {}
	}
