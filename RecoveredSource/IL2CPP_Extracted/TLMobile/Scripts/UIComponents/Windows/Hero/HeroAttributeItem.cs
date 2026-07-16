// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAttributeItem : ObservableModel
	{
		// Fields
		[ObservableValue]
		private HeroAttribute _attribute;
		[ObservableValue]
		private float _selectedUnitPoints;
		[ObservableValue]
		private int _modifiedUsedPoints;
		[ObservableValue]
		private int _minAvailablePoints;
		[ObservableValue]
		private int _maxAvailablePoints;
		[ObservableValue]
		private float _modifiedAttributeValue;
		[ObservableValue]
		private bool _addPointsDisabled;
		[ObservableValue]
		private bool _valueIsPercentage;
	
		// Properties
		[ObservableValue]
		public HeroAttribute attribute { get => default; set {} }
		[ObservableValue]
		public float selectedUnitPoints { get => default; set {} }
		[ObservableValue]
		public int modifiedUsedPoints { get => default; set {} }
		[ObservableValue]
		public int minAvailablePoints { get => default; set {} }
		[ObservableValue]
		public int maxAvailablePoints { get => default; set {} }
		[ObservableValue]
		public float modifiedAttributeValue { get => default; set {} }
		[ObservableValue]
		public bool addPointsDisabled { get => default; set {} }
		[ObservableValue]
		public bool valueIsPercentage { get => default; set {} }
		public int selectedPoints { get; private set; }
	
		// Constructors
		[Obsolete("Used only by data bindings")]
		public HeroAttributeItem() {}
		public HeroAttributeItem(HeroAttribute heroAttribute) {}
	
		// Methods
		public void SetPoint(int point) {}
		[UICallable]
		public void AddPoint(int point) {}
		private void AdjustObservables() {}
		private void SetModifiedAttributeValue() {}
		public void UpdatePointAddDisabled(int availablePoints) {}
	}
