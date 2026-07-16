// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsFilterPopup : MultiSelectableListController<int>
	{
		// Fields
		[ObservableValue]
		private ObservableList<DropdownOption> _rarityOptions;
		[ObservableValue]
		private bool _useMultipleFilters;
		public SpriteCfg sprites;
		public SpriteCfg raritySprites;
		private Action<HeroRarity?, int?> onApplied;
		private int? previouslySelectedRarity;
		private int? selectedOption;
		private AuctionItem selectedItem;
		private int? previouslySelectedRarityOnOpen;
	
		// Properties
		[ObservableValue]
		public ObservableList<DropdownOption> rarityOptions { get => default; set {} }
		[ObservableValue]
		public bool useMultipleFilters { get => default; set {} }
	
		// Constructors
		public AuctionsFilterPopup() {}
	
		// Methods
		private void _rarityOptionsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(AuctionItem item, Action<HeroRarity?, int?> onFilterApplied) {}
		public override void Hide() {}
		protected override void DisableEveryFilterOption() {}
		private void ResetRarityFilterOption() {}
		protected override void ConfirmFiltersChoice() {}
		protected override List<int> CountSelectedFilters() => default;
		protected override ObservableList<DropdownOption> SetupOptions() => default;
		protected GraphQLObservableList<int> GetSelectedRarityValuesInt() => default;
		protected void IterateOverSelectedRarityOptions(Action<DropdownOption> callback) {}
		[UICallable]
		public override void ToggleMainOption(DropdownOption mainOption) {}
		[UICallable]
		public override void ToggleSubOption(DropdownOption mainOption, DropdownOption subOption) {}
		[UICallable]
		public override void ResetFilters() {}
	}
