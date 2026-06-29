// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmDeleteRaidListTargetPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<FarmSlot> _raidsInEdit;
		[ObservableValue]
		private RaidsFiltersController.FilterOption _filterFlags;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public GraphQLObservableList<FarmSlot> raidsInEdit { get => default; set {} }
		[ObservableValue]
		public RaidsFiltersController.FilterOption filterFlags { get => default; set {} }
	
		// Constructors
		public ConfirmDeleteRaidListTargetPopupController() {}
	
		// Methods
		private void _raidsInEditNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(System.Action confirmCallback, GraphQLObservableList<FarmSlot> raidsInEdit, RaidsFiltersController.FilterOption? activeFilter = default) {}
		[UICallable]
		public void ConfirmDeleteRaidListTarget() {}
	}
