// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class EditDescriptionBase : GenericPopupWithInsertInEditButton
	{
		// Fields
		[ObservableValue]
		private int _availableMedalsCount;
		[ObservableValue]
		private string _currentColumn1;
		[ObservableValue]
		private string _currentColumn2;
		protected ObservableList<MedalsPicker.MedalData> medalDataForPicker;
		protected ObservableList<MedalsPicker.MedalData> playerMedals;
	
		// Properties
		[ObservableValue]
		public int availableMedalsCount { get; set; }
		[ObservableValue]
		public string currentColumn1 { get; set; }
		[ObservableValue]
		public string currentColumn2 { get; set; }
	
		// Constructors
		protected EditDescriptionBase() {}
	
		// Methods
		protected override void Awake() {}
		protected void Setup() {}
		public virtual void UpdateAvailableMedals() {}
		protected bool FilterMedalForPicker(MedalsPicker.MedalData medal) => default;
		[UICallable]
		public virtual void OpenMedals() {}
		protected virtual void OnMedalSelected(string medalCode) {}
		protected void FillPlayerGameworldMedals(GraphQLObservableList<MedalGameworld> profileMedalsGameworld) {}
		protected void FillPlayerGloriaMedals(GraphQLObservableList<MedalLifetime> profileMedalsLifetime) {}
		protected void FillPlayerAllianceMedals(GraphQLObservableList<AllianceMedal> profileMedalsAlliance) {}
	}
