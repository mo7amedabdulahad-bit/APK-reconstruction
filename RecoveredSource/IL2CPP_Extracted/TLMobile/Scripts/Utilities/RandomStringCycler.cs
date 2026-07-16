// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RandomStringCycler : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private string _oldString;
		[ObservableValue]
		private string _newString;
		[SerializeField]
		private TMP_Text textTop;
		[SerializeField]
		private TMP_Text textBottom;
		[SerializeField]
		private TGFramework.Translate translateTop;
		[SerializeField]
		private TGFramework.Translate translateBottom;
		[SerializeField]
		private CanvasGroup canvasGroupTop;
		[SerializeField]
		private CanvasGroup canvasGroupBottom;
		[SerializeField]
		private List<string> originalList;
		[SerializeField]
		private float delay;
		[SerializeField]
		private float initialDelay;
		[SerializeField]
		private float fadeDuration;
		[SerializeField]
		private float verticalOffset;
		private Queue<string> queue;
		private string lastItem;
		private float timer;
		private DG.Tweening.Sequence rollingSequence;
	
		// Properties
		[ObservableValue]
		public string oldString { get => default; set {} }
		[ObservableValue]
		public string newString { get => default; set {} }
	
		// Constructors
		public RandomStringCycler() {}
	
		// Methods
		[IteratorStateMachine(typeof(_Start_d__23))]
		private IEnumerator Start() => default;
		protected override void OnDestroy() {}
		[ContextMenu("OnFirstLanguageLibraryLoaded")]
		private void OnFirstLanguageLibraryLoaded() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void Update() {}
		private string GetNext() => default;
		[ContextMenu("ResetQueue")]
		private void ResetQueue() {}
		private void StartRoll(string next) {}
	}
