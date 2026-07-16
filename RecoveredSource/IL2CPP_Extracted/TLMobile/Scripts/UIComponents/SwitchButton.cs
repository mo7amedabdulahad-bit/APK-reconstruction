// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SwitchButton : ToggledButton
	{
		// Fields
		[ObservableValue]
		[SerializeField]
		private bool _isSwitchedOn;
		[SerializeField]
		private OnSwitchedEvent m_OnValueChanged;
	
		// Properties
		[ObservableValue]
		public bool isSwitchedOn { get => default; set {} }
		public OnSwitchedEvent OnSwitched { get => default; set {} }
	
		// Nested types
		[Serializable]
		public class OnSwitchedEvent : UnityEvent<bool>
		{
			// Constructors
			public OnSwitchedEvent() {}
		}
	
		// Constructors
		public SwitchButton() {}
	
		// Methods
		[UICallable]
		public void Toggle() {}
	}
