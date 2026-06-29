// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.GoldShop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TravianPlusBrowserOnlyChecker : InjectableViewModel
	{
		// Fields
		private static readonly ObservableList<GoldShopAdvantagesController.PlusFeature> browserOnlyFeatures;
		[InjectableValue]
		[ObservableValue]
		private int _plusFeature;
		[ObservableValue]
		private bool _isBrowserOnly;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public int plusFeature { get => default; set {} }
		[ObservableValue]
		public bool isBrowserOnly { get => default; set {} }
	
		// Constructors
		public TravianPlusBrowserOnlyChecker() {}
		static TravianPlusBrowserOnlyChecker() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
	}
