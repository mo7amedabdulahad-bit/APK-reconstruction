// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InsufficientGoldHandler : InjectableViewModel
	{
		// Fields
		[InjectableValue(acceptsConstant = true, hasToBeSet = true)]
		[ObservableValue]
		private int _goldPrice;
	
		// Properties
		[InjectableValue(acceptsConstant = true, hasToBeSet = true)]
		[ObservableValue]
		public int goldPrice { get => default; set {} }
	
		// Constructors
		public InsufficientGoldHandler() {}
	
		// Methods
		[UICallable]
		public void OpenGoldShop() {}
	}
