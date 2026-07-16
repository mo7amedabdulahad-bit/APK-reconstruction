// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableMovementInfo : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private MovementInfo _movementInfo;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public MovementInfo movementInfo { get => default; set {} }
	
		// Constructors
		public InjectableMovementInfo() {}
	}
