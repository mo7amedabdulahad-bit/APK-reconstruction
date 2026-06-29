// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableMedalData : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private MedalsPicker.MedalData _medalData;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public MedalsPicker.MedalData medalData { get => default; set {} }
	
		// Constructors
		public InjectableMedalData() {}
	}
