// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableTroopAmounts : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private TroopAmounts _troopAmounts;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public TroopAmounts troopAmounts { get => default; set {} }
	
		// Constructors
		public InjectableTroopAmounts() {}
	}
