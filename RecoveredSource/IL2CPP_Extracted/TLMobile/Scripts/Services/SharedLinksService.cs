// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SharedLinksService : MonoBehaviour, ISharedLinksService
	{
		// Fields
		public const string TravianPageNotFound = "https://travian.com/404";
		public const string DiscordInviteLinkKey = "discord_invite";
		public const string DiscordChangeLogLinkKey = "discord_changeLog";
		[SerializeField]
		private WebViewLinkLocalized supportHome;
		[SerializeField]
		private WebViewLinkLocalized gameRules;
		[SerializeField]
		private WebViewLinkLocalized goldTransferInformation;
	
		// Properties
		public WebViewLinkLocalized SupportHome { get => default; }
		public WebViewLinkLocalized GameRules { get => default; }
		public WebViewLinkLocalized GoldTransferInformation { get => default; }
	
		// Constructors
		public SharedLinksService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void JoinDiscord() {}
		public void OpenDiscordChangeLog() {}
		private void OpenRemoteConfigLink(string remoteConfigKey) {}
	}
