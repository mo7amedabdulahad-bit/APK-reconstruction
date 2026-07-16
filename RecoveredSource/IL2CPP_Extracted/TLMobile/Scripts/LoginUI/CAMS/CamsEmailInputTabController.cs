// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsEmailInputTabController : CamsDetailWindowTabController
	{
		// Fields
		public AdvancedInputField emailInputField;
		[ObservableValue]
		protected EmailError _emailError;
		[ObservableValue]
		protected SingleInputController _emailInputController;
	
		// Properties
		[ObservableValue]
		public EmailError emailError { get => default; set {} }
		[ObservableValue]
		public SingleInputController emailInputController { get => default; set {} }
	
		// Constructors
		public CamsEmailInputTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnDestroy() {}
		protected void OnApplicationQuit() {}
		[UICallable]
		public void UpdateEmailInput() {}
		public override void OnOpen(int tabNumber) {}
		protected virtual void UpdateLoginState() {}
		[UICallable]
		public virtual bool HasInputError() => default;
		[UICallable]
		private void OnResetErrors() {}
	}
