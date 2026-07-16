// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MilitaryStrengthStatisticsController : BaseStatisticsController
	{
		// Fields
		public PieChart pieChart;
		public IntMaterialDictionary materials;
		[ObservableValue]
		private MilitaryStrengthView _activeView;
		[ObservableValue]
		private float _betterPercentage;
		[ObservableValue]
		private int? _betterValue;
		[ObservableValue]
		private int _currentVillageId;
		[ObservableValue]
		private int _rank;
		[ObservableValue]
		private int _rankAlliance;
		[ObservableValue]
		private int _strength;
		[ObservableValue]
		private int _strengthSum;
		[ObservableValue]
		private int? _villageId;
		[ObservableValue]
		private float _worsePercentage;
		[ObservableValue]
		private int? _worseValue;
		private GraphQLFetchableList<MilitaryRank> allMilitaryRanks;
		private MilitaryRank militaryRank;
		private MilitaryRank militaryRankCurrentVillage;
	
		// Properties
		[ObservableValue]
		public MilitaryStrengthView activeView { get => default; set {} }
		[ObservableValue]
		public float betterPercentage { get => default; set {} }
		[ObservableValue]
		public int? betterValue { get => default; set {} }
		[ObservableValue]
		public int currentVillageId { get => default; set {} }
		[ObservableValue]
		public int rank { get => default; set {} }
		[ObservableValue]
		public int rankAlliance { get => default; set {} }
		[ObservableValue]
		public int strength { get => default; set {} }
		[ObservableValue]
		public int strengthSum { get => default; set {} }
		[ObservableValue]
		public int? villageId { get => default; set {} }
		[ObservableValue]
		public float worsePercentage { get => default; set {} }
		[ObservableValue]
		public int? worseValue { get => default; set {} }
	
		// Constructors
		public MilitaryStrengthStatisticsController() {}
	
		// Methods
		private void CurrentVillageChanged(OwnVillage newVill) {}
		protected override void Setup() {}
		protected override void OnDestroy() {}
		private void FetchAllVillages() {}
		private void SetupPieChart() {}
		[UICallable]
		public void ChangeView(MilitaryStrengthView view) {}
	}
