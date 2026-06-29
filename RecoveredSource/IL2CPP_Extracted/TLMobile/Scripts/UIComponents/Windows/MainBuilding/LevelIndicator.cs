// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LevelIndicator : InjectableViewModel
	{
		// Fields
		[SerializeField]
		private BuildingDroppable buildingDroppable;
		[ObservableValue]
		private float _alpha;
		private RectTransform buildingRectTransform;
		private int originalIndex;
		private RectTransform rectTransform;
	
		// Properties
		[ObservableValue]
		public float alpha { get => default; set {} }
		public BuildingDroppable BuildingDroppable { get => default; }
	
		// Constructors
		public LevelIndicator() {}
	
		// Methods
		protected override void Awake() {}
		private void Update() {}
		private void OnAlphaChanged(float alpha) {}
		private void UpdatePosition() {}
	}
