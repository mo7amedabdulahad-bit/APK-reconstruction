// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableBuildingInfo : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private BuildingInfo _buildingInfo;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public BuildingInfo buildingInfo { get => default; set {} }
	
		// Constructors
		public InjectableBuildingInfo() {}
	}
