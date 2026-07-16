// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableResourceAmounts : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
	
		// Constructors
		public InjectableResourceAmounts() {}
	}
