// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DynamicInterval
	{
		// Properties
		public float MinInterval { get; private set; }
		public float MaxInterval { get; private set; }
		public float MinReferenceValue { get; private set; }
		public float MaxReferenceValue { get; private set; }
		public Ease Easing { get; private set; }
		public float LastCalculatedIntervalValue { get; private set; }
	
		// Constructors
		public DynamicInterval() {} // Dummy constructor
		public DynamicInterval(Ease easing, float interval = 5f) {}
	
		// Methods
		public DynamicInterval WithReferenceValueRange(float min, float max) => default;
		public DynamicInterval WithIntervalRange(float min, float max) => default;
		public int CalculateAsInt(float referenceValue) => default;
		public float Calculate(float referenceValue) => default;
	}
