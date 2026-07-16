// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GloriaMedalController : InjectableViewModel
	{
		// Fields
		public UnityEngine.UI.Image image;
		[ObservableValue]
		private MedalLifetime _medal;
		[InjectableValue]
		[ObservableValue]
		private MedalsPicker.MedalData _injectableMedal;
	
		// Properties
		[ObservableValue]
		public MedalLifetime medal { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public MedalsPicker.MedalData injectableMedal { get => default; set {} }
		private static Dictionary<int, Sprite> CachedMedalImages { get; }
	
		// Constructors
		public GloriaMedalController() {}
		static GloriaMedalController() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		public void Setup(MedalLifetime medalLifetime) {}
		private void SetSprite(string imgUrl, int id) {}
		private void OnImageDownloaded(HTTPRequest originalRequest, HTTPResponse response, int id) {}
	}
