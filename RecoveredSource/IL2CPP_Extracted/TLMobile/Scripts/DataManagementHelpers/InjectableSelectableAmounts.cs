// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableSelectableAmounts : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
	
		// Constructors
		public InjectableSelectableAmounts() {}
	}
