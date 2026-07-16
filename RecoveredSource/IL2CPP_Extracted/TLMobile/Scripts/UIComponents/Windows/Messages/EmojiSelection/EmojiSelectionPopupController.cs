// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages.EmojiSelection
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class EmojiSelectionPopupController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private TMP_SpriteAsset spriteAssets;
		[ObservableValue]
		private int _selectedCount;
		[ObservableValue]
		private string _previewText;
		[ObservableValue]
		private ObservableList<int> _emojiIndices;
		[ObservableValue]
		private ObservableList<string> _emojiSpriteCodes;
		private Action<string> callback;
		private string selectedIconsAsBBCode;
		private List<int> selectedEmojiIndices;
	
		// Properties
		[ObservableValue]
		public int selectedCount { get => default; set {} }
		[ObservableValue]
		public string previewText { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> emojiIndices { get => default; set {} }
		[ObservableValue]
		public ObservableList<string> emojiSpriteCodes { get => default; set {} }
	
		// Constructors
		public EmojiSelectionPopupController() {}
	
		// Methods
		private void _emojiIndicesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _emojiSpriteCodesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void Setup(Action<string> callback) {}
		private void CreateBBCodeString() {}
		private string IndexToSpriteCode(int index) => default;
		private void UpdatePreviewText() {}
		private void SetupSpriteCharacters() {}
		[UICallable]
		public void ConfirmSelection() {}
		[UICallable]
		public void AddEmoji(int index) {}
		[UICallable]
		public void RemoveLastEmoji() {}
	}
