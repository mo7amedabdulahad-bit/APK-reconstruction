// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroResourceTransferPopupController : DetailWindowController
	{
		// Fields
		public List<UnityEngine.UI.Slider> sliders;
		[ObservableValue]
		private ResourceAmounts _resourcesLeft;
		[ObservableValue]
		private ResourceAmounts _resourcesSelected;
		[ObservableValue]
		private ResourceAmounts _newResources;
		[ObservableValue]
		private ResourceAmounts _resourcesMax;
		[ObservableValue]
		private ObservableList<bool> _resourcesLocked;
		[ObservableValue]
		private ObservableList<bool> _resourcesAtMax;
		[ObservableValue]
		private bool _someStorageFull;
		[ObservableValue]
		private bool _storageFull;
		[ObservableValue]
		private bool _showMaxTransferButton;
		private OwnVillage ownVillage;
		private OwnHero ownHero;
		private ResourceAmounts resourcesInVillage;
		private ResourceAmounts requestedResources;
	
		// Properties
		[ObservableValue]
		public ResourceAmounts resourcesLeft { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesSelected { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts newResources { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesMax { get => default; set {} }
		[ObservableValue]
		public ObservableList<bool> resourcesLocked { get => default; set {} }
		[ObservableValue]
		public ObservableList<bool> resourcesAtMax { get => default; set {} }
		[ObservableValue]
		public bool someStorageFull { get => default; set {} }
		[ObservableValue]
		public bool storageFull { get => default; set {} }
		[ObservableValue]
		public bool showMaxTransferButton { get => default; set {} }
	
		// Constructors
		public HeroResourceTransferPopupController() {}
	
		// Methods
		private void _resourcesLockedNotify(object sender, PropertyChangedEventArgs args) {}
		private void _resourcesAtMaxNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void UpdateButtonVisibility() {}
		public void PrefillAmounts(ResourceAmounts resourceAmounts) {}
		private void CurrentVillageChanged(OwnVillage newVillage) {}
		private void SelectedAmountChange(object o, PropertyChangedEventArgs args) {}
		private void ResetSelected() {}
		private void UpdateValues() {}
		private void UpdateResource(int index) {}
		private void CheckLockedStatus() {}
		private List<IPromise> CallTransferResourceApi(ResourceTypes resourceType, int requestedAmount) => default;
		[UICallable]
		public void TransferSelected() {}
		[UICallable]
		public void TransferMaximum() {}
	}
