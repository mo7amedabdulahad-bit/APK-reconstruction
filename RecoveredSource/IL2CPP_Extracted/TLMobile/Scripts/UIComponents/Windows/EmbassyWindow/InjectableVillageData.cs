// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.EmbassyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableVillageData : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private NearbyVillageTabController.VillageData _villageData;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public NearbyVillageTabController.VillageData villageData { get => default; set {} }
	
		// Constructors
		public InjectableVillageData() {}
	}
