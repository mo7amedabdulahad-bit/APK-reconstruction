// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsLobbyGameWorldOverview : CamsDetailLobbyTabController
	{
		// Fields
		[ObservableValue]
		private ObservableList<Avatar> _avatars;
		[ObservableValue]
		private ObservableList<Avatar> _legacyAvatars;
		[ObservableValue]
		private ObservableDictionary<string, GameworldDualInvites> _gameworldDualInvites;
		[ObservableValue]
		private ObservableDictionary<string, GameworldDualInvites> _allGameworldDualInvites;
		[SerializeField]
		private TGFramework.Repeat repeat;
		[ObservableValue]
		[PollForUpdates(5f, 1, -1f)]
		private GraphQLFetchableList<Avatar> _allSimpleAvatars;
		[ObservableValue]
		[PollForUpdates(5f, 1, -1f)]
		private GraphQLFetchableList<DualInvite> _allDualInvites;
		private List<Avatar> allAvatars;
		private List<Avatar> allLegacyAvatars;
		public List<int> runningPromisesIds;
		private List<SimpleAvatar> lastAvatars;
		private List<ValueTuple<string, string>> lastDualInvites;
	
		// Properties
		[ObservableValue]
		public ObservableList<Avatar> avatars { get => default; set {} }
		[ObservableValue]
		public ObservableList<Avatar> legacyAvatars { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<string, GameworldDualInvites> gameworldDualInvites { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<string, GameworldDualInvites> allGameworldDualInvites { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(5f, 1, -1f)]
		public GraphQLFetchableList<Avatar> allSimpleAvatars { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(5f, 1, -1f)]
		public GraphQLFetchableList<DualInvite> allDualInvites { get => default; set {} }
	
		// Constructors
		public CamsLobbyGameWorldOverview() {}
	
		// Methods
		private void _avatarsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _legacyAvatarsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _gameworldDualInvitesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allGameworldDualInvitesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allSimpleAvatarsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allDualInvitesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void RefreshAvatars() {}
		private static void UpdateAvatar(Avatar avatar, Avatar fetchedSimpleAvatar) {}
		private void RemoveAvatarsInDeletionWithAcceptedDualPlay() {}
		private void RefreshDualInvites() {}
		private void RemovePromiseIdFromRunningPromises(int id) {}
		private void FilterDualInvitesWhichAreAccepted() {}
		private void UpdateDualInvites(List<DualInvite> dualInvites, string dualInviteUuid) {}
		private void UpdateGameworldDualInvites() {}
		private void RefreshAvatarsAndDualInvites() {}
		[UICallable]
		public void EditDuals(Avatar avatar) {}
		[UICallable]
		public void EditInvite(GameworldDualInvites gameworldDualInvites) {}
		[UICallable]
		public void EditDualSettings(Avatar avatar) {}
		[UICallable]
		public void PlayNow(Avatar avatar) {}
		public static void PlayNowWithDualCheck(Avatar avatar, List<Avatar> allAvatars, bool ignoreAskForDirectLoginPopup = false) {}
		public static void ProceedToGameworld(Avatar avatar) {}
		private static void OnSceneLoaded() {}
	}
