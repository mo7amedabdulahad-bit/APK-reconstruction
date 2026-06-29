// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.News
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldNewsArticleTab : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private NewsEntry _newsArticle;
		[SerializeField]
		private RectTransform referenceRect;
		private UniWebView uniWebView;
	
		// Properties
		[ObservableValue]
		public NewsEntry newsArticle { get => default; set {} }
	
		// Constructors
		public GameworldNewsArticleTab() {}
	
		// Methods
		protected override void OnDisable() {}
		public override void OnOpen(int tabIndex) {}
		private void SetupArticleView() {}
		private void OnPageFinished(UniWebView webView, int statusCode, string url) {}
		public void Cleanup() {}
	}
