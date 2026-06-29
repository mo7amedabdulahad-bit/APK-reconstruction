// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendTroopInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Village _targetVillage;
		[ObservableValue]
		private MapCell _targetMapCell;
		[ObservableValue]
		private ObservableList<SelectedAmountWithSendInfo> _waves;
		[ObservableValue]
		private ResourcesCostInfo _resourcesCostInfo;
		[ObservableValue]
		private int _fromMapId;
		[ObservableValue]
		private int _fromVillageId;
		[ObservableValue]
		private int _originVillageId;
		[ObservableValue]
		private WaveEditType _waveEditType;
		[ObservableValue]
		private int _lastEditedWaveIndex;
		[ObservableValue]
		private bool _validCatapultTarget;
		[ObservableValue]
		private AttackType _attackType;
		[ObservableValue]
		private string _targetMapCellTypeName;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private Vector2Int _destinationCoordinates;
	
		// Properties
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
		[ObservableValue]
		public MapCell targetMapCell { get => default; set {} }
		[ObservableValue]
		public ObservableList<SelectedAmountWithSendInfo> waves { get => default; set {} }
		[ObservableValue]
		public ResourcesCostInfo resourcesCostInfo { get => default; set {} }
		[ObservableValue]
		public int fromMapId { get => default; set {} }
		[ObservableValue]
		public int fromVillageId { get => default; set {} }
		[ObservableValue]
		public int originVillageId { get => default; set {} }
		[ObservableValue]
		public WaveEditType waveEditType { get => default; set {} }
		[ObservableValue]
		public int lastEditedWaveIndex { get => default; set {} }
		[ObservableValue]
		public bool validCatapultTarget { get => default; set {} }
		[ObservableValue]
		public AttackType attackType { get => default; set {} }
		[ObservableValue]
		public string targetMapCellTypeName { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public Vector2Int destinationCoordinates { get => default; set {} }
	
		// Nested types
		public enum WaveEditType
		{
			None = 0,
			Add = 1,
			Edit = 2
		}
	
		// Constructors
		[Obsolete("Only for data binding purposes!")]
		public SendTroopInfo() {}
		public SendTroopInfo(AttackType attackType, int originVillageId, int fromMapId, int fromVillageId = 0) {}
	
		// Methods
		public void UpdateDistance() {}
		public SendTroopInfo SetAttackType(AttackType attackType) => default;
		public SendTroopInfo SetOriginVillageId(int originVillageId) => default;
		public SendTroopInfo SetMapFromId(int mapFromId) => default;
		public SendTroopInfo SetVillageFromId(int villageFromId) => default;
		public SendTroopInfo SetTargetVillage(Village targetVillage) => default;
		public SendTroopInfo SetTargetMapCell(MapCell targetMapCell) => default;
		public SendTroopInfo SetResourceAmounts(ResourcesAmount resourceAmounts) => default;
		public void InitializeWaves(SelectableAmounts selectableAmounts) {}
		public SelectedAmountWithSendInfo GetCurrentWaveObject() => default;
		private void UpdatePossibleCatapultTarget() {}
		private void _wavesNotify(object sender, PropertyChangedEventArgs args) {}
	}
