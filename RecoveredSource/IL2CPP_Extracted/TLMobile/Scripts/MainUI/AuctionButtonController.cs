// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionButtonController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private bool _hasPermissionAndFinishedRequirements;
		private int adventuresLeftForRequirement;
		private BootstrapData bootstrapData;
		private OwnHero hero;
	
		// Properties
		[ObservableValue]
		public bool hasPermissionAndFinishedRequirements { get => default; set {} }
	
		// Constructors
		public AuctionButtonController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CheckButtonState() {}
		[UICallable]
		public void OnAuctionButtonClick() {}
	}
