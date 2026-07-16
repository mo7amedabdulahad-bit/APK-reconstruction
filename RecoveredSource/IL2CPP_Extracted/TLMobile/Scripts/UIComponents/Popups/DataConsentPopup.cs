// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DataConsentPopup : DetailWindowController
	{
		// Fields
		private const string AdvertisementConsentKey = "AdvertConsent";
		private const string AnalyticsConsentKey = "AnalyticsConsent";
		private const string ConsentGivenKey = "PlayerConsentGiven";
		[ObservableValue]
		private bool _isOpen;
		[ObservableValue]
		private bool _advertisingConsent;
		[ObservableValue]
		private bool _analyticsConsent;
		[ObservableValue]
		private bool _choiceChanged;
		private System.Action onClose;
	
		// Properties
		[ObservableValue]
		public bool isOpen { get => default; set {} }
		[ObservableValue]
		public bool advertisingConsent { get => default; set {} }
		[ObservableValue]
		public bool analyticsConsent { get => default; set {} }
		[ObservableValue]
		public bool choiceChanged { get => default; set {} }
		public static bool ConsentGiven { get => default; set {} }
		public static bool AdvertisingConsentGiven { get => default; set {} }
		public static bool AnalyticsConsentGiven { get => default; set {} }
		public static int AnalyticsConsentGivenInt { get => default; set {} }
	
		// Constructors
		public DataConsentPopup() {}
	
		// Methods
		protected override void OnEnable() {}
		public void SetupCallback(System.Action onClose) {}
		[UICallable]
		public void ToggleAdvertisingConsent() {}
		[UICallable]
		public void ToggleAnalyticsConsent() {}
		[UICallable]
		public void AcceptAll() {}
		[UICallable]
		public void RejectAll() {}
		[UICallable]
		public void OpenCompanyPolicy() {}
		[UICallable]
		public void OpenTermsAndConditions() {}
		[UICallable]
		public override void Hide() {}
	}
