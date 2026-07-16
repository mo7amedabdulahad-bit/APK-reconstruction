// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnMerchantMovement : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private MerchantEventType _type;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _sender;
		[ObservableValue]
		private RemovablePlayer _customer;
		[ObservableValue]
		private int? _route;
		[ObservableValue]
		private Village _from;
		[ObservableValue]
		private Village _to;
		[ObservableValue]
		private int _oneWayDuration;
		[ObservableValue]
		private int _arrivalAt;
		[ObservableValue]
		private ResourcesAmount _carriedResources;
		[ObservableValue]
		private ResourcesAmount _merchantsCapacity;
		[ObservableValue]
		private int _runs;
		[ObservableValue]
		private int _merchantsAmount;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private GraphQLObservableList<MerchantMovementHistory> _history;
		[ObservableValue]
		private bool _useTradeShips;
		[ObservableValue]
		private int? _cancelDeliveryUntil;
		[ObservableValue]
		private bool? _cancelled;
		[ObservableValue]
		private bool _isExpanded;
		[ObservableValue]
		private bool _isReturning;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private ObservableList<OwnMerchantMovementRun> _ownMerchantMovementRuns;
		private bool isAllwaysFoldedOut;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public MerchantEventType type { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player sender { get => default; set {} }
		[ObservableValue]
		public RemovablePlayer customer { get => default; set {} }
		[ObservableValue]
		public int? route { get => default; set {} }
		[ObservableValue]
		public Village from { get => default; set {} }
		[ObservableValue]
		public Village to { get => default; set {} }
		[ObservableValue]
		public int oneWayDuration { get => default; set {} }
		[ObservableValue]
		public int arrivalAt { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount carriedResources { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount merchantsCapacity { get => default; set {} }
		[ObservableValue]
		public int runs { get => default; set {} }
		[ObservableValue]
		public int merchantsAmount { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MerchantMovementHistory> history { get => default; set {} }
		[ObservableValue]
		public bool useTradeShips { get => default; set {} }
		[ObservableValue]
		public int? cancelDeliveryUntil { get => default; set {} }
		[ObservableValue]
		public bool? cancelled { get => default; set {} }
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public bool isReturning { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnMerchantMovementRun> ownMerchantMovementRuns { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnMerchantMovement() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnMerchantMovementDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnMerchantMovementDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListHistory(GraphQLObservableList<MerchantMovementHistory> to, List<MerchantMovementHistoryDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _historyNotify(object sender, PropertyChangedEventArgs args) {}
		private void _ownMerchantMovementRunsNotify(object sender, PropertyChangedEventArgs args) {}
		public int GetRequiredUpdateTime() => default;
		public void SetAllwaysFoldedOut(bool value) {}
		[UICallable]
		public void OnFoldClicked() {}
		public override void AfterServerDataCallback() {}
	}
