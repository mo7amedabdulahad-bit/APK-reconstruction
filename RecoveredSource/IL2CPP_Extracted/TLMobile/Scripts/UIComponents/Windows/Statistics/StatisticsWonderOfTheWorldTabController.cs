// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StatisticsWonderOfTheWorldTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private GraphQLFetchableList<WonderOfWorldStatEntry> _worldOfWonders;
	
		// Properties
		[ObservableValue]
		public GraphQLFetchableList<WonderOfWorldStatEntry> worldOfWonders { get => default; set {} }
	
		// Constructors
		public StatisticsWonderOfTheWorldTabController() {}
	
		// Methods
		private void _worldOfWondersNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		private void Init() {}
		[UICallable]
		public void ClickBehaviour(WonderOfWorldStatEntry entry) {}
	}
