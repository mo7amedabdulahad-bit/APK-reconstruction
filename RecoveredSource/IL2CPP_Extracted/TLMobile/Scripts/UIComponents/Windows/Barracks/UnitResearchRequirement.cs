// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Barracks
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnitResearchRequirement : ObservableModel
	{
		// Fields
		[ObservableValue]
		private ObservableList<RequiredBuilding> _requiredBuildings;
		[ObservableValue]
		private bool _isLastElement;
	
		// Properties
		[ObservableValue]
		public ObservableList<RequiredBuilding> requiredBuildings { get => default; set {} }
		[ObservableValue]
		public bool isLastElement { get => default; set {} }
	
		// Constructors
		public UnitResearchRequirement() {}
	
		// Methods
		private void _requiredBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
	}
