// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnitInfoController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<UnitResearchRequirement> _prerequisitesForResearch;
		[ObservableValue]
		private TroopInfo _troopInfo;
		[ObservableValue]
		private ObservableDictionary<RequiredBuilding, bool> _buildingIsAlreadyInVillage;
		[ObservableValue]
		private bool _unitWithSpecialBuildingLevelRequirement;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public GraphQLObservableList<UnitResearchRequirement> prerequisitesForResearch { get => default; set {} }
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<RequiredBuilding, bool> buildingIsAlreadyInVillage { get => default; set {} }
		[ObservableValue]
		public bool unitWithSpecialBuildingLevelRequirement { get => default; set {} }
	
		// Constructors
		public UnitInfoController() {}
	
		// Methods
		private void _prerequisitesForResearchNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildingIsAlreadyInVillageNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Setup(TroopInfo troop) {}
		private bool IsRequiredBuildingAvailable(RequiredBuilding requiredBuilding) => default;
	}
