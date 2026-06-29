// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DemolishBuildingPopupController : ArrangementPopupController
	{
		// Fields
		private const string GapLength = "_GapLength";
		private static readonly int Length;
		[SerializeField]
		private UnityEngine.UI.Image demolishBuildingLevelOnlyBackgroundImage;
		[SerializeField]
		private UnityEngine.UI.Image demolishBuildingLevelCompletelyBackgroundImage;
		[SerializeField]
		private float animationDuration;
		[SerializeField]
		private Transform demolishingBuildingTransform;
		[SerializeField]
		private float defaultIconScale;
		[SerializeField]
		private float scaledIconScale;
		[SerializeField]
		private BuildingDroppableForDemolishLevelOnly buildingDroppableForDemolishLevelOnly;
		[SerializeField]
		private BuildingDroppableForDemolishLevelCompletely buildingDroppableForDemolishLevelCompletely;
		[ObservableValue]
		private BuildEvent _buildEvent;
		[ObservableValue]
		private float _demolishLevelCompletelyIconScale;
		[ObservableValue]
		private float _demolishLevelOnlyIconScale;
		[ObservableValue]
		private int _demolishTime;
		[ObservableValue]
		private float _selectedBuildingTransition;
		[ObservableValue]
		private bool _showWallBottomLevelIndicator;
		[ObservableValue]
		private bool _showWallTopLevelIndicator;
		[ObservableValue]
		private BuildingInfo _buildingToDemolish;
		private float defaultGapSize;
		private Material demolishBuildingLevelCompletelyBackgroundImageMaterial;
		private Tween demolishBuildingLevelCompletelyTween;
		private Material demolishBuildingLevelOnlyBackgroundImageMaterial;
		private Tween demolishBuildingLevelOnlyTween;
		public Action<BuildEvent> NotifyOnBuildEventChanged;
		private System.Action refreshBuildingArrangementTabController;
	
		// Properties
		[ObservableValue]
		public BuildEvent buildEvent { get => default; set {} }
		[ObservableValue]
		public float demolishLevelCompletelyIconScale { get => default; set {} }
		[ObservableValue]
		public float demolishLevelOnlyIconScale { get => default; set {} }
		[ObservableValue]
		public int demolishTime { get => default; set {} }
		[ObservableValue]
		public float selectedBuildingTransition { get => default; set {} }
		[ObservableValue]
		public bool showWallBottomLevelIndicator { get => default; set {} }
		[ObservableValue]
		public bool showWallTopLevelIndicator { get => default; set {} }
		[ObservableValue]
		public BuildingInfo buildingToDemolish { get => default; set {} }
	
		// Constructors
		public DemolishBuildingPopupController() {}
		static DemolishBuildingPopupController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Setup(Building building, System.Action refreshBuildingArrangementTabController) {}
		protected override void OnBuildingsInVillageChanged() {}
		private void OnBuildEventChanged() {}
		public void SetPlaceId(int placeId) {}
		public void SetIsDroppable(bool levelOnly, bool isDroppable) {}
		protected override bool CheckBuildingIsDraggable(BuildingInfo buildingInfo) => default;
		protected override void DoOnNotDraggable() {}
		[UICallable]
		public override void SetSelectedBuilding(BuildingInfo buildingInfo, Vector3? position = default) {}
		[UICallable]
		public void DemolishLevel() {}
		public void DemolishLevel(BuildingInfo buildingInfo) {}
		private void DoDemolishLevel() {}
		[UICallable]
		public void DemolishCompletely() {}
		public void DemolishCompletely(BuildingInfo buildingInfo) {}
		private void DoDemolishCompletely(BuildingInfo buildingToDemolish) {}
		private static void ShowException(Exception exception) {}
		public override bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
	}
