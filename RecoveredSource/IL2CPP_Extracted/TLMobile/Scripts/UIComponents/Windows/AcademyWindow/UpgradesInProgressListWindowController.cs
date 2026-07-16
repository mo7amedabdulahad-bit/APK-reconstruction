// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AcademyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UpgradesInProgressListWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Wall _wall;
		[ObservableValue]
		private string _watchTowerName;
	
		// Properties
		[ObservableValue]
		public Wall wall { get => default; set {} }
		[ObservableValue]
		public string watchTowerName { get => default; set {} }
	
		// Constructors
		public UpgradesInProgressListWindowController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void OnLanguageChanged() {}
		public void Setup(OwnVillage village) {}
		private void CheckStillValid() {}
	}
