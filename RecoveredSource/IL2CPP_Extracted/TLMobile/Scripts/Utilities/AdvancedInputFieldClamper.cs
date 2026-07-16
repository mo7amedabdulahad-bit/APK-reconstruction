// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AdvancedInputFieldClamper : InjectableViewModel
	{
		// Fields
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private int _minValue;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private int _maxValue;
		[InjectableValue]
		[ObservableValue]
		private string _input;
		[ObservableValue]
		private string _output;
		private AdvancedInputField advancedInputField;
	
		// Properties
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public int minValue { get => default; set {} }
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public int maxValue { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public string input { get => default; set {} }
		[ObservableValue]
		public string output { get => default; set {} }
		public AdvancedInputField.EndEditEventWithoutReason OnEndEditWithoutReason { get; }
		public AdvancedInputField.ValueChangedEvent OnEndEdit { get; }
	
		// Constructors
		public AdvancedInputFieldClamper() {}
	
		// Methods
		public void OnEnable() {}
		protected void OnDisable() {}
		private void ClampInput() {}
		private void EndEdit(string input, EndEditReason reason) {}
		private void ClampInput(string arg0) {}
	}
