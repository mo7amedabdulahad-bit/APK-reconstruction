// TLMobile.dll - TLMobile.Scripts.UIComponents.Windows.InventoryController
// Extracted from IL2CPP metadata v39
// Method count: 42
// NOTE: Method bodies are stubs - require native decompilation

namespace TLMobile.Scripts.UIComponents.Windows
{
    public class InventoryController
    {
        #region Constructors
        // 0x0512AAF0
        public InventoryController() { }
        #endregion

        #region Methods
        // 0x05128EBC: ObservableList`1[TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper] get_inventoryItems()
        public ObservableList`1[TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper] get_inventoryItems() { return default; }
        // 0x05128EC4: Void set_inventoryItems(ObservableList`1[TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper])
        public void set_inventoryItems(ObservableList`1[TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper]) { return default; }
        // 0x05128FC8: Void _inventoryItemsNotify(Object, PropertyChangedEventArgs)
        public void _inventoryItemsNotify(Object, PropertyChangedEventArgs) { return default; }
        // 0x05129024: HeroItemCategory get_currentFilter()
        public HeroItemCategory get_currentFilter() { return default; }
        // 0x0512902C: Void set_currentFilter(HeroItemCategory)
        public void set_currentFilter(HeroItemCategory) { return default; }
        // 0x05129100: ObservableList`1[TLMobile.Scripts.Enums.HeroItemCategory] get_inventoryFilters()
        public ObservableList`1[TLMobile.Scripts.Enums.HeroItemCategory] get_inventoryFilters() { return default; }
        // 0x05129108: Void set_inventoryFilters(ObservableList`1[TLMobile.Scripts.Enums.HeroItemCategory])
        public void set_inventoryFilters(ObservableList`1[TLMobile.Scripts.Enums.HeroItemCategory]) { return default; }
        // 0x0512920C: Void _inventoryFiltersNotify(Object, PropertyChangedEventArgs)
        public void _inventoryFiltersNotify(Object, PropertyChangedEventArgs) { return default; }
        // 0x05129268: InventoryItemWrapper get_selectedItem()
        public InventoryItemWrapper get_selectedItem() { return default; }
        // 0x05129270: Void set_selectedItem(InventoryItemWrapper)
        public void set_selectedItem(InventoryItemWrapper) { return default; }
        // 0x0512930C: HeroEquipment get_equipment()
        public HeroEquipment get_equipment() { return default; }
        // 0x05129314: Void set_equipment(HeroEquipment)
        public void set_equipment(HeroEquipment) { return default; }
        // 0x051293B0: OwnHero get_ownHero()
        public OwnHero get_ownHero() { return default; }
        // 0x051293B8: Void set_ownHero(OwnHero)
        public void set_ownHero(OwnHero) { return default; }
        // 0x05129454: Boolean get_filteredCategoryIsEmpty()
        public bool get_filteredCategoryIsEmpty() { return default; }
        // 0x0512945C: Void set_filteredCategoryIsEmpty(Boolean)
        public void set_filteredCategoryIsEmpty(bool) { return default; }
        // 0x051294F0: Int32 get_actualInventoryItemCount()
        public int get_actualInventoryItemCount() { return default; }
        // 0x051294F8: Void set_actualInventoryItemCount(Int32)
        public void set_actualInventoryItemCount(int) { return default; }
        // 0x0512958C: HeroItemCategory get_horseCategory()
        public HeroItemCategory get_horseCategory() { return default; }
        // 0x05129594: Void set_horseCategory(HeroItemCategory)
        public void set_horseCategory(HeroItemCategory) { return default; }
        // 0x05129668: Void add_OnItemSelected(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper])
        public void add_OnItemSelected(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper]) { return default; }
        // 0x05129718: Void remove_OnItemSelected(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper])
        public void remove_OnItemSelected(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper]) { return default; }
        // 0x051297C8: Void Awake()
        public void Awake() { return default; }
        // 0x05129A58: Void SetCurrentFilter(HeroItemCategory)
        public void SetCurrentFilter(HeroItemCategory) { return default; }
        // 0x05129B78: Void OnEnable()
        public void OnEnable() { return default; }
        // 0x05129C1C: Void UpdateHero()
        public void UpdateHero() { return default; }
        // 0x05129C98: Void UnSelectItem()
        public void UnSelectItem() { return default; }
        // 0x05129CA0: Void OnDisable()
        public void OnDisable() { return default; }
        // 0x05129D08: Void TemporarilyFilterOutItem(InventoryItemWrapper)
        public void TemporarilyFilterOutItem(InventoryItemWrapper) { return default; }
        // 0x05129DC8: Void RemoveAllTemporaryFilters()
        public void RemoveAllTemporaryFilters() { return default; }
        // 0x05129E4C: Boolean FilterInventory(InventoryItemWrapper)
        public bool FilterInventory(InventoryItemWrapper) { return default; }
        // 0x05129E98: Void UpdateInventory()
        public void UpdateInventory() { return default; }
        // 0x0512A5A8: Boolean FilterOutMaterialCategory(HeroItemCategory)
        public bool FilterOutMaterialCategory(HeroItemCategory) { return default; }
        // 0x0512A5B4: InventoryItemWrapper GetFirstEmptySlot()
        public InventoryItemWrapper GetFirstEmptySlot() { return default; }
        // 0x0512A6B0: Void SelectItem(Int32, InventoryItemWrapper)
        public void SelectItem(Int32, InventoryItemWrapper) { return default; }
        // 0x0512A9BC: Void DeselectItemAndUpdateEquipment(InventoryItemWrapper)
        public void DeselectItemAndUpdateEquipment(InventoryItemWrapper) { return default; }
        // 0x0512A9D8: List`1[TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper] SearchItemsByCategory(HeroItemCategory, Nullable`1[TLMobile.Scripts.Enums.HeroRarity], Nullable`1[TLMobile.Scripts.Enums.HeroQuality])
        public List`1[TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper] SearchItemsByCategory(HeroItemCategory, Nullable`1[TLMobile.Scripts.Enums.HeroRarity], Nullable`1[TLMobile.Scripts.Enums.HeroQuality]) { return default; }
        // 0x0512AAE8: Void RegisterItemClickHandler(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper])
        public void RegisterItemClickHandler(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper]) { return default; }
        // 0x0512AAEC: Void UnregisterItemClickHandler(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper])
        public void UnregisterItemClickHandler(Action`2[Int32,TLMobile.Scripts.DataManagementHelpers.InventoryItemWrapper]) { return default; }
        // 0x0512AB04: Boolean <UpdateInventory>b__52_1(InventoryItemWrapper)
        public bool <UpdateInventory>b__52_1(InventoryItemWrapper) { return default; }
        // 0x0512AB34: Void <SetCurrentFilter>b__55_0()
        public void <SetCurrentFilter>b__55_0() { return default; }
        #endregion
    }
}
