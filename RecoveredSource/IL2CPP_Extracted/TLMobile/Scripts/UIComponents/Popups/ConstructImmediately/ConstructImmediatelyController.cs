// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.ConstructImmediately
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConstructImmediatelyController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.BuildingInProgress> _constructionEvents;
		[ObservableValue]
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.BuildingInProgress> _demolitionEvents;
		[ObservableValue]
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.BuildingExtensions> _buildingExtensionEvents;
		[ObservableValue]
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.UpgradeResearchInProgress> _upgradeResearchEvents;
		[ObservableValue]
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.AcademyResearchInProgress> _academyResearchEvents;
		[ObservableValue]
		private Wallet _wallet;
		[ObservableValue]
		private bool _redeemButtonDisabled;
		[ObservableValue]
		private int _goldAmount;
		private Academy academy;
		private System.Action closePopupCallback;
		private string constructImmediatelyOneTimeToken;
		private OwnVillage ownVillage;
		private Smithy smithy;
	
		// Properties
		[ObservableValue]
		public ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.BuildingInProgress> constructionEvents { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.BuildingInProgress> demolitionEvents { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.BuildingExtensions> buildingExtensionEvents { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.UpgradeResearchInProgress> upgradeResearchEvents { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Scripts.UIComponents.Popups.ConstructImmediately.AcademyResearchInProgress> academyResearchEvents { get => default; set {} }
		[ObservableValue]
		public Wallet wallet { get => default; set {} }
		[ObservableValue]
		public bool redeemButtonDisabled { get => default; set {} }
		[ObservableValue]
		public int goldAmount { get => default; set {} }
	
		// Constructors
		public ConstructImmediatelyController() {}
	
		// Methods
		private void _constructionEventsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _demolitionEventsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildingExtensionEventsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _upgradeResearchEventsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _academyResearchEventsNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Init(ConstructImmediatelyResponseBodyData responseBodyData, string oneTimeToken, System.Action closeCallback = null) {}
		protected override void OnDestroy() {}
		private void OnVillageChange(OwnVillage newVill) {}
		private void AddUpgradeResearchEvents(ConstructImmediatelyResponseBodyData response) {}
		private void AddAcademyResearchEvents(ConstructImmediatelyResponseBodyData response) {}
		private void AddBuildingExtensionEvents(ConstructImmediatelyResponseBodyData response) {}
		private void AddDemolitionEvents(ConstructImmediatelyResponseBodyData response) {}
		private void AddConstructionEvents(ConstructImmediatelyResponseBodyData response) {}
		[UICallable]
		public virtual void CompleteImmediately() {}
	}
