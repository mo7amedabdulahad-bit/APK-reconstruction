// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS.AvatarCreation
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsJoinNewGameworldWindowController : DetailWindowController
	{
		// Fields
		private const string TitleTribeSelection = "anmelden.vid_choose";
		private const string TitleSectorSelection = "anmelden.sector_choose";
		private const string TitleConfirmSelection = "anmelden.confirmSelection";
		private const string ButtonSelectTribeKey = "cams_avatarCreation_button_selectTribe";
		private const string ButtonUpdateTribeKey = "cams_avatarCreation_button_updateTribe";
		private const string ButtonSelectSectorKey = "cams_avatarCreation_button_selectSector";
		private const string ButtonUpdateSectorKey = "cams_avatarCreation_button_updateSector";
		private const string ButtonConfirmSelectionKey = "cams_avatarCreation_button_startPlaying";
		private const string SectorSelectionNWKey = "anmelden.activation_sectorSelection_northWest";
		private const string SectorSelectionNOKey = "anmelden.activation_sectorSelection_northEast";
		private const string SectorSelectionSWKey = "anmelden.activation_sectorSelection_southWest";
		private const string SectorSelectionSOKey = "anmelden.activation_sectorSelection_southEast";
		private const string InputfieldTextPlaceholder = "cams_avatarCreation_name_placeHolder";
		private const string InputfieldTextError = "cams_avatarCreation_name_errorEmpty";
		[HideInInspector]
		public DatabindingReceiverFeeder myFeeder;
		[ObservableValue]
		private int _recommendedTribe;
		[ObservableValue]
		private int _recommendedSector;
		[ObservableValue]
		private bool _buttonDisabled;
		[ObservableValue]
		private int _selectedTribe;
		[ObservableValue]
		private int _selectedArea;
		[ObservableValue]
		private string _titleTranslationKey;
		[ObservableValue]
		private string _buttonTranslationKey;
		[ObservableValue]
		private string _sectorTranslationKey;
		[ObservableValue]
		private string _placeholderTranslated;
		[ObservableValue]
		private string _errorMessage;
		[InjectableValue]
		[ObservableValue]
		private string _avatarName;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _selectedGameworld;
		[ObservableValue]
		private int _lastOpenedTab;
		[ObservableValue]
		private bool _firstOpening;
		[ObservableValue]
		private bool _isRespawnFeature;
		private string avatarCookie;
		private System.Action buttonAction;
		private Action<ApiException> onRespawnError;
		private bool isRequestInProgress;
	
		// Properties
		[ObservableValue]
		public int recommendedTribe { get => default; set {} }
		[ObservableValue]
		public int recommendedSector { get => default; set {} }
		[ObservableValue]
		public bool buttonDisabled { get => default; set {} }
		[ObservableValue]
		public int selectedTribe { get => default; set {} }
		[ObservableValue]
		public int selectedArea { get => default; set {} }
		[ObservableValue]
		public string titleTranslationKey { get => default; set {} }
		[ObservableValue]
		public string buttonTranslationKey { get => default; set {} }
		[ObservableValue]
		public string sectorTranslationKey { get => default; set {} }
		[ObservableValue]
		public string placeholderTranslated { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public string avatarName { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld selectedGameworld { get => default; set {} }
		[ObservableValue]
		public int lastOpenedTab { get => default; set {} }
		[ObservableValue]
		public bool firstOpening { get => default; set {} }
		[ObservableValue]
		public bool isRespawnFeature { get => default; set {} }
	
		// Constructors
		public CamsJoinNewGameworldWindowController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void OnInjectedValueChanged() {}
		public void Setup(TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld, ApiResponse<InlineResponse2005> inviteCodeServerResponse = null) {}
		public void SetupRespawn(TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld, int selectedTribe, int selectedSector, string avatarName, Action<ApiException> onError = null) {}
		private void HandleResponse(ApiResponse<InlineResponse2005> response) {}
		private void FinishFirstSetup() {}
		private void FinishAvatarCreation() {}
		private void OnSceneLoaded() {}
		private void OnError(Exception err) {}
		private void RespawnOnGameworld() {}
		private void NewJoinedGameworld() {}
		private void SetLoadingAnimation(bool visible, string loadingReason) {}
		[UICallable]
		public void OnButtonAction() {}
		private void CheckButtonState() {}
		public override DetailWindowTabController SetWindowTab(int newTabIndex) => default;
		private void SelectSector(int x) {}
		[UICallable]
		public void OpenCancelAvatarCreationPopup() {}
		protected override void OnDestroy() {}
	}
