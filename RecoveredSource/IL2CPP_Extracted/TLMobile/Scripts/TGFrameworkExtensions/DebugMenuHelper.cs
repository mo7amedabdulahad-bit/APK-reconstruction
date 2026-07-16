// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DebugMenuHelper : InjectableViewModel
	{
		// Fields
		[ObservableValue]
		private string _methodName;
		[InjectableValue]
		[ObservableValue]
		private System.Action _debugMethod;
	
		// Properties
		[ObservableValue]
		public string methodName { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public System.Action debugMethod { get => default; set {} }
	
		// Constructors
		public DebugMenuHelper() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		public void Start() {}
		private void UpdateText() {}
		[UICallable]
		public void CallDebugMethod() {}
	}
