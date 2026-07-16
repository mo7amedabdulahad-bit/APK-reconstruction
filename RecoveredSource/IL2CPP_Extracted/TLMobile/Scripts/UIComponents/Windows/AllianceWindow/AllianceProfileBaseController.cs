// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceProfileBaseController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private SubTab _currentTab;
		[ObservableValue]
		private bool _showDetails;
		protected OwnPlayer ownPlayer;
	
		// Properties
		[ObservableValue]
		public SubTab currentTab { get => default; set {} }
		[ObservableValue]
		public bool showDetails { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			Profile = 0,
			Description = 1,
			Members = 2,
			Regional = 3
		}
	
		// Constructors
		public AllianceProfileBaseController() {}
	
		// Methods
		protected override void Awake() {}
		public virtual void Init() {}
		public override void OnOpen(int tabNumber) {}
		[UICallable]
		public void ToggleDetails() {}
		[UICallable]
		public void SetSubTab(SubTab subTab) {}
		[UICallable]
		public bool FilterAllianceMemberByPosition(AllianceMember member) => default;
		[UICallable]
		public bool FilterOwnAllianceMemberByPosition(OwnAllianceMember member) => default;
	}
