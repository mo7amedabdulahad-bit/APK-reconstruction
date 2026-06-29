// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewCultureController : VillageOverviewTabController
	{
		// Fields
		[ObservableValue]
		private int _cpProductionSum;
		[ObservableValue]
		private int _settlerSum;
		[ObservableValue]
		private int _chiefSum;
		[ObservableValue]
		private int _slotsUsedSum;
		[ObservableValue]
		private int _slotsTotalSum;
		[ObservableValue]
		private int _settlerSpriteIndex;
		[ObservableValue]
		private int _chiefSpriteIndex;
		private bool updateScheduled;
	
		// Properties
		[ObservableValue]
		public int cpProductionSum { get => default; set {} }
		[ObservableValue]
		public int settlerSum { get => default; set {} }
		[ObservableValue]
		public int chiefSum { get => default; set {} }
		[ObservableValue]
		public int slotsUsedSum { get => default; set {} }
		[ObservableValue]
		public int slotsTotalSum { get => default; set {} }
		[ObservableValue]
		public int settlerSpriteIndex { get => default; set {} }
		[ObservableValue]
		public int chiefSpriteIndex { get => default; set {} }
	
		// Constructors
		public VillageOverviewCultureController() {}
	
		// Methods
		[Testable]
		protected override void GatherVillageInformation(bool forceFetch) {}
		private void ScheduleSumUpdate() {}
		[Testable]
		private void UpdateSums() {}
	}
