// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableLandDistribution : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private LandDistribution _landDistribution;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public LandDistribution landDistribution { get => default; set {} }
	
		// Constructors
		public InjectableLandDistribution() {}
	}
