// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Cancel
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CancelPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private string _objectName;
		[ObservableValue]
		private int _objectLevel;
		[ObservableValue]
		private int _refundPercentage;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private CancelType _type;
		private int eventID;
		public IRestApiService restApiService;
		public Dictionary<string, string> translations;
	
		// Properties
		[ObservableValue]
		public string objectName { get => default; set {} }
		[ObservableValue]
		public int objectLevel { get => default; set {} }
		[ObservableValue]
		public int refundPercentage { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public CancelType type { get => default; set {} }
	
		// Constructors
		public CancelPopupController() {}
	
		// Methods
		protected override void Awake() {}
		public void Init(UnitInDevelopment unit, CancelType cancelType) {}
		public void Init(BuildEvent activity, CancelType cancelType) {}
		public ResourceAmounts CalculateUnitRefundedResources(ResourceAmounts amounts, int currentLevel) => default;
		public int CalculatePercentage(float refundCosts, float spentCosts) => default;
		[UICallable]
		public void CancelUpgrade() {}
		public void CancelUpgrade(int id) {}
	}
