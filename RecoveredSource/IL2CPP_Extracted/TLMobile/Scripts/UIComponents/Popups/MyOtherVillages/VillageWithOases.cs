// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.MyOtherVillages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageWithOases : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private GraphQLFetchableList<OccupiedOasis> _oases;
		[ObservableValue]
		private bool _editMode;
		[ObservableValue]
		private string _editModeVillageName;
		[ObservableValue]
		private string _artefactName;
	
		// Properties
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<OccupiedOasis> oases { get => default; set {} }
		[ObservableValue]
		public bool editMode { get => default; set {} }
		[ObservableValue]
		public string editModeVillageName { get => default; set {} }
		[ObservableValue]
		public string artefactName { get => default; set {} }
	
		// Constructors
		public VillageWithOases() {}
	
		// Methods
		private void _oasesNotify(object sender, PropertyChangedEventArgs args) {}
	}
