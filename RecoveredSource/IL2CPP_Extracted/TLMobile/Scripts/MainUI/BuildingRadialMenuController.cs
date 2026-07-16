// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingRadialMenuController : FadedPanelController
	{
		// Fields
		[SerializeField]
		private RectTransform radialMenuTransform;
	
		// Properties
		public Building Target { get; private set; }
		public RectTransform RadialMenuTransform { get => default; }
	
		// Constructors
		public BuildingRadialMenuController() {}
	
		// Methods
		protected override void Awake() {}
		public virtual void Init() {}
		public virtual bool ChangeRadialMenuTransform(RectTransform newRadialMenu) => default;
		[UICallable]
		public virtual void Open(Vector2 position, Building targetBuilding) {}
		[UICallable]
		public virtual void UpgradeBuilding() {}
		[UICallable]
		public virtual void Close() {}
		[UICallable]
		public virtual void ShowDetailWindow() {}
		protected override void OnCompleteClosingAnimation() {}
	}
