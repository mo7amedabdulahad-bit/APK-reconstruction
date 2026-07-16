// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.ExchangeResources
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ExchangeResourcesController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ResourceAmounts _originalResources;
		[ObservableValue]
		private ResourceAmounts _resourcesWanted;
		[ObservableValue]
		private ResourceAmounts _resourcesInput;
		[ObservableValue]
		private ResourceAmounts _resourcesSlider;
		[ObservableValue]
		private ResourceAmounts _resourcesMax;
		[ObservableValue]
		private ResourceAmounts _resourcesDelta;
		[ObservableValue]
		private ObservableList<bool> _resourceLocked;
		[ObservableValue]
		private int _rest;
		[ObservableValue]
		private int _featurePrice;
		[ObservableValue]
		private string _errorMessage;
		[ObservableValue]
		private Tab _currentTab;
		[ObservableValue]
		private ResourceAmounts _targetResources;
		[ObservableValue]
		private int _buildableAmount;
		[ObservableValue]
		private int _desiredBuildableAmount;
		[ObservableValue]
		private int _initialBuildableAmount;
		[ObservableValue]
		private int _maximumBuildableAmount;
		[ObservableValue]
		private ResourceTypes _prioritizedResourceType;
		[ObservableValue]
		private TroopInfo _troopInfo;
		[ObservableValue]
		private Intention _intention;
		[ObservableValue]
		private bool _anythingChanged;
		[ObservableValue]
		private bool _exchangePossible;
		private OwnPlayer ownPlayer;
	
		// Properties
		[ObservableValue]
		public ResourceAmounts originalResources { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesWanted { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesInput { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesSlider { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesMax { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesDelta { get => default; set {} }
		[ObservableValue]
		public ObservableList<bool> resourceLocked { get => default; set {} }
		[ObservableValue]
		public int rest { get => default; set {} }
		[ObservableValue]
		public int featurePrice { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
		[ObservableValue]
		public Tab currentTab { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts targetResources { get => default; set {} }
		[ObservableValue]
		public int buildableAmount { get => default; set {} }
		[ObservableValue]
		public int desiredBuildableAmount { get => default; set {} }
		[ObservableValue]
		public int initialBuildableAmount { get => default; set {} }
		[ObservableValue]
		public int maximumBuildableAmount { get => default; set {} }
		[ObservableValue]
		public ResourceTypes prioritizedResourceType { get => default; set {} }
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
		[ObservableValue]
		public Intention intention { get => default; set {} }
		[ObservableValue]
		public bool anythingChanged { get => default; set {} }
		[ObservableValue]
		public bool exchangePossible { get => default; set {} }
	
		// Nested types
		public enum Intention
		{
			None = 0,
			Upgrade = 1,
			Merge = 2,
			Research = 3,
			Celebration = 4,
			ReviveHero = 5
		}
	
		public enum Tab
		{
			None = 0,
			Automatic = 1,
			Manual = 2
		}
	
		// Constructors
		public ExchangeResourcesController() {}
	
		// Methods
		private void _resourceLockedNotify(object sender, PropertyChangedEventArgs args) {}
		private void GeneralSetup() {}
		public void Setup(ResourceAmounts targetResources, Intention intention = Intention.Upgrade) {}
		public void Setup(TroopInfo troopInfo, string callingDetailsWindow = "") {}
		private void InputResourcesChanged() {}
		private void DesiredBuildableAmountChanged() {}
		private void UpdateResources() {}
		private void DistributeResourceAmount(int toDistribute, int originatingResourceType = 0) {}
		[UICallable]
		public void Lock(int resourceNumber) {}
		[UICallable]
		public void Distribute() {}
		[UICallable]
		public void ChangePrioritizedResource(ResourceTypes newType) {}
		[UICallable]
		public void SetMaxPossible() {}
		[UICallable]
		public void SwitchTab(Tab newTab) {}
		[UICallable]
		public void Exchange() {}
	}
