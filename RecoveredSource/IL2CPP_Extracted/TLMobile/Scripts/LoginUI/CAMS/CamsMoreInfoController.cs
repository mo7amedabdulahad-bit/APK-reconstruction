// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsMoreInfoController : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private bool _showMoreInfo;
		[ObservableValue]
		private int _showQuestionIndex;
		private ContentSizeFitter contentSizeFitter;
		private LayoutElement layoutElement;
		private Vector2 originalSize;
		private RectTransform rectTransform;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public bool showMoreInfo { get => default; set {} }
		[ObservableValue]
		public int showQuestionIndex { get => default; set {} }
	
		// Constructors
		public CamsMoreInfoController() {}
	
		// Methods
		protected override void Awake() {}
		protected void OnEnable() {}
		private void ToggleMoreInfo() {}
		[UICallable]
		public void ToggleQuestionIndex(int index) {}
	}
