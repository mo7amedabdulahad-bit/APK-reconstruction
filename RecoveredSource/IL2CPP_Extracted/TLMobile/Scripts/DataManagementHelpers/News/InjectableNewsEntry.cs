// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.News
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableNewsEntry : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private NewsEntry _newsEntry;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public NewsEntry newsEntry { get => default; set {} }
	
		// Constructors
		public InjectableNewsEntry() {}
	}
