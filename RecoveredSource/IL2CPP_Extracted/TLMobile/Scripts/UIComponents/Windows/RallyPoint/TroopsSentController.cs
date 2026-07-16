// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsSentController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private SendPayoffAnimationController payoffAnimator;
		[ObservableValue]
		private SendTroopInfo _sendTroopInfo;
		private SendTroopsMainController sendTroopsMainController;
	
		// Properties
		[ObservableValue]
		public SendTroopInfo sendTroopInfo { get => default; set {} }
	
		// Constructors
		public TroopsSentController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public virtual void Setup(SendTroopInfo sendTroopInfo, SendTroopsMainController sendTroopsMainController) {}
		[UICallable]
		public virtual void OpenTroopsOverview() {}
		[UICallable]
		public virtual void BackToVillage() {}
		[UICallable]
		public override void Hide() {}
		private void OnMapViewLoaded(SceneStatus status) {}
	}
