// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ArrangementPopupController : DetailWindowController, IDragAndDropContextController
	{
		// Fields
		private static readonly int EllipseCenter;
		private static readonly int EllipseSize;
		[SerializeField]
		private UnityEngine.UI.Image image;
		[SerializeField]
		private Material maskMaterial;
		[SerializeField]
		private Vector2 maskStartSize;
		[SerializeField]
		private Vector2 maskTargetSizeVillage;
		[SerializeField]
		private Vector2 maskTargetSizeCity;
		[SerializeField]
		private Vector2 maskTargetSizeShore;
		[SerializeField]
		private Vector2 maskTargetSizeShoreCity;
		[SerializeField]
		private Vector2 maskCenterVillage;
		[SerializeField]
		private Vector2 maskCenterCity;
		[SerializeField]
		private Vector2 maskCenterShore;
		[SerializeField]
		private Vector2 maskCenterShoreCity;
		[SerializeField]
		private float maskScaleDuration;
		[SerializeField]
		private List<BuildingSlot> slotIdToPositionList;
		[SerializeField]
		protected List<BuildingDroppable> buildingDroppables;
		[SerializeField]
		private BuildingDroppable buildingDroppableWallTop;
		[SerializeField]
		private BuildingDroppable buildingDroppableWallButtom;
		[SerializeField]
		private List<LevelIndicator> levelIndicators;
		[ObservableValue]
		private ObservableDictionary<int, BuildingInfo> _allSlots;
		[ObservableValue]
		private bool _hasRearranged;
		[ObservableValue]
		private bool _isRearranging;
		[ObservableValue]
		private OwnVillage _ownVillage;
		[ObservableValue]
		private Vector3 _selectableBuildingPosition;
		[ObservableValue]
		private Building _selectedBuilding;
		[ObservableValue]
		private BuildingInfo _selectedBuildingInfo;
		[ObservableValue]
		private BuildingInfo _wall;
		[Testable]
		private ObservableList<BuildingInfo> allConstructedBuildings;
		private ObservableDictionary<int, BuildingInfo> allSlotsOriginal;
		private Material material;
		private Tween tween;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<int, BuildingInfo> allSlots { get => default; set {} }
		[ObservableValue]
		public bool hasRearranged { get => default; set {} }
		[ObservableValue]
		public bool isRearranging { get => default; set {} }
		[ObservableValue]
		public OwnVillage ownVillage { get => default; set {} }
		[ObservableValue]
		public Vector3 selectableBuildingPosition { get => default; set {} }
		[ObservableValue]
		public Building selectedBuilding { get => default; set {} }
		[ObservableValue]
		public BuildingInfo selectedBuildingInfo { get => default; set {} }
		[ObservableValue]
		public BuildingInfo wall { get => default; set {} }
		private Dictionary<int, Vector3> SlotIdToPosition { get; set; }
		private Dictionary<int, int> SlotIdToOrderInLayer { get; set; }
	
		// Events
		public event Action<bool> OnIsRearrangingChanged;
		public event Action<BuildingInfo> OnSelectedBuildingInfoChanged;
	
		// Constructors
		public ArrangementPopupController() {}
		static ArrangementPopupController() {}
	
		// Methods
		private void _allSlotsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		private void Update() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void ObserveOnOwnVillage(OwnVillage currentVillage) {}
		private void Init() {}
		private void InitializeSlotIdMapping(List<BuildingSlot> slotIdToPositionInGameObjectTransform) {}
		protected void TriggerEllipseAnimation(bool scaleIn, bool ignoreCurrentValue = false) {}
		public virtual void SetIsRearranging(bool isRearranging) {}
		[UICallable]
		public virtual void SetSelectedBuilding(BuildingInfo buildingInfo, Vector3? position = default) {}
		protected virtual void OnBuildingsInVillageChanged() {}
		private void UpdateBuildingsUpgradeState() {}
		[UICallable]
		public virtual void CheckBuildingIsDraggableAndSelect(BuildingInfo buildingInfo) {}
		protected virtual void DoOnNotDraggable() {}
		protected virtual bool CheckBuildingIsDraggable(BuildingInfo buildingInfo) => default;
		protected void DoOnHide() {}
		private void UpdateSiblingIndexes() {}
		protected virtual void UpdateSiblingIndexOfSelectedBuildingDroppable(List<BuildingDroppable> allBuildingDroppables, int sortedBuildingDroppablesCount, int sortedLevelIndicatorsCount) {}
		protected virtual void UpdateSiblingIndexOfSelectedBuildingDroppableLevelIndicators(List<LevelIndicator> levelIndicators, int sortedBuildingDroppablesCount, int sortedLevelIndicatorsCount) {}
		protected virtual void SortOutBuildingDroppables(List<BuildingDroppable> sortedBuildingDroppables) {}
		protected virtual void SortOutLevelIndicators(List<LevelIndicator> sortedLevelIndicators) {}
		public virtual bool IsDraggable(IDraggableObject draggable) => default;
		public virtual bool IsDroppable(IDraggableObject draggable, IDroppableObject target) => default;
		public virtual void OnStartDragging(IDraggableObject draggable) {}
		public virtual void OnStopDragging(IDraggableObject draggable) {}
		public virtual void OnDropped(IDraggableObject draggable, IDroppableObject target) {}
		public virtual bool HasOnDroppedErrors(IDraggableObject draggable, IDroppableObject target) => default;
	}
