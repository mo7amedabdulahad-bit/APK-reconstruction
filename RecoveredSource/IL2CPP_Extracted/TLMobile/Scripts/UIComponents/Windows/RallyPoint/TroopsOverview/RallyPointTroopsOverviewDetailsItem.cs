// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointTroopsOverviewDetailsItem : ObservableModel
	{
		// Fields
		[ObservableValue]
		private TroopsEntityType _troopsEntityType;
		[ObservableValue]
		private bool _expanded;
		[ObservableValue]
		private MovingTroop _movingTroop;
		[ObservableValue]
		private StandingTroop _standingTroop;
		[ObservableValue]
		private TroopAmounts _troopAmounts;
		[ObservableValue]
		private int _totalCarry;
		[ObservableValue]
		private bool _actionPanelOpen;
		[ObservableValue]
		private PossibleAction _possibleActions;
		public string PaginationCursorNext;
		public string PaginationCursor;
	
		// Properties
		[ObservableValue]
		public TroopsEntityType troopsEntityType { get => default; set {} }
		[ObservableValue]
		public bool expanded { get => default; set {} }
		[ObservableValue]
		public MovingTroop movingTroop { get => default; set {} }
		[ObservableValue]
		public StandingTroop standingTroop { get => default; set {} }
		[ObservableValue]
		public TroopAmounts troopAmounts { get => default; set {} }
		[ObservableValue]
		public int totalCarry { get => default; set {} }
		[ObservableValue]
		public bool actionPanelOpen { get => default; set {} }
		[ObservableValue]
		public PossibleAction possibleActions { get => default; set {} }
	
		// Nested types
		[Flags]
		public enum PossibleAction
		{
			None = 0,
			SendBack = 1,
			Forward = 2,
			Merge = 4,
			Release = 8,
			Kill = 16
		}
	
		// Constructors
		public RallyPointTroopsOverviewDetailsItem() {}
		public RallyPointTroopsOverviewDetailsItem(StandingTroopEdge standingTroopEdge) {}
		public RallyPointTroopsOverviewDetailsItem(MovingTroop movingTroop) {}
	
		// Methods
		public bool IsStillRelevant() => default;
		public bool UpdateTroopsEntityType() => default;
	}
