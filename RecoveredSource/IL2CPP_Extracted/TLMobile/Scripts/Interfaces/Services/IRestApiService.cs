// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IRestApiService : IService
	{
		// Properties
		IBuildingApi BuildingApi { get; }
		IVillageApi VillageApi { get; }
		IAdSalesApi AdSalesApi { get; }
		IVideoFeatureApi VideoFeatureApi { get; }
		ITroopApi TroopApi { get; }
		IHeroApi HeroApi { get; }
		IPremiumApi PremiumApi { get; }
		IFarmListsApi RaidListApi { get; }
		IGeneralApi GeneralApi { get; }
		IMarketplaceApi MarketplaceApi { get; }
		ITradeRoutesApi TradeRoutesApi { get; }
		IUnitsApi UnitsApi { get; }
		IAllianceApi AllianceApi { get; }
		IPlayerApi PlayerApi { get; }
		IPreferencesApi PreferencesApi { get; }
		INotificationsApi NotificationsApi { get; }
		IShopApi ShopApi { get; }
		IDiplomacyApi DiplomacyApi { get; }
		IReportsApi ReportsApi { get; }
		IProfileApi ProfileApi { get; }
		ITasksApi TasksApi { get; }
		IHeroMansionApi HeroMansionApi { get; }
		IDailyQuestApi DailyQuestApi { get; }
		IMessageApi MessageApi { get; }
		IHospitalApi HospitalApi { get; }
		ITrapperApi TrapperApi { get; }
		ISitterApi SitterApi { get; }
		IBreweryApi BreweryApi { get; }
		IRallyPointApi RallyPointApi { get; }
		IDebugApi DebugApi { get; }
		IFreshdeskApi FreshdeskApi { get; }
		IAvatarApi AvatarApi { get; }
		IInfoboxApi InfoboxApi { get; }
		IAuctionApi AuctionApi { get; }
		IHarbourApi HarbourApi { get; }
		ITreasuryApi TreasuryApi { get; }
		IAuthenticationApi AuthenticationApi { get; }
		IIdentityApi IdentityApi { get; }
		ILobbyApi LobbyApi { get; }
		ICalendarApi CalendarApi { get; }
		INewsApi NewsApi { get; }
		IMetadataApi MetadataApi { get; }
		IVillageGroupsApi VillageGroupsApi { get; }
		IGoldTransferApi GoldTransferApi { get; }
		IGtlApi GtlApi { get; }
		IMapApi MapApi { get; }
	
		// Methods
		void UpdateCookieHeaders(string newValue);
		void UpdateBasePathHeader(string newValue);
	}
