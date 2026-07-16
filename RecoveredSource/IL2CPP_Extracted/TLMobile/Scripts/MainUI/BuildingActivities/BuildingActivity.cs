// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.BuildingActivities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingActivity : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Building _building;
		[ObservableValue]
		private int _busyUntil;
		[ObservableValue]
		private int _actionsOngoing;
		[ObservableValue]
		private int _maxActionsPossible;
		[ObservableValue]
		private bool _canInstantComplete;
		[ObservableValue]
		private bool _unsupportedWIP;
		[ObservableValue]
		private bool _showAdditionalText;
		[ObservableValue]
		private int _additionalAmount;
		[ObservableValue]
		private bool _showSpecialStatus;
		[ObservableValue]
		private string _specialStatusText;
	
		// Properties
		[ObservableValue]
		public Building building { get => default; set {} }
		[ObservableValue]
		public int busyUntil { get => default; set {} }
		[ObservableValue]
		public int actionsOngoing { get => default; set {} }
		[ObservableValue]
		public int maxActionsPossible { get => default; set {} }
		[ObservableValue]
		public bool canInstantComplete { get => default; set {} }
		[ObservableValue]
		public bool unsupportedWIP { get => default; set {} }
		[ObservableValue]
		public bool showAdditionalText { get => default; set {} }
		[ObservableValue]
		public int additionalAmount { get => default; set {} }
		[ObservableValue]
		public bool showSpecialStatus { get => default; set {} }
		[ObservableValue]
		public string specialStatusText { get => default; set {} }
	
		// Constructors
		public BuildingActivity() {}
	}
