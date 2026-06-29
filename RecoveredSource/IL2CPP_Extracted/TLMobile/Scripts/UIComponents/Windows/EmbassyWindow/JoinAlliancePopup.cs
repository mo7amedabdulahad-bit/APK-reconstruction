// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.EmbassyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class JoinAlliancePopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private AllianceInvitation _invitation;
		[ObservableValue]
		private int _cooldownPeriod;
	
		// Properties
		[ObservableValue]
		public AllianceInvitation invitation { get => default; set {} }
		[ObservableValue]
		public int cooldownPeriod { get => default; set {} }
	
		// Constructors
		public JoinAlliancePopup() {}
	
		// Methods
		public void Setup(AllianceInvitation allianceInvitation) {}
		[UICallable]
		public void AcceptInvite(AllianceInvitation allianceInvitation) {}
		[UICallable]
		public void DeclineInvite(AllianceInvitation allianceInvitation) {}
	}
