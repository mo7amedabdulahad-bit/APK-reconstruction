// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroReforgePopupController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private HeroForgeProbabilityController heroForgeProbabilityController;
		[ObservableValue]
		private ObservableList<InventoryItemWrapper> _forgedEquipment;
		[ObservableValue]
		private int _reforgePrice;
		private CraftingItems crafting;
		private System.Action callback;
		private Action<Exception> errorHandling;
	
		// Properties
		[ObservableValue]
		public ObservableList<InventoryItemWrapper> forgedEquipment { get => default; set {} }
		[ObservableValue]
		public int reforgePrice { get => default; set {} }
	
		// Constructors
		public HeroReforgePopupController() {}
	
		// Methods
		private void _forgedEquipmentNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		private void UpdateCrafting() {}
		public void FetchReforgePrice(Action<Exception> errorHandling) {}
		public void SetCallback(System.Action callback) {}
		[UICallable]
		public void TakeItem(int itemIndex) {}
		[UICallable]
		public void Reforge(int itemIndex) {}
		[UICallable]
		public void ShowDetails(InventoryItemWrapper item) {}
	}
