// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericTargetSelection : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private Village _targetVillage;
		[ObservableValue]
		private string _villageFetchServerError;
		[ObservableValue]
		private TargetRelation _relationToTarget;
		[ObservableValue]
		private bool _enableConfirmButton;
		[SerializeField]
		private RectTransform mapPreviewTransform;
		[SerializeField]
		private RawImage mapDisplayImage;
		protected OwnPlayer currentPlayer;
		protected int? disabledVillageId;
		protected string clickOnDisabledVillageTranslationKey;
		private bool xInputDone;
		private bool yInputDone;
		private Vector2Int? lastMapTargetPosition;
		private bool blockUpdates;
		private Village expectedVillage;
	
		// Properties
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
		[ObservableValue]
		public string villageFetchServerError { get => default; set {} }
		[ObservableValue]
		public TargetRelation relationToTarget { get => default; set {} }
		[ObservableValue]
		public bool enableConfirmButton { get => default; set {} }
	
		// Constructors
		public GenericTargetSelection() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void Init() {}
		public void RequestVillageInfo() {}
		public virtual void Setup(Village target) {}
		protected virtual void DoAfterChangeChecks() {}
		private void VillageFetchErrorHandler(GraphQLServerError obj) {}
		private void GoToMapLocation() {}
		private void VillageInfoReceived(ServerObject villageObject) {}
		private void AfterXInput() {}
		private void AfterYInput() {}
		private void UpdateRelationToTarget() {}
		[UICallable]
		public void ClickOnMap() {}
		[UICallable]
		public void OpenMyVillagesPopup() {}
		[UICallable]
		public void OpenVillageSelection() {}
		public void CenterOnVillage() {}
		private void OnMapViewLoaded(SceneStatus status) {}
	}
