// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.TroopsPagination
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsPagination : IPaginatedObject<RallyPointTroopsOverviewDetailsItem>
	{
		// Fields
		private static readonly Dictionary<int, RallyPointTroopsOverviewDetailsItem> MovingTroopsCache;
		private readonly MovingTroopConnection movingTroopConnection;
		private readonly StandingTroopConnection standingTroopConnection;
	
		// Properties
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Constructors
		public TroopsPagination() {}
		public TroopsPagination(MovingTroopConnection movingTroopConnection) {}
		public TroopsPagination(StandingTroopConnection standingTroopConnection) {}
		public TroopsPagination(ServerObject serverObject) {}
		static TroopsPagination() {}
	
		// Methods
		public void ObserveWhole(System.Action observer, bool instantlyCallWhenFilled = true, bool deepObserve = true) {}
		public void ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData = false) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<RallyPointTroopsOverviewDetailsItem> CreateListItems() => default;
		public List<RallyPointTroopsOverviewDetailsItem> CreatePlaceHolders(int count) => default;
	}
