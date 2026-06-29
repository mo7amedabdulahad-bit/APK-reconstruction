// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointTroopsOverviewItem : ObservableModel, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private Category _overviewItemCategory;
		[ObservableValue]
		private bool _visible;
		[ObservableValue]
		private bool _clickable;
		[ObservableValue]
		private TroopsPower _power;
		[ObservableValue]
		private int _firstArrivalTime;
		[ObservableValue]
		private bool _isStandingTroop;
		private IPaginatedObject<RallyPointTroopsOverviewDetailsItem> paginatedPage;
	
		// Properties
		[ObservableValue]
		public Category overviewItemCategory { get => default; set {} }
		[ObservableValue]
		public bool visible { get => default; set {} }
		[ObservableValue]
		public bool clickable { get => default; set {} }
		[ObservableValue]
		public TroopsPower power { get => default; set {} }
		[ObservableValue]
		public int firstArrivalTime { get => default; set {} }
		[ObservableValue]
		public bool isStandingTroop { get => default; set {} }
	
		// Nested types
		public enum Category
		{
			None = 0,
			IncomingAttacksAndRaids = 1,
			OutgoingAttacksAndRaids = 2,
			ReturningTroops = 3,
			OwnTroopsInVillage = 4,
			ForeignTroopsInVillage = 5,
			TroopsInOtherVillagesOrOases = 6,
			IncomingReinforcement = 7,
			OutgoingReinforcements = 8,
			AdvancedCustomDetails = 10
		}
	
		// Constructors
		public RallyPointTroopsOverviewItem() {}
	
		// Methods
		public void Update(int query = 0) {}
		public void SetFirstArrivalTimeForCategory(Category category, ITroopsPaginatedDataQueryFactory troopsPaginatedDataQueryFactory) {}
		public void UpdateIsStandingTroop() {}
	}
