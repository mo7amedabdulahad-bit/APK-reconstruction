// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MovementInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private RallyPointTroopsOverviewItem.Category _type;
		[ObservableValue]
		private int? _firstArriving;
		[ObservableValue]
		private int _amount;
	
		// Properties
		[ObservableValue]
		public RallyPointTroopsOverviewItem.Category type { get => default; set {} }
		[ObservableValue]
		public int? firstArriving { get => default; set {} }
		[ObservableValue]
		public int amount { get => default; set {} }
	
		// Constructors
		[Obsolete("Framework compatibility constructor, use constructor for parameters in code.")]
		public MovementInfo() {}
		public MovementInfo(int? arrivalTime, RallyPointTroopsOverviewItem.Category type, Generated.GraphQL.Game.TroopsOverview troopsOverview) {}
	
		// Methods
		private void Setup(int? arrivalTime, RallyPointTroopsOverviewItem.Category type, Generated.GraphQL.Game.TroopsOverview troopsOverview) {}
	}
