// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsSettingsPasswordTab : DetailWindowTabController
	{
		// Fields
		private const int PasswordChangeCooldown = 60;
		[ObservableValue]
		private double _passwordChangeTimeLeft;
		[ObservableValue]
		private bool _requestSent;
		private OwnIdentity ownIdentity;
		private double passwordChangeTime;
	
		// Properties
		[ObservableValue]
		public double passwordChangeTimeLeft { get => default; set {} }
		[ObservableValue]
		public bool requestSent { get => default; set {} }
	
		// Constructors
		public CamsSettingsPasswordTab() {}
	
		// Methods
		protected override void OnEnable() {}
		private void ProcessCooldown() {}
		private void SetChangeTime(double value) {}
		[UICallable]
		public void SendPasswordResetRequest() {}
	}
