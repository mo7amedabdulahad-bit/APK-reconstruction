// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.SmithyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SmithyUpgradeListController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<UnitInDevelopment> _unitInDevelopment;
		private OwnVillage ownVillage;
		private Smithy smithy;
	
		// Properties
		[ObservableValue]
		public GraphQLObservableList<UnitInDevelopment> unitInDevelopment { get => default; set {} }
	
		// Constructors
		public SmithyUpgradeListController() {}
	
		// Methods
		private void _unitInDevelopmentNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void CurrentVillageChanged(OwnVillage newVill) {}
		public void Setup() {}
	}
