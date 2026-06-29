// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageTargetSearchPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Coordinate _target;
		private Action<TLMobile.Generated.GraphQL.Game.Coordinate> callback;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Coordinate target { get => default; set {} }
	
		// Constructors
		public VillageTargetSearchPopupController() {}
	
		// Methods
		public void Setup(Action<TLMobile.Generated.GraphQL.Game.Coordinate> callback) {}
		[UICallable]
		public void SelectTarget(int x, int y) {}
		[UICallable]
		public override void Hide() {}
	}
