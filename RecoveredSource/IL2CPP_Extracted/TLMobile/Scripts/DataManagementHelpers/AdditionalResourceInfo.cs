// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AdditionalResourceInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private int _resourceIndex;
		[ObservableValue]
		private int _timeWhenFull;
		[ObservableValue]
		private float _resourcesInterpolated;
		[ObservableValue]
		private int _valueFloored;
		[ObservableValue]
		private float _fillPercent;
		[ObservableValue]
		private int _storageCapacity;
		[ObservableValue]
		private int _production;
		private int type;
		private TLMobile.Generated.GraphQL.Game.Resource sourceObject;
		private int firstCalculation;
	
		// Properties
		[ObservableValue]
		public int resourceIndex { get => default; set {} }
		[ObservableValue]
		public int timeWhenFull { get => default; set {} }
		[ObservableValue]
		public float resourcesInterpolated { get => default; set {} }
		[ObservableValue]
		public int valueFloored { get => default; set {} }
		[ObservableValue]
		public float fillPercent { get => default; set {} }
		[ObservableValue]
		public int storageCapacity { get => default; set {} }
		[ObservableValue]
		public int production { get => default; set {} }
	
		// Constructors
		public AdditionalResourceInfo() {}
		public AdditionalResourceInfo(int resourceType, TLMobile.Generated.GraphQL.Game.Resource sourceObject) {}
	
		// Methods
		public void UpdateValues(bool resetFirstCalculation) {}
		public void Interpolate() {}
	}
