// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.WoWWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WonderOfTheWorldWindowController : BuildingDetailWindowController
	{
		// Fields
		private const int MaxStringLength = 25;
		[ObservableValue]
		private string _wowName;
	
		// Properties
		[ObservableValue]
		public string wowName { get => default; set {} }
	
		// Constructors
		public WonderOfTheWorldWindowController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnDestroy() {}
		protected override void CurrentVillageChanged(OwnVillage newVillage) {}
		[UICallable]
		public void SaveNameChange() {}
	}
