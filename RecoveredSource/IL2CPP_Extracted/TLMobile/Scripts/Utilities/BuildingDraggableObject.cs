// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingDraggableObject : DraggableObject<BuildingInfo>
	{
		// Fields
		private const string OutlineThickness = "_OutlineThickness";
		private const string OutlineColor = "_OutlineColor";
		private static readonly int OutlineColor1;
		private static readonly int Thickness;
		[SerializeField]
		private UnityEngine.UI.Image[] images;
		[SerializeField]
		private Material outlineMaterial;
		[SerializeField]
		private float outlineScaleDuration;
		[SerializeField]
		private float outlineThickness;
		[SerializeField]
		private UnityEngine.Color outlineColor;
		private ArrangementPopupController arrangementPopupController;
		private Material material;
		private int originalSiblingIndex;
		private Tween tween;
	
		// Constructors
		public BuildingDraggableObject() {}
		static BuildingDraggableObject() {}
	
		// Methods
		protected override void Awake() {}
		private void OnEnable() {}
		private void OnDisable() {}
		public virtual void Setup(ArrangementPopupController arrangementPopupController) {}
		protected override void OnDestroy() {}
		private void OnSelectedBuildingInfoChanged(BuildingInfo buildin) {}
		private void UpdateSelectionAnimation() {}
		protected override void StartDragging(PointerEventData eventData) {}
		private void SelectBuilding(BuildingInfo buildingInfo, RectTransform rectTransform = null, bool ignoreCurrentValue = false) {}
		private void StartOutlineScaleAnimation(bool scaleUp, bool ignoreCurrentValue = false) {}
		protected override void SetCurrentlyDragging(bool currentlyDragging) {}
		public override void ResetDraggedObject() {}
		protected override void OnDragImpossible() {}
		public override void CleanupAfterDrop() {}
		protected override void GetTempoaryDragParent(UnityEngine.Canvas canvas) {}
		protected override void UpdateDraggable() {}
	}
