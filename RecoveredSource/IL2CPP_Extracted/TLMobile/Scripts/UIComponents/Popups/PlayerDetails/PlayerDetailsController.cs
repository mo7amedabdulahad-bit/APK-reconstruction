// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.PlayerDetails
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerDetailsController : DetailWindowController
	{
		// Fields
		public SpriteCfg sortingIcons;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private Tab _currentTab;
		[ObservableValue]
		private int _oasesAmount;
		[ObservableValue]
		private ObservableList<VillageWithOases> _villages;
		[ObservableValue]
		private string _sortingPopupTitle1;
		[ObservableValue]
		private bool _mayWriteMessage;
		[ObservableValue]
		private bool _keepTribeOnConquer;
		[ObservableValue]
		private DetailWindowsShowController _detailWindowsShowController;
		private GraphQLFetchableList<Artefact> bigArtefacts;
		private DropdownOption selectedOption;
		private GraphQLFetchableList<Artefact> smallArtefacts;
		[Testable]
		private ObservableList<DropdownOption> sortDropdownOptions;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public Tab currentTab { get => default; set {} }
		[ObservableValue]
		public int oasesAmount { get => default; set {} }
		[ObservableValue]
		public ObservableList<VillageWithOases> villages { get => default; set {} }
		[ObservableValue]
		public string sortingPopupTitle1 { get => default; set {} }
		[ObservableValue]
		public bool mayWriteMessage { get => default; set {} }
		[ObservableValue]
		public bool keepTribeOnConquer { get => default; set {} }
		[ObservableValue]
		public DetailWindowsShowController detailWindowsShowController { get => default; set {} }
	
		// Nested types
		public enum SortBy
		{
			None = 0,
			PopulationSize = 1,
			VictoryPoints = 2,
			VillageName = 3,
			RegionName = 4
		}
	
		public enum Tab
		{
			Info = 0,
			Villages = 1,
			Description = 2
		}
	
		// Constructors
		public PlayerDetailsController() {}
	
		// Methods
		private void _villagesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Start() {}
		protected override void OnEnable() {}
		public void Setup(int playerId) {}
		[Testable]
		private void UpdatePlayer() {}
		private void SortingChanged() {}
		[UICallable]
		public void SetCurrentTab(Tab newTab) {}
		[UICallable]
		public void InviteToAlliance() {}
		[UICallable]
		public void ToggleBlockPlayer() {}
		[UICallable]
		public void OpenDropdown() {}
		[UICallable]
		public void OpenToolTip(InventoryItemWrapper item) {}
		[UICallable]
		public void OpenFilteredReports() {}
	}
