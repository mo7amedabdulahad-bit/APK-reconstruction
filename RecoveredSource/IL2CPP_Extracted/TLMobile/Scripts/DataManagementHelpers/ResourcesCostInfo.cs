// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourcesCostInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private ResourceAmounts _cost;
		[ObservableValue]
		private ResourceAmounts _difference;
		[ObservableValue]
		private OwnHero _ownHero;
		[ObservableValue]
		private int _costFreeCrop;
		[ObservableValue]
		private bool _isButtonDisabled;
		[ObservableValue]
		private GeneralErrorType _errorType;
		private ResourceAmounts differenceToStock;
		private ResourceAmounts differenceToCapacity;
		private GeneralErrorType errorConfig;
		private OwnVillage currentVillage;
		private Func<bool, bool> additionalCondition;
	
		// Properties
		[ObservableValue]
		public ResourceAmounts cost { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts difference { get => default; set {} }
		[ObservableValue]
		public OwnHero ownHero { get => default; set {} }
		[ObservableValue]
		public int costFreeCrop { get => default; set {} }
		[ObservableValue]
		public bool isButtonDisabled { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType errorType { get => default; set {} }
	
		// Constructors
		[Obsolete("Added only for TGFramework compatibility. Use the constructor with parameters.")]
		public ResourcesCostInfo() {}
		public ResourcesCostInfo(ResourcesAmount cost, int costFreeCrop = 0, GeneralErrorType errorConfig = GeneralErrorType.None | GeneralErrorType.ExtendWarehouse | GeneralErrorType.ExtendGranary | GeneralErrorType.ExtendWarehouseAndGranary, Func<bool, bool> additionalCondition = null) {}
		public ResourcesCostInfo(ResourceAmounts cost, int costFreeCrop = 0, GeneralErrorType errorConfig = GeneralErrorType.None | GeneralErrorType.ExtendWarehouse | GeneralErrorType.ExtendGranary | GeneralErrorType.ExtendWarehouseAndGranary, Func<bool, bool> additionalCondition = null) {}
	
		// Methods
		~ResourcesCostInfo() {}
		private void CurrentVillageResourcesChanged() {}
		public GeneralErrorType GetErrorType(int costFreeCrop = 0) => default;
		public bool HasAdditionalConditionError(bool skipToast = false) => default;
		public bool HasCapacityError(bool skipToast = false) => default;
		public bool HasCropError(bool skipToast = false) => default;
		public bool HasCropProductionError(bool skipToast = false) => default;
		public bool HasOwnHeroNoResources(bool skipToast = false) => default;
	}
