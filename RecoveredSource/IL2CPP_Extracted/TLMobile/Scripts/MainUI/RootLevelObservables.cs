// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RootLevelObservables : ViewModelWithPolling
	{
		// Fields
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		private OwnPlayer _ownPlayer;
		[ObservableValue]
		[PollForUpdates(10f, 6, -1f)]
		private OwnPlayer _ownPlayerReportsCount;
		[ObservableValue]
		[PollForUpdates(10f, 7, 30f)]
		private OwnPlayer _ownPlayerNotCollectedTasksCount;
		[ObservableValue]
		[PollForUpdates(10f, 8, -1f)]
		private OwnPlayer _ownPlayerIsLocked;
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		private OwnVillage _ownVillage;
		[ObservableValue]
		[PollForUpdates(10f, 11, 30f)]
		private OwnVillage _ownVillageNotCollectedTasksCount;
		[ObservableValue]
		[PollForUpdates(4f, 4, 10f)]
		private OwnVillage _ownVillageResources;
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		private OwnHero _hero;
		[ObservableValue]
		[PollForUpdates(10f, 0, -1f)]
		private Generated.GraphQL.Game.Messages _messages;
		[ObservableValue]
		private BootstrapData _bootstrapData;
		[ObservableValue]
		private bool _isDevelopBuild;
		[ObservableValue]
		private bool _isTestEnvironment;
		[ObservableValue]
		private int _currentTimestamp;
		[ObservableValue]
		private bool _isNewSurveyAvailable;
		[ObservableValue]
		private bool _surveyAvailable;
		[ObservableValue]
		private bool _surveyIsRewarded;
		[ObservableValue]
		private int _mapMinX;
		[ObservableValue]
		private int _mapMaxX;
		[ObservableValue]
		private int _mapMinY;
		[ObservableValue]
		private int _mapMaxY;
		[ObservableValue]
		private bool _isRTLLanguage;
		[ObservableValue]
		private bool _hasAShopPromotion;
		[ObservableValue]
		private int _promotionEndsAt;
		[ObservableValue]
		private bool _hasAShopOneTimeOffer;
		private IShopService shopService;
	
		// Properties
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		public OwnPlayer ownPlayer { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 6, -1f)]
		public OwnPlayer ownPlayerReportsCount { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 7, 30f)]
		public OwnPlayer ownPlayerNotCollectedTasksCount { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 8, -1f)]
		public OwnPlayer ownPlayerIsLocked { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		public OwnVillage ownVillage { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 11, 30f)]
		public OwnVillage ownVillageNotCollectedTasksCount { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(4f, 4, 10f)]
		public OwnVillage ownVillageResources { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		public OwnHero hero { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(10f, 0, -1f)]
		public Generated.GraphQL.Game.Messages messages { get => default; set {} }
		[ObservableValue]
		public BootstrapData bootstrapData { get => default; set {} }
		[ObservableValue]
		public bool isDevelopBuild { get => default; set {} }
		[ObservableValue]
		public bool isTestEnvironment { get => default; set {} }
		[ObservableValue]
		public int currentTimestamp { get => default; set {} }
		[ObservableValue]
		public bool isNewSurveyAvailable { get => default; set {} }
		[ObservableValue]
		public bool surveyAvailable { get => default; set {} }
		[ObservableValue]
		public bool surveyIsRewarded { get => default; set {} }
		[ObservableValue]
		public int mapMinX { get => default; set {} }
		[ObservableValue]
		public int mapMaxX { get => default; set {} }
		[ObservableValue]
		public int mapMinY { get => default; set {} }
		[ObservableValue]
		public int mapMaxY { get => default; set {} }
		[ObservableValue]
		public bool isRTLLanguage { get => default; set {} }
		[ObservableValue]
		public bool hasAShopPromotion { get => default; set {} }
		[ObservableValue]
		public int promotionEndsAt { get => default; set {} }
		[ObservableValue]
		public bool hasAShopOneTimeOffer { get => default; set {} }
	
		// Constructors
		public RootLevelObservables() {}
	
		// Methods
		protected override void Awake() {}
		private void OnIsRTLChanged(bool isRTLLanguage) {}
		protected void Start() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void OnShopUpdate() {}
		private void UpdateOneTimeOffer() {}
		protected override void OnDestroy() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void UpdateSurveyState() {}
		private void UpdateShopPromotions() {}
	}
