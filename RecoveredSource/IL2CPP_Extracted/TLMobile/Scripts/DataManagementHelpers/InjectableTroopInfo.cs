// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableTroopInfo : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private TroopInfo _troopInfo;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
	
		// Constructors
		public InjectableTroopInfo() {}
	}
