// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Banned
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BannedPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private string _banDescription;
		[ObservableValue]
		private string _punishmentList;
		[ObservableValue]
		private int _autoAcceptTime;
		[ObservableValue]
		private BanInfo _banInfo;
		[ObservableValue]
		private ExternalURLs _externalUrls;
		[ObservableValue]
		private bool _hasData;
		private Action<OwnVillage> callback;
		private OwnPlayer ownPlayer;
	
		// Properties
		[ObservableValue]
		public string banDescription { get => default; set {} }
		[ObservableValue]
		public string punishmentList { get => default; set {} }
		[ObservableValue]
		public int autoAcceptTime { get => default; set {} }
		[ObservableValue]
		public BanInfo banInfo { get => default; set {} }
		[ObservableValue]
		public ExternalURLs externalUrls { get => default; set {} }
		[ObservableValue]
		public bool hasData { get => default; set {} }
	
		// Constructors
		public BannedPopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		private void CheckLockedStatus() {}
		private void UpdateBanMessages() {}
		[UICallable]
		public void ContactSupport() {}
		[UICallable]
		public void OpenGameRules() {}
		[UICallable]
		public void AcceptPunishment() {}
	}
