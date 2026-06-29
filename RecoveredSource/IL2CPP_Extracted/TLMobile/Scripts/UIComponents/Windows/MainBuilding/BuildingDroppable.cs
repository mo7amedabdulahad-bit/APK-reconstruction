// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MainBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingDroppable : BaseDroppable<BuildingInfo>
	{
		// Fields
		protected const float NotDroppableAlpha = 0.5f;
		[ObservableValue]
		private float _alpha;
		[ObservableValue]
		private bool _buildingIsDroppable;
		[InjectableValue]
		[ObservableValue]
		private BuildingInfo _item;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private int _placeId;
		private bool isRearranging;
		public Action<float> NotifyOnAlphaChanged;
		private BuildingInfo oldItem;
		private BuildingInfo selectedBuilding;
		protected Action<bool> SetIsRearranging;
		protected BuildingDraggableObject buildingDraggableObject;
	
		// Properties
		[ObservableValue]
		public float alpha { get => default; set {} }
		[ObservableValue]
		public bool buildingIsDroppable { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public BuildingInfo item { get => default; set {} }
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public int placeId { get => default; set {} }
	
		// Constructors
		public BuildingDroppable() {}
	
		// Methods
		public virtual void Setup(ArrangementPopupController arrangementPopupController) {}
		public override void OnInjectedValueChanged() {}
		private void OnItemUpdate() {}
		private void OnIsRearrangingChanged(bool isRearranging) {}
		private void OnSelectedBuildingInfoChanged(BuildingInfo selectedBuilding) {}
		protected virtual void UpdateAlpha() {}
		protected void SetAlpha(float alpha) {}
		private void UpdateBuildingAlphaToIsDraggable() {}
	}
