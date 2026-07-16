// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Debug
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DebugMenuPopupController : DetailWindowController
	{
		// Fields
		private Coroutine unloadingAssetsCoroutine;
		private bool unloadingAssets;
		private Coroutine testPurchaseCoroutine;
		[ObservableValue]
		private string _currentVersion;
		[ObservableValue]
		private bool _isUsingDevServers;
		[ObservableValue]
		private bool _tutorialOnRailsCompletion;
		public const string DebugAccountsPrefsKey = "DebugAccountsPrefsKey";
		private DebugFunction.AccessLevel accessLevel;
		[ObservableValue]
		private ObservableList<System.Action> _debugMethods;
		[ObservableValue]
		private ObservableList<DebugAccount> _debugAccounts;
		[ObservableValue]
		private bool _isDevelopBuild;
		[ObservableValue]
		private string _buildVersion;
		[ObservableValue]
		private bool _isUsabilityTestBuild;
		[ObservableValue]
		private bool _lastLinkIsRecognized;
		[ObservableValue]
		private int _logLevel;
		[ObservableValue]
		private string _currentLobbyCookie;
		private List<Texture2D> texturesToCrash;
	
		// Properties
		[ObservableValue]
		public string currentVersion { get => default; set {} }
		[ObservableValue]
		public bool isUsingDevServers { get => default; set {} }
		[ObservableValue]
		public bool tutorialOnRailsCompletion { get => default; set {} }
		[ObservableValue]
		public ObservableList<System.Action> debugMethods { get => default; set {} }
		[ObservableValue]
		public ObservableList<DebugAccount> debugAccounts { get => default; set {} }
		[ObservableValue]
		public bool isDevelopBuild { get => default; set {} }
		[ObservableValue]
		public string buildVersion { get => default; set {} }
		[ObservableValue]
		public bool isUsabilityTestBuild { get => default; set {} }
		[ObservableValue]
		public bool lastLinkIsRecognized { get => default; set {} }
		[ObservableValue]
		public int logLevel { get => default; set {} }
		[ObservableValue]
		public string currentLobbyCookie { get => default; set {} }
	
		// Constructors
		public DebugMenuPopupController() {}
	
		// Methods
		private void _debugMethodsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _debugAccountsNotify(object sender, PropertyChangedEventArgs args) {}
		private void SetupBase() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void OnLinkActivationResultChanged(UniversalDeepLinkingService.LinkActivationResult lastLinkActivation) {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void DebugGameInfo() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void DebugCrash() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void DebugLaunchAdInspector() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void DebugCopyPushNotificationData() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void PrintAppSize() {}
		public void PrintAppSize(string suffix) {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void SetDebugLevel() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ToggleGraphQLLogging() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ToggleGraphQLResponseLogging() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ToggleLoggingHTTPBody() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ToggleRestAPILogging() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void TestDebugLogs() {}
		[IteratorStateMachine(typeof(_DoForceUnloadAssets_d__53))]
		private IEnumerator DoForceUnloadAssets() => default;
		private string FormatBytesToMB(long bytes) => default;
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ForceUnloadAssets() {}
		protected void CallDebugFunctionWithInputField(string command, System.Action refresh = null, string title = "", string defaultInput = "") {}
		protected void CallbackWithInputFieldResponse(Action<string> refresh = null, string title = "", string defaultInput = "") {}
		protected IPromise<string> CallDebugFunctionWithInput(string command, System.Action refresh = null, string input = "") => default;
		protected IPromise<string> CallDebugFunction(string command, System.Action refresh = null) => default;
		private void UpdateBuildSettings() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ShowLastLinkActivated() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void OpenLinkNotWorkingPopup() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void StartEmptyGraphQLRequest() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void SetGameWorldURLNull() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void ResetGameWorldURL() {}
		protected void Restart() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void FillRamUntilCrash() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void Shop_IOS_ToggleBrokenPurchasing() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void Shop_ToggleSimulateBackendNotReachablePurchasing() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void OpenDebugMenuSettingsPopup() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void DeletePlayerPrefByKey() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void TargetFrameRate_1() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void TargetFrameRate_10() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void TargetFrameRate_30() {}
		private void SetupGame() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void FillUpResources() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void FillUpTroops() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void FillUpInventory() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void PimpVillage() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SpeedUpAllEvents() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SpeedUpPlayerEvents() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SpeedUpBuildEvents() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SpeedUpTradeEvents() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SpeedUpTroopEvents() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void CreateReports() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void HeroAlive() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void ChangePlayersTribe() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SetGold() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SetSilver() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SetCulturePoints() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void CreateVillage() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void ConquerVillage() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void CustomCheat() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SetGoldClub() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SetTravianPlus() {}
		[IteratorStateMachine(typeof(_TestPurchaseCoroutine_d__97))]
		private IEnumerator TestPurchaseCoroutine(BuyGoldController buyGoldController, string testProductId, int amount, float delay) => default;
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void SaveTestPendingPurchaseData() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void ToggleWorkingAdsResources() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void LoadAndShowAllPendingPurchases() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void DebugRemoveAllPendingPurchases() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void CreateDummySystemMessages() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void CurrentSitterPermissions() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void CurrentPlayerInfo() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void RefreshALot() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Game)]
		public void ClearRTATrackingData() {}
		private void BasicRefresh() {}
		private void PlayerRefresh() {}
		private void VillageRefresh() {}
		private void HeroRefresh() {}
		private void SetupLobby() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void ToggleIsDevelopBuild() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void ToggleIsUsabilityTestBuild() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void ChangeBuildVersion() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void RestartLoginFlow() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void GetAdvertisementID_IOS() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void GetAdvertisementID_ANDROID() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void ClearAllPlayerPrefs() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenRegistration() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenLogin() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenActivation() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenSetPassword() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenSetUsername() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenLobby() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenCamsAccountCreated() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void OpenWindow() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void ToggleUsingLiveOrDevServers() {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Lobby)]
		public void ToggleTutorialOnRailsCompletion() {}
		public void Setup(DebugFunction.AccessLevel level) {}
		[DebugFunction(accessLevel = DebugFunction.AccessLevel.Everywhere)]
		public void HideDebugButton() {}
		[UICallable]
		public void LoginDebugAccount(DebugAccount account) {}
		[UICallable]
		public void DeleteLoginAccount(DebugAccount account) {}
		[UICallable]
		public void OpenAddDebugAccountToList() {}
		private void CreateLoginAccount(string displayName, string username, string password) {}
	}
