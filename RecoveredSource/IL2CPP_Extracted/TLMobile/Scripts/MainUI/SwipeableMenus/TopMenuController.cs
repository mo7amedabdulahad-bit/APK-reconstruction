// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.SwipeableMenus
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TopMenuController : TLMViewModel
	{
		// Fields
		public float toggledOnBoxHeight;
		public float toggledOffBoxHeight;
		public float toggledOnBarHeight;
		public float toggledOffBarHeight;
		public float toggledOnAlphaValue;
		public float toggledOffAlphaValue;
		public float toggledOnGoldIconSize;
		public float toggledOffGoldIconSize;
		[ObservableValue]
		private Wallet _wallet;
		[ObservableValue]
		private int _swipeValue;
		[ObservableValue]
		private float _boxHeight;
		[ObservableValue]
		private float _barHeight;
		[ObservableValue]
		private float _alphaValue;
		[ObservableValue]
		private float _goldIconSize;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Resource _resources;
		[ObservableValue]
		private ObservableList<ProductionBoost> _productionBoosts;
		private OwnVillage currentVillage;
		private Coroutine interpolationCoroutine;
	
		// Properties
		[ObservableValue]
		public Wallet wallet { get => default; set {} }
		[ObservableValue]
		public int swipeValue { get => default; set {} }
		[ObservableValue]
		public float boxHeight { get => default; set {} }
		[ObservableValue]
		public float barHeight { get => default; set {} }
		[ObservableValue]
		public float alphaValue { get => default; set {} }
		[ObservableValue]
		public float goldIconSize { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Resource resources { get => default; set {} }
		[ObservableValue]
		public ObservableList<ProductionBoost> productionBoosts { get => default; set {} }
	
		// Constructors
		public TopMenuController() {}
	
		// Methods
		private void _productionBoostsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void OnSwiped() {}
		private void UpdateResourcesValues() {}
		[IteratorStateMachine(typeof(_InterpolateResourceValues_d__50))]
		private IEnumerator InterpolateResourceValues() => default;
	}
