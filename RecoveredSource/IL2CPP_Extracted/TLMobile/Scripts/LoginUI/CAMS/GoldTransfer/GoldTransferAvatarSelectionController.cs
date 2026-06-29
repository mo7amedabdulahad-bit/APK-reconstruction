// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS.GoldTransfer
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldTransferAvatarSelectionController : TLMViewModel
	{
		// Fields
		private const string NoErrorText = " ";
		[ObservableValue]
		private ObservableList<AvatarGameworldInfo> _avatarSearchResults;
		[ObservableValue]
		private string _searchError;
		[SerializeField]
		private GoldTransferWindowController goldTransferController;
		[SerializeField]
		private AdvancedInputField avatarNameField;
		private List<AvatarGameworldInfo> ownAvatars;
	
		// Properties
		[ObservableValue]
		public ObservableList<AvatarGameworldInfo> avatarSearchResults { get => default; set {} }
		[ObservableValue]
		public string searchError { get => default; set {} }
	
		// Constructors
		public GoldTransferAvatarSelectionController() {}
	
		// Methods
		private void _avatarSearchResultsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void ViewStateChanged() {}
		private void PopulateOwnAvatars(System.Action onFinished) {}
		[UICallable]
		public void SearchAvatarsByName() {}
		[UICallable]
		public void SelectAvatar(int index) {}
	}
