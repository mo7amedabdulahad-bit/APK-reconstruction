// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapMarkersOverviewPopupController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private ColorCfg mapMarkerColorCfg;
		[SerializeField]
		private RectTransform editingPanel;
		[ObservableValue]
		private int _selectedSubTab;
		[ObservableValue]
		private ObservableList<MapMarker> _playerMarkerPlayers;
		[ObservableValue]
		private ObservableList<MapMarker> _playerMarkerAlliances;
		[ObservableValue]
		private ObservableList<MapFlag> _playerFlags;
		[ObservableValue]
		private ObservableList<MapMarker> _allianceMarkerPlayers;
		[ObservableValue]
		private ObservableList<MapMarker> _allianceMarkerAlliances;
		[ObservableValue]
		private ObservableList<MapFlag> _allianceFlags;
		[ObservableValue]
		private ObservableDictionary<MapMarkerListType, bool> _isListExpanded;
		[ObservableValue]
		private ObservableDictionary<MapMarkerListType, int> _listCounts;
		[ObservableValue]
		private bool _hasEditPermission;
		[ObservableValue]
		private MapMarker _editingMarker;
		[ObservableValue]
		private MapFlag _editingFlag;
		[ObservableValue]
		private bool _isEditingFlagText;
		[ObservableValue]
		private string _editingFlagText;
		[ObservableValue]
		private ObservableList<int> _markerColors;
		[ObservableValue]
		private ObservableList<int> _playerFlagKeys;
		[ObservableValue]
		private ObservableList<int> _allianceFlagKeys;
		[ObservableValue]
		private MapController.MapSettings _mapSettings;
		private MapController.MapSettings startingSettings;
		private bool triggerMapRefreshOnClose;
		private bool isOpeningMapCellWindow;
		private bool isInitialized;
	
		// Properties
		[ObservableValue]
		public int selectedSubTab { get => default; set {} }
		[ObservableValue]
		public ObservableList<MapMarker> playerMarkerPlayers { get => default; set {} }
		[ObservableValue]
		public ObservableList<MapMarker> playerMarkerAlliances { get => default; set {} }
		[ObservableValue]
		public ObservableList<MapFlag> playerFlags { get => default; set {} }
		[ObservableValue]
		public ObservableList<MapMarker> allianceMarkerPlayers { get => default; set {} }
		[ObservableValue]
		public ObservableList<MapMarker> allianceMarkerAlliances { get => default; set {} }
		[ObservableValue]
		public ObservableList<MapFlag> allianceFlags { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<MapMarkerListType, bool> isListExpanded { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<MapMarkerListType, int> listCounts { get => default; set {} }
		[ObservableValue]
		public bool hasEditPermission { get => default; set {} }
		[ObservableValue]
		public MapMarker editingMarker { get => default; set {} }
		[ObservableValue]
		public MapFlag editingFlag { get => default; set {} }
		[ObservableValue]
		public bool isEditingFlagText { get => default; set {} }
		[ObservableValue]
		public string editingFlagText { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> markerColors { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> playerFlagKeys { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> allianceFlagKeys { get => default; set {} }
		[ObservableValue]
		public MapController.MapSettings mapSettings { get => default; set {} }
	
		// Nested types
		public enum MapMarkerListType
		{
			PlayerMarkerAlliances = 0,
			PlayerMarkerPlayers = 1,
			PlayerFlags = 2,
			AllianceMarkerAlliance = 3,
			AllianceMarkerPlayers = 4,
			AllianceFlags = 5
		}
	
		// Constructors
		public MapMarkersOverviewPopupController() {}
	
		// Methods
		private void _playerMarkerPlayersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _playerMarkerAlliancesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _playerFlagsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allianceMarkerPlayersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allianceMarkerAlliancesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allianceFlagsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _isListExpandedNotify(object sender, PropertyChangedEventArgs args) {}
		private void _listCountsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _markerColorsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _playerFlagKeysNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allianceFlagKeysNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		private void Initialize() {}
		public void RefreshData() {}
		[UICallable]
		public void ToggleShowAllianceMarks() {}
		[UICallable]
		public void ToggleShowPlayerMarks() {}
		private void SaveMapSettings() {}
		[UICallable]
		public void SetSubTab(int subTabIndex) {}
		[UICallable]
		public void SetMarkerColor(MapMarker marker, int colorKey) {}
		[UICallable]
		public void SetFlagColor(MapFlag flag, int colorKey) {}
		[UICallable]
		public void DeleteMarker(MapMarker marker) {}
		private void DeleteMarkerConfirmed(MapMarker marker, MapFlag flag) {}
		[UICallable]
		public void OpenFlagCellLocation(MapFlag flag) {}
		[UICallable]
		public void DeleteFlag(MapFlag flag) {}
		[UICallable]
		public void DismissEditMode() {}
		[UICallable]
		public void OpenEditForMarker(MapMarker marker, RectTransform holder) {}
		[UICallable]
		public void OpenEditForFlag(MapFlag flag, bool isEditText, RectTransform holder) {}
		[UICallable]
		public void SaveFlagText(MapFlag flag) {}
		[UICallable]
		public void SelectList(int listTypeInt) {}
		public override void Hide() {}
	}
