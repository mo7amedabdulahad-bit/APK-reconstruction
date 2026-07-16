// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.WaterworksWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WaterworksOasisTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<OasisExtensionHolder> _oasesList;
		[ObservableValue]
		private float _effectValue;
		private BootstrapData bootstrapData;
		private HeroMansion heroMansion;
		private OwnVillage ownVillage;
	
		// Properties
		[ObservableValue]
		public GraphQLObservableList<OasisExtensionHolder> oasesList { get => default; set {} }
		[ObservableValue]
		public float effectValue { get => default; set {} }
	
		// Constructors
		public WaterworksOasisTabController() {}
	
		// Methods
		private void _oasesListNotify(object sender, PropertyChangedEventArgs args) {}
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		[Testable]
		private void UpdateDisplayedList() {}
		[UICallable]
		public void OpenOasisMapCell(OasisInterface oasis) {}
	}
