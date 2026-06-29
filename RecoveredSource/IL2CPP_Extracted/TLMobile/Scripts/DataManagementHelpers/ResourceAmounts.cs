// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceAmounts : ObservableModel, IEquatable<ResourceAmounts>, IDisposable
	{
		// Fields
		[ObservableValue]
		private int _wood;
		[ObservableValue]
		private int _clay;
		[ObservableValue]
		private int _iron;
		[ObservableValue]
		private int _crop;
		[ObservableValue]
		private int _sum;
		[ObservableValue]
		private ResourceTypes _highestAmountResourceType;
		[ObservableValue]
		private ObservableDictionary<int, int> _amount;
	
		// Properties
		[ObservableValue]
		public int wood { get => default; set {} }
		[ObservableValue]
		public int clay { get => default; set {} }
		[ObservableValue]
		public int iron { get => default; set {} }
		[ObservableValue]
		public int crop { get => default; set {} }
		[ObservableValue]
		public int sum { get => default; set {} }
		[ObservableValue]
		public ResourceTypes highestAmountResourceType { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, int> amount { get => default; set {} }
	
		// Constructors
		public ResourceAmounts() {}
		public ResourceAmounts(int amountForAll) {}
		public ResourceAmounts(ResourceAmounts otherObject) {}
		public ResourceAmounts(ObservableList<ResourceAmount> original, bool skipType0 = false) {}
		public ResourceAmounts(TLMobile.Generated.GraphQL.Game.Resource original, bool takeProductionInsteadOfStock = false, bool useCropBalanceAsProduction = false) {}
		public ResourceAmounts(ResourcesAmount resourcesAmount, bool skipType0 = true) {}
	
		// Methods
		public bool Equals(ResourceAmounts other) => default;
		public void Add(int type, int amountToAdd, bool updateAmountArray = true) {}
		public void Set(int type, int newAmount, bool updateAmountArray = true) {}
		public void Set(ResourceTypes type, int newAmount, bool updateAmountArray = true) {}
		public void Set(ResourceAmounts otherAmounts) {}
		public int Get(int type) => default;
		public int Get(ResourceTypes type) => default;
		public void Add(ResourceAmounts otherAmounts) {}
		public void Subtract(ResourceAmounts otherAmounts) {}
		public void Multiply(int multiplicator) {}
		public void Multiply(float multiplicator, int roundFactor = 1) {}
		public int Divide(ResourceAmounts otherAmounts) => default;
		private void AmountsChanged(object o, PropertyChangedEventArgs args) {}
		public void UpdateAmountAndSum() {}
		public bool IsMoreOrEqualThan(ResourceAmounts other) => default;
		public bool IsMoreOrEqualThanWithoutCrop(ResourceAmounts other) => default;
		public int[] GetAsArray() => default;
		public void Dispose() {}
		private void _amountNotify(object sender, PropertyChangedEventArgs args) {}
	}
