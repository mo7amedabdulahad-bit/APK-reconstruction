// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RestApiService : MonoBehaviour, IRestApiService
	{
		// Fields
		public const string CookieHeader = "set-cookie";
		private RestAPI.Client.Configuration configuration;
		private RestAPI.Client.Configuration identityConfiguration;
		private RestAPI.Client.Configuration accountConfiguration;
		private IAdSalesApi adSalesApi;
		private IVideoFeatureApi videoFeatureApi;
		private IAllianceApi allianceApi;
		private IAuctionApi auctionApi;
		private IAvatarApi avatarApi;
		private IBreweryApi breweryApi;
		private IBuildingApi buildingApi;
		private IDailyQuestApi dailyQuestApi;
		private IDebugApi debugApi;
		private IDiplomacyApi diplomacyApi;
		private IFreshdeskApi freshdeskApi;
		private IGeneralApi generalApi;
		private IHarbourApi harbourApi;
		private IHeroApi heroApi;
		private IHeroMansionApi heroMansionApi;
		private IHospitalApi hospitalApi;
		private IInfoboxApi infoboxApi;
		private IMarketplaceApi marketplaceApi;
		private IMessageApi messageApi;
		private IPlayerApi playerApi;
		private IPreferencesApi preferencesApi;
		private INotificationsApi notificationsApi;
		private IPremiumApi premiumApi;
		private IProfileApi profileApi;
		private IFarmListsApi raidListApi;
		private IRallyPointApi rallyPointApi;
		private IReportsApi reportsApi;
		private IShopApi shopApi;
		private ISitterApi sitterApi;
		private ITasksApi tasksApi;
		private ITradeRoutesApi tradeRoutesApi;
		private ITrapperApi trapperApi;
		private ITreasuryApi treasuryApi;
		private ITroopApi troopApi;
		private IUnitsApi unitsApi;
		private IVillageApi villageApi;
		private ICalendarApi calendarApi;
		private INewsApi newsApi;
		private IMetadataApi metadataApi;
		private IAuthenticationApi authenticationApi;
		private IIdentityApi identityApi;
		private ILobbyApi lobbyApi;
		private IVillageGroupsApi villageGroupsApi;
		private IGoldTransferApi goldTransferApi;
		private IGtlApi gtlApi;
		private IMapApi mapApi;
	
		// Properties
		public IAdSalesApi AdSalesApi { get => default; }
		public IVideoFeatureApi VideoFeatureApi { get => default; }
		public ITroopApi TroopApi { get => default; }
		public IHeroApi HeroApi { get => default; }
		public IPremiumApi PremiumApi { get => default; }
		public IVillageApi VillageApi { get => default; }
		public IBuildingApi BuildingApi { get => default; }
		public IFarmListsApi RaidListApi { get => default; }
		public IGeneralApi GeneralApi { get => default; }
		public IMarketplaceApi MarketplaceApi { get => default; }
		public ITradeRoutesApi TradeRoutesApi { get => default; }
		public IUnitsApi UnitsApi { get => default; }
		public IAllianceApi AllianceApi { get => default; }
		public IPlayerApi PlayerApi { get => default; }
		public IPreferencesApi PreferencesApi { get => default; }
		public INotificationsApi NotificationsApi { get => default; }
		public IShopApi ShopApi { get => default; }
		public IDiplomacyApi DiplomacyApi { get => default; }
		public IReportsApi ReportsApi { get => default; }
		public IProfileApi ProfileApi { get => default; }
		public ITasksApi TasksApi { get => default; }
		public IHeroMansionApi HeroMansionApi { get => default; }
		public IDailyQuestApi DailyQuestApi { get => default; }
		public IMessageApi MessageApi { get => default; }
		public IHospitalApi HospitalApi { get => default; }
		public ITrapperApi TrapperApi { get => default; }
		public ISitterApi SitterApi { get => default; }
		public IBreweryApi BreweryApi { get => default; }
		public IRallyPointApi RallyPointApi { get => default; }
		public IDebugApi DebugApi { get => default; }
		public IFreshdeskApi FreshdeskApi { get => default; }
		public IAuctionApi AuctionApi { get => default; }
		public IAvatarApi AvatarApi { get => default; }
		public IInfoboxApi InfoboxApi { get => default; }
		public IHarbourApi HarbourApi { get => default; }
		public ITreasuryApi TreasuryApi { get => default; }
		public IAuthenticationApi AuthenticationApi { get => default; }
		public IIdentityApi IdentityApi { get => default; }
		public ILobbyApi LobbyApi { get => default; }
		public ICalendarApi CalendarApi { get => default; }
		public INewsApi NewsApi { get => default; }
		public IMetadataApi MetadataApi { get => default; }
		public IVillageGroupsApi VillageGroupsApi { get => default; }
		public IGoldTransferApi GoldTransferApi { get => default; }
		public IGtlApi GtlApi { get => default; }
		public IMapApi MapApi { get => default; }
	
		// Constructors
		public RestApiService() {}
	
		// Methods
		private T AssertConfigured<T>(T api) => default;
		public IPromise BootInstance(params object[] args) => default;
		public IPromise Init(params object[] args) => default;
		private RestAPI.Client.Configuration SetupConfiguration(IDictionary<string, string> headers, string url) => default;
		private IPromise ConfigureLobby(IDictionary<string, string> headers, IAuthorizationService authorizationService = null) => default;
		private IPromise ConfigureGameworld(IDictionary<string, string> headers, string restApiUrl) => default;
		public void UpdateCookieHeaders(string newValue) {}
		public void UpdateBasePathHeader(string newValue) {}
	}
