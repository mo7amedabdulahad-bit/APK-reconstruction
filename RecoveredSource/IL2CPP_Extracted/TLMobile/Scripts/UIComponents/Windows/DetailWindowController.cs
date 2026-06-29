// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DetailWindowController : TLMViewModel
	{
		// Fields
		private const string LastTabPlayPrefKey = "LastTab";
		private const string LastSubTabPlayPrefKey = "LastSubTab";
		[SerializeField]
		private bool skipAnimations;
		public int defaultTab;
		public bool rememberLastTab;
		public List<DetailWindowTabController> availableTabs;
		public RectTransform contentMask;
		public List<int> tabsOnlyWithPlus;
		public List<int> tabsOnlyWithGold;
		private readonly List<DetailWindowTabController> instantiatedTabs;
		[ObservableValue]
		private int _currentWindowTab;
		public System.Action OnShowAnimationDone;
		private DG.Tweening.Sequence mySequence;
		protected bool skipDefaultTab;
	
		// Properties
		[ObservableValue]
		public int currentWindowTab { get => default; set {} }
		public DetailWindows WindowID { get; set; }
	
		// Events
		public event System.Action OnHide;
	
		// Constructors
		public DetailWindowController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDestroy() {}
		[Testable]
		protected virtual void OpenDefaultTab() {}
		[UICallable]
		public virtual void Hide() {}
		private CanvasGroup GetCanvasGroup(DetailWindowTabController windowTabController) => default;
		[UICallable]
		public virtual DetailWindowTabController SetWindowTab(int newTabIndex) => default;
		[UICallable]
		public virtual T SetWindowTab<T>()
			where T : DetailWindowTabController => default;
		[UICallable]
		public void HideIfNoKeyboard() {}
		public DetailWindowTabController GetCurrentTab() => default;
		public int GetLastSelectedSubTab() => default;
		public T GetLastSelectedSubTab<T>()
			where T : Enum => default;
		public void SaveLastSelectedSubTab(int subTab) {}
	}
