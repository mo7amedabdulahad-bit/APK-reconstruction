// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsActivationTabController : CamsDetailWindowTabController
	{
		// Fields
		private const int activationCodeLength = 6;
		public AdvancedInputField activationCodeInputField;
		[ObservableValue]
		private ActivationCodeError _activationCodeError;
		[ObservableValue]
		private SingleInputController _activationCodeInputController;
		[ObservableValue]
		private int _typedActivationCodeLength;
	
		// Properties
		[ObservableValue]
		public ActivationCodeError activationCodeError { get => default; set {} }
		[ObservableValue]
		public SingleInputController activationCodeInputController { get => default; set {} }
		[ObservableValue]
		public int typedActivationCodeLength { get => default; set {} }
	
		// Constructors
		public CamsActivationTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		protected override void OnDestroy() {}
		public override void OnOpen(int tabNumber) {}
		public void SetActivationCode(string activationCode) {}
		[UICallable]
		public void UpdateActivationCodeInput() {}
		[UICallable]
		public bool HasInputError() => default;
		[UICallable]
		public void ActivateAccount() {}
		[UICallable]
		public void SendCodeAgain() {}
		[UICallable]
		private void OnResetErrors() {}
	}
