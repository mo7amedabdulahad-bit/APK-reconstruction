// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsRecoverPasswordTabController : CamsEmailInputTabController
	{
		// Fields
		private const int PasswordRecoverCooldown = 60;
		[ObservableValue]
		private double _passwordRecoverTimeLeft;
		private double passwordRecoverTime;
	
		// Properties
		[ObservableValue]
		public double passwordRecoverTimeLeft { get => default; set {} }
	
		// Constructors
		public CamsRecoverPasswordTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		private void ProcessCooldown() {}
		private void SetRecoverTime(double value) {}
		[UICallable]
		public void RequestPasswordReset() {}
	}
