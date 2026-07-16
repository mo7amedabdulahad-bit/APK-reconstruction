// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map.UI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapPositionController : DetailWindowController
	{
		// Fields
		public float maxDistanceBeforeCenterMapDisables;
		[SerializeField]
		private RTLAdvancedInputField selectedXInput;
		[SerializeField]
		private RTLAdvancedInputField selectedYInput;
		[ObservableValue]
		private bool _hasError;
		[ObservableValue]
		private int? _mapId;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private string _searchInput;
		[ObservableValue]
		private SearchType _searchType;
		[ObservableValue]
		private int _selectedX;
		[ObservableValue]
		private int _selectedY;
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private ObservableList<NotOwnVillageWithDistance> _villages;
		private bool selectLocation;
	
		// Properties
		[ObservableValue]
		public bool hasError { get => default; set {} }
		[ObservableValue]
		public int? mapId { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public string searchInput { get => default; set {} }
		[ObservableValue]
		public SearchType searchType { get => default; set {} }
		[ObservableValue]
		public int selectedX { get => default; set {} }
		[ObservableValue]
		public int selectedY { get => default; set {} }
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public ObservableList<NotOwnVillageWithDistance> villages { get => default; set {} }
	
		// Nested types
		public enum SearchType
		{
			Location = 0,
			Player = 1
		}
	
		// Constructors
		public MapPositionController() {}
	
		// Methods
		private void _villagesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		private void Start() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override void OnDestroy() {}
		private void CheckMaxTranslation() {}
		public void Init() {}
		[Testable]
		private void DoBackendSearchGetPlayerVillages(int playerId) {}
		private void SyncVillages(List<NotOwnVillageWithDistance> resultByDistance) {}
		private void SelectMapId() {}
		[UICallable]
		public void GoToCell(int x, int y) {}
		public void GoToCell() {}
		private void SetSelectedCellObservableValues(int x, int y) {}
		[UICallable]
		public void SetSearchType(SearchType searchType) {}
		[UICallable]
		public void OpenVillageSelection() {}
		[UICallable]
		public void OpenPlayerSelection() {}
		[UICallable]
		public void SelectVillage(Village village) {}
		[UICallable]
		public void HideThis() {}
		[UICallable]
		public void ClearSearchResults() {}
	}
