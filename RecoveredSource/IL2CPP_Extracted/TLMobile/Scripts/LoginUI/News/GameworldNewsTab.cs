// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.News
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldNewsTab : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private ObservableList<NewsEntry> _newsArticles;
	
		// Properties
		[ObservableValue]
		public ObservableList<NewsEntry> newsArticles { get => default; set {} }
	
		// Constructors
		public GameworldNewsTab() {}
	
		// Methods
		private void _newsArticlesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void FetchNewsEntries() {}
		[UICallable]
		public void OpenNewsEntry(NewsEntry entry) {}
	}
