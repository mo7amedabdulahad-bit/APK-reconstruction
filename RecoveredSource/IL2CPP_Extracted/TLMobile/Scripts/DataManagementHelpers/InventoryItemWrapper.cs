// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryItemWrapper : ObservableModel, IMoveableDroppable
	{
		// Fields
		private const string TranslationKeyPrefixCategory = "hero.itemTypeV2_";
		private const string TranslationKeyPrefixName = "items.item";
		[ObservableValue]
		private InteractionPurpose _interactionPurpose;
		[ObservableValue]
		private int _placeId;
		[ObservableValue]
		private int _typeId;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private bool _isConsumable;
		[ObservableValue]
		private bool _isUsableIfDead;
		[ObservableValue]
		private GraphQLObservableList<InventoryItemAttributes> _attributes;
		[ObservableValue]
		private string _slot;
		[ObservableValue]
		private HeroQuality _quality;
		[ObservableValue]
		private HeroRarity _rarity;
		[ObservableValue]
		private GraphQLObservableList<int> _possibleAmountsToSell;
		[ObservableValue]
		private string _place;
		[ObservableValue]
		private string _descriptionDetails;
		[ObservableValue]
		private bool? _canBeUsed;
		[ObservableValue]
		private string _errorMessage;
		[ObservableValue]
		private string _tooltipErrorMessage;
		[ObservableValue]
		private string _warningMessage;
		[ObservableValue]
		private int _maxInput;
		[ObservableValue]
		private int _minInput;
		[ObservableValue]
		private int _defaultInput;
		[ObservableValue]
		private string _description;
		[ObservableValue]
		private int? _alreadyEquipped;
		[ObservableValue]
		private bool? _isEquipped;
		[ObservableValue]
		private bool? _canBeClicked;
		[ObservableValue]
		private ClickShortDescription _clickShortDescription;
		[ObservableValue]
		private InventoryItemCooldown _cooldown;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private string _descriptionDecoded;
		[ObservableValue]
		private TypeIdEnum _typeIdEnum;
		[ObservableValue]
		private HeroItemCategory _heroItemCategory;
		[ObservableValue]
		private bool _canBeSold;
		[ObservableValue]
		private bool _soldInBulk;
		[ObservableValue]
		private int? _id;
		[ObservableValue]
		private int _amount;
		[ObservableValue]
		private bool _forceShowAmount;
		[ObservableValue]
		private ItemDataType _dataType;
		[ObservableValue]
		private int _heroRarityIndex;
		[ObservableValue]
		private int _heroItemCategoryIndex;
		[ObservableValue]
		private int _amountNotInUse;
		[ObservableValue]
		private int _imageToUse;
		[ObservableValue]
		private bool _everythingInUse;
		private int temporaryInUseAmount;
	
		// Properties
		[ObservableValue]
		public string TranslationKeyCategory { get => default; }
		[ObservableValue]
		public string TranslationKeyName { get => default; }
		[ObservableValue]
		public string TranslationKeyRarity { get => default; }
		[ObservableValue]
		public string TranslationKeyInteractionPurpose { get => default; }
		[ObservableValue]
		public string TranslationKeyItemTypeText { get => default; }
		[ObservableValue]
		public string TranslationKeyItemQuality { get => default; }
		[ObservableValue]
		public InteractionPurpose interactionPurpose { get => default; set {} }
		[ObservableValue]
		public int placeId { get => default; set {} }
		[ObservableValue]
		public int typeId { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public bool isConsumable { get => default; set {} }
		[ObservableValue]
		public bool isUsableIfDead { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<InventoryItemAttributes> attributes { get => default; set {} }
		[ObservableValue]
		public string slot { get => default; set {} }
		[ObservableValue]
		public HeroQuality quality { get => default; set {} }
		[ObservableValue]
		public HeroRarity rarity { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> possibleAmountsToSell { get => default; set {} }
		[ObservableValue]
		public string place { get => default; set {} }
		[ObservableValue]
		public string descriptionDetails { get => default; set {} }
		[ObservableValue]
		public bool? canBeUsed { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
		[ObservableValue]
		public string tooltipErrorMessage { get => default; set {} }
		[ObservableValue]
		public string warningMessage { get => default; set {} }
		[ObservableValue]
		public int maxInput { get => default; set {} }
		[ObservableValue]
		public int minInput { get => default; set {} }
		[ObservableValue]
		public int defaultInput { get => default; set {} }
		[ObservableValue]
		public string description { get => default; set {} }
		[ObservableValue]
		public int? alreadyEquipped { get => default; set {} }
		[ObservableValue]
		public bool? isEquipped { get => default; set {} }
		[ObservableValue]
		public bool? canBeClicked { get => default; set {} }
		[ObservableValue]
		public ClickShortDescription clickShortDescription { get => default; set {} }
		[ObservableValue]
		public InventoryItemCooldown cooldown { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public string descriptionDecoded { get => default; set {} }
		[ObservableValue]
		public TypeIdEnum typeIdEnum { get => default; set {} }
		[ObservableValue]
		public HeroItemCategory heroItemCategory { get => default; set {} }
		[ObservableValue]
		public bool canBeSold { get => default; set {} }
		[ObservableValue]
		public bool soldInBulk { get => default; set {} }
		[ObservableValue]
		public int? id { get => default; set {} }
		[ObservableValue]
		public int amount { get => default; set {} }
		[ObservableValue]
		public bool forceShowAmount { get => default; set {} }
		[ObservableValue]
		public ItemDataType dataType { get => default; set {} }
		[ObservableValue]
		public int heroRarityIndex { get => default; set {} }
		[ObservableValue]
		public int heroItemCategoryIndex { get => default; set {} }
		[ObservableValue]
		public int amountNotInUse { get => default; set {} }
		[ObservableValue]
		public int imageToUse { get => default; set {} }
		[ObservableValue]
		public bool everythingInUse { get => default; set {} }
	
		// Constructors
		public InventoryItemWrapper() {}
		public InventoryItemWrapper(TLMobile.Generated.GraphQL.Game.Item item, InteractionPurpose interactionPurpose = InteractionPurpose.View) {}
		public InventoryItemWrapper(InventoryItem item, InteractionPurpose interactionPurpose = InteractionPurpose.View) {}
		public InventoryItemWrapper(HeroInventoryItem item, InteractionPurpose? interactionPurpose = default) {}
	
		// Methods
		public static InventoryItemWrapper CreateFakeMaterial(HeroRarity rarity) => default;
		public static InventoryItemWrapper CreateFakeItem(InventoryItemWrapper item, int? id = default, int? typeId = default, HeroRarity? rarity = default, TypeIdEnum? typeIdEnum = default) => default;
		public override void AfterServerDataCallback() {}
		private void UpdateImageToUse() {}
		public int GetMinSellableAmount() => default;
		public void UpdateAmountInUse(int value) {}
		public InventoryItemWrapper UpdatePurpose(InteractionPurpose? interactionPurpose = default, OwnHero ownHero = null) => default;
		public IPromise CallMoveDroppable(int? target, int selectedAmount, System.Action afterSuccessCallback, Action<Exception> afterFailCallback = null) => default;
		public void CallUseInventory(int selectedAmount, System.Action afterSuccessCallback, Action<Exception> afterFailCallback = null) {}
		public string GetError(OwnHero hero) => default;
		public bool IsEqual(InventoryItemWrapper other) => default;
		public InventoryItemWrapper Clone() => default;
		public void UpdateData(InventoryItemWrapper newData, bool isClone = false) {}
		public void Clear() {}
		public HeroItemCategory GetFilterCategory() => default;
		public void FillFromAuctionItem(AuctionItem auctionItem) {}
		public void FillFromAuctionInterface(AuctionInterface auctionInterface) {}
		public void FillFromAdventureDroppedItem(AdventureDroppedItem adventureDroppedItem) {}
		private string GetItemTypeTextTranslationKey() => default;
		private string GetItemQualityTranslationKey() => default;
		private void _attributesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _possibleAmountsToSellNotify(object sender, PropertyChangedEventArgs args) {}
	}
