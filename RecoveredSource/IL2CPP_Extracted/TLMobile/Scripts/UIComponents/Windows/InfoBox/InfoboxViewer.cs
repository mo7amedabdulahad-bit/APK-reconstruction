// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.InfoBox
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InfoboxViewer : ViewModelWithPolling, IBackendUpdateable
	{
		// Fields
		private const float DarkenRatio = 0.7f;
		[SerializeField]
		private SwipeablePanel infoBoxPanel;
		[SerializeField]
		private LeftMenuController leftMenuController;
		[SerializeField]
		private UnityEngine.UI.Image notificationButtonOverlay;
		[ObservableValue]
		private ObservableList<InfoboxMessageInterface> _infoboxMessage;
		[ObservableValue]
		[PollForUpdates(15f, 0, -1f)]
		private GraphQLFetchableList<InfoboxMessageInterface> _infoboxMessageInterfaces;
		[ObservableValue]
		private GoldActionPrices _prices;
		[ObservableValue]
		private bool _hasUnseenInfoboxMessages;
		private bool oldLockedStatus;
		private AvatarMessageState avatarMessageState;
		private Tween notificationTween;
		private UnityEngine.Color startColor;
		private UnityEngine.Color darkenColor;
		private float notificationLerpRatio;
	
		// Properties
		[ObservableValue]
		public ObservableList<InfoboxMessageInterface> infoboxMessage { get => default; set {} }
		[ObservableValue]
		[PollForUpdates(15f, 0, -1f)]
		public GraphQLFetchableList<InfoboxMessageInterface> infoboxMessageInterfaces { get => default; set {} }
		[ObservableValue]
		public GoldActionPrices prices { get => default; set {} }
		[ObservableValue]
		public bool hasUnseenInfoboxMessages { get => default; set {} }
		[ObservableValue]
		public int ProductionBoostPremiumPercentage { get => default; }
		[ObservableValue]
		public int ProductionBoostVideoPercentage { get => default; }
		protected float NotificationButtonColorLerp { get => default; set {} }
	
		// Constructors
		public InfoboxViewer() {}
	
		// Methods
		private void _infoboxMessageNotify(object sender, PropertyChangedEventArgs args) {}
		private void _infoboxMessageInterfacesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnDestroy() {}
		void IBackendUpdateable.Update(int query = 0) {}
		private void OnLanguageChanged() {}
		private void CheckForBan() {}
		private GraphQLFetchableList<InfoboxMessageInterface> DeprecationInterfaceCorrection(GraphQLFetchableList<InfoboxMessageInterface> newList) => default;
		private void UpdateList(ServerObject newList) {}
		private void UpdateNotificationState() {}
		private void OnInfoboxCollapsedStateChanged(bool isExpanded) {}
		private void OnPanelExpandStateChanged(bool isExpanded) {}
		private void MarkInfoboxAsSeen() {}
		private bool MarkInfoboxMessageAsRead(InfoboxMessageInterface message) => default;
		private bool IsInfoboxMessageRead(InfoboxMessageInterface message) => default;
		[UICallable]
		public void OpenBanMessage() {}
		[UICallable]
		public void RemoveInfoboxMessage(int id) {}
		[UICallable]
		public void ExtendPlus() {}
		[UICallable]
		public void ExtendResourcesProduction(int resourceType) {}
		private void ExtendBonus(BookFeatureRequestBody.FeatureEnum featureToBook) {}
	}
