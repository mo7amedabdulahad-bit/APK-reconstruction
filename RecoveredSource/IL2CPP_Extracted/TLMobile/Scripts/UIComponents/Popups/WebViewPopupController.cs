// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WebViewPopupController : DetailWindowController
	{
		// Fields
		public RectTransform referenceRect;
		[ObservableValue]
		private string _translationKey;
		private bool clearCookiesAfterClose;
		private Action<string> htmlContentCallback;
		private UniWebView uniWebView;
	
		// Properties
		[ObservableValue]
		public string translationKey { get => default; set {} }
	
		// Constructors
		public WebViewPopupController() {}
	
		// Methods
		public static WebViewPopupController SetupWithFallback(string url, string titleKey, Action<string> analyseHtmlContentCallback = null, string fallbackContent = null) => default;
		public void Setup(string url, string titleKey, Action<string> analyseHtmlContentCallback = null) {}
		[UICallable]
		public override void Hide() {}
		private void FinaliseHide(string content) {}
		public void ClearCookiesAfterClose() {}
	}
