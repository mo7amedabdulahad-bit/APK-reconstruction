// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

public class MapMarkersPopupController : DetailWindowController
{
	// Fields
	[SerializeField]
	private ColorCfg mapMarkerColorCfg;
	[ObservableValue]
	private MapCellMarkerMode _currentMarkerMode;
	[ObservableValue]
	private MarkerType _selectedMarkerType;
	[ObservableValue]
	private int? _xCoordinate;
	[ObservableValue]
	private int? _yCoordinate;
	[ObservableValue]
	private MapCell _selectedMapCell;
	[ObservableValue]
	private ObservableList<int> _markerColors;
	[ObservableValue]
	private int _selectedColorKey;
	[ObservableValue]
	private ObservableList<int> _flagKeys;
	[ObservableValue]
	private int _selectedFlagKey;
	[ObservableValue]
	private bool _setForAlliance;
	[ObservableValue]
	private string _fieldMarkerText;
	[ObservableValue]
	private int _fieldMarkerTextCharacterCount;
	[ObservableValue]
	private int _fieldMarkerTextMaxCharacterCount;
	[ObservableValue]
	private bool _hasInputTextError;
	[ObservableValue]
	private bool _hasReachedFlagLimit;
	[ObservableValue]
	private int _flagPlacementLimit;
	private MapFlag editedMapFlag;
	private MapMarker editedMapMarker;
	private bool blockMapCellInfoFetching;
	private bool refreshMarkersOnClosed;

	// Properties
	[ObservableValue]
	public MapCellMarkerMode currentMarkerMode { get => default; set {} }
	[ObservableValue]
	public MarkerType selectedMarkerType { get => default; set {} }
	[ObservableValue]
	public int? xCoordinate { get => default; set {} }
	[ObservableValue]
	public int? yCoordinate { get => default; set {} }
	[ObservableValue]
	public MapCell selectedMapCell { get => default; set {} }
	[ObservableValue]
	public ObservableList<int> markerColors { get => default; set {} }
	[ObservableValue]
	public int selectedColorKey { get => default; set {} }
	[ObservableValue]
	public ObservableList<int> flagKeys { get => default; set {} }
	[ObservableValue]
	public int selectedFlagKey { get => default; set {} }
	[ObservableValue]
	public bool setForAlliance { get => default; set {} }
	[ObservableValue]
	public string fieldMarkerText { get => default; set {} }
	[ObservableValue]
	public int fieldMarkerTextCharacterCount { get => default; set {} }
	[ObservableValue]
	public int fieldMarkerTextMaxCharacterCount { get => default; set {} }
	[ObservableValue]
	public bool hasInputTextError { get => default; set {} }
	[ObservableValue]
	public bool hasReachedFlagLimit { get => default; set {} }
	[ObservableValue]
	public int flagPlacementLimit { get => default; set {} }

	// Nested types
	public enum MapCellMarkerMode
	{
		NoCellSelected = 0,
		FieldOrUnoccupiedOasis = 1,
		VillageOrOccupiedOasis = 2
	}

	public enum MarkerType
	{
		Alliance = 0,
		Player = 1,
		Field = 2
	}

	// Constructors
	public MapMarkersPopupController() {}

	// Methods
	private void _markerColorsNotify(object sender, PropertyChangedEventArgs args) {}
	private void _flagKeysNotify(object sender, PropertyChangedEventArgs args) {}
	protected override void Awake() {}
	protected override void OnEnable() {}
	public void Setup(MapCell mapCell) {}
	private void RefreshFlagPlacementLimit() {}
	private void AfterXInput() {}
	private void AfterYInput() {}
	private void GetMapCellInfo(int x, int y) {}
	private void RefreshMarkerModes() {}
	private void CenterMapOnCoordinates() {}
	[UICallable]
	public void OpenMapCellInfoWindow() {}
	[UICallable]
	public void ToggleSetForAlliance() {}
	private void RefreshFlagKeys() {}
	[UICallable]
	public void SelectMarkerType(MarkerType markerType) {}
	[UICallable]
	public void OnColorSelected(int colorKey) {}
	[UICallable]
	public void OnFlagSelected(int flagKey) {}
	[UICallable]
	public void OpenVillageSelection() {}
	[UICallable]
	public void Save() {}
	public override void Hide() {}
}
