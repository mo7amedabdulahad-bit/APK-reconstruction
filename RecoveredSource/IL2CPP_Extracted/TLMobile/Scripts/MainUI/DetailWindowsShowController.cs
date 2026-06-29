// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DetailWindowsShowController : ViewModel, IBootable
	{
		// Fields
		[ObservableValue]
		private bool _detailWindowIsOpen;
		[ObservableValue]
		private bool _notificationWindowIsOpen;
		private IWindowsService windowsService;
	
		// Properties
		[ObservableValue]
		public bool detailWindowIsOpen { get => default; set {} }
		[ObservableValue]
		public bool notificationWindowIsOpen { get => default; set {} }
	
		// Constructors
		public DetailWindowsShowController() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void FrameUpdate() {}
		[UICallable]
		public virtual DetailWindowController ShowWindow(DetailWindows detailWindowId) => default;
		[UICallable]
		public virtual DetailWindowController ShowWindowAndTab(DetailWindows detailWindowId, int tab) => default;
		[UICallable]
		public virtual DetailWindowController ShowPopup(DetailWindows detailWindowId) => default;
		[UICallable]
		public virtual DropdownListController ShowDropdownListPopup(ObservableList<DropdownOption> dropdownOptions, string popupTitleTranslateKey, Action<DropdownOption> callback, ObservableList<DropdownOption> recentOptions = null) => default;
		[UICallable]
		public virtual DetailWindowController ShowAuctionBuyTabWithFilter(AuctionFilter filter) => default;
		[UICallable]
		public virtual DetailWindowController ShowPlaceBonusPopup(DetailWindows detailWindowId, PlaceBonusInterface selectedPlaceBonus) => default;
		[UICallable]
		public virtual DetailWindowController ShowArtefactFormerOwnerPopup(Artefact selectedArtefact) => default;
		[UICallable]
		public virtual DetailWindowController ShowCancelPopupConstruction(DetailWindows detailWindowId, BuildEvent activity) => default;
		[UICallable]
		public virtual DetailWindowController ShowCancelPopupImprovement(DetailWindows detailWindowId, UnitInDevelopment unit) => default;
		[UICallable]
		public virtual DetailWindowController ShowCancelPopupResearch(DetailWindows detailWindowId, UnitInDevelopment unit) => default;
		[UICallable]
		public virtual UnitInfoController ShowUnitInfo(TroopInfo troopInfo) => default;
		[UICallable]
		public virtual AllianceEditMemberPopupController ShowAllianceEditMember(TLMobile.Generated.GraphQL.Game.Player player) => default;
		[UICallable]
		public virtual AllianceKickPlayerPopupController ShowAllianceKickMember(TLMobile.Generated.GraphQL.Game.Player player) => default;
		[UICallable]
		public virtual RallyPointRaidListEditController ShowEditRaidPopup(FarmList raidListToEdit) => default;
		[UICallable]
		public virtual TroopsTrainingListController ShowTrainingList(Building.TypeId buildingTypeId) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResources(BuildingInfo info) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesForExtensionInfo(TLMobile.Scripts.VillageView.ExtensionInfo info) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesWithoutGoal() => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesForMerge(ResourceAmounts amounts) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesForResearch(ResourceAmounts amounts) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesForCelebration(ResourceAmounts amounts) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesForReviveHero(ResourceAmounts amounts) => default;
		private ExchangeResourcesController ExchangeResourcesControllerWithIntention(ResourceAmounts amounts, ExchangeResourcesController.Intention intention) => default;
		[UICallable]
		public virtual ExchangeResourcesController ShowExchangeResourcesForTroops(TroopInfo info, string callingDetailsWindow = null) => default;
		[UICallable]
		public virtual void ShowGoldClubPopup(GoldClubFeature selectedFeature) {}
		[UICallable]
		public virtual void ShowGoldShop(GoldShopTabs tab = GoldShopTabs.BuyGold, int? missingGold = default) {}
		[UICallable]
		public virtual void ShowGoldShopAdvantagesController(GoldShopAdvantagesController.PlusFeature selectedFeature) {}
		[UICallable]
		public virtual void ShowPrivacySettingPopup() {}
		[UICallable]
		public virtual RallyPointWindowController ShowRallyPoint(RallyPointWindowController.RallyPointTabs activeTab, bool suggestConstruction = true) => default;
		private static RallyPointWindowController GetRallyPointController(bool suggestConstruction) => default;
		[UICallable]
		public virtual void ShowRallyPointTroopsOverviewCategory(RallyPointTroopsOverviewItem.Category category) {}
		[UICallable]
		public JoinAlliancePopup OpenJoinAlliancePopup(AllianceInvitation invitation) => default;
		[UICallable]
		public void OpenWriteNotePopup(TLMobile.Generated.GraphQL.Game.Player player) {}
		[UICallable]
		public void OpenPlayerProfilePopup(int playerId) {}
		[UICallable]
		public void OpenReportWindow(ReportInterface report) {}
		[UICallable]
		public void ShowAllianceEditPermissionsPopup(TLMobile.Generated.GraphQL.Game.Player player) {}
		[UICallable]
		public void ShowCompleteImmediatelyPopup() {}
		[UICallable]
		public void ShowReportPlayerPopup(TLMobile.Generated.GraphQL.Game.Player player) {}
		[UICallable]
		public void ShowReportMessagePopup(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void ShowNewMessagePopup(TLMobile.Generated.GraphQL.Game.Player recipient = null, TLMobile.Generated.GraphQL.Game.Message message = null) {}
		[UICallable]
		public void ShowMessageFullViewPopup(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void ShowToastWarning(string translationKey) {}
		[UICallable]
		public void ShowToastError(string translationKey) {}
		[UICallable]
		public void ShowWebViewPage(string url, string titleKey) {}
		[UICallable]
		public void ShowHeroResourceTransferPopup(ResourcesCostInfo resourcesCostInfo) {}
	}
