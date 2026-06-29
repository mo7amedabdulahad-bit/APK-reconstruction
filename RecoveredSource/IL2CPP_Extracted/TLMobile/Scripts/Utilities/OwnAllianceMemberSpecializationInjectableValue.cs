// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceMemberSpecializationInjectableValue : InjectableViewModel
	{
		// Fields
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private OwnAllianceMemberSpecialization _value;
		[ObservableValue]
		private string _localeValue;
		[ObservableValue]
		private int _spriteValue;
	
		// Properties
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public OwnAllianceMemberSpecialization value { get => default; set {} }
		[ObservableValue]
		public string localeValue { get => default; set {} }
		[ObservableValue]
		public int spriteValue { get => default; set {} }
	
		// Constructors
		public OwnAllianceMemberSpecializationInjectableValue() {}
	
		// Methods
		protected override void Awake() {}
		private void OnValueChanged() {}
	}
