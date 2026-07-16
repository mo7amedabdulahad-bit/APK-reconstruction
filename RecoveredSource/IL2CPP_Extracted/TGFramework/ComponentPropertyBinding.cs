// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ComponentPropertyBinding : DatabindingWithLogic
	{
		// Fields
		[HideInInspector]
		public string selectedComponentValue;
		[HideInInspector]
		public string twoWayBinding;
		[HideInInspector]
		public BoundProperty binding;
		public bool interpolateOverTime;
		public bool isVeryFirstInterpolation;
		public bool resetToLastValueIfEmpty;
		[SerializeField]
		public InterpolationInfo interpolation;
		public UnityEngine.Component selectedComponent;
		public Dictionary<string, BoundProperty> changeableValues;
		private static List<System.Type> allowedPropertyTypes;
		private bool initializedInterpolationLoop;
		private bool retriedOnce;
		private bool preventSetterRecursion;
		private string[] splittedSelectedComponent;
		private object twoWayBindingListener;
	
		// Properties
		public bool doInterpolateOverTime { get => default; set {} }
	
		// Nested types
		public enum Modifier
		{
			None = 0,
			VectorX = 1,
			VectorY = 2,
			VectorZ = 3,
			Left = 4,
			Right = 5,
			Top = 6,
			Bottom = 7
		}
	
		public class BoundProperty
		{
			// Fields
			public string name;
			public UnityEngine.Component selectedComponent;
			public PropertyInfo selectedProperty;
			public Modifier modifier;
	
			// Constructors
			public BoundProperty() {}
		}
	
		[Serializable]
		public class InterpolationInfo
		{
			// Fields
			public bool active;
			public double startValue;
			public double currentValue;
			public double destinationValue;
			public float startTime;
			public int roundDigits;
			public AnimationCurve curve;
			public float duration;
			private float timePassedBeforePaused;
			public ComponentPropertyBinding parentBinding;
			private bool _paused;
	
			// Properties
			public bool IsPaused { get => default; }
	
			// Constructors
			public InterpolationInfo() {}
	
			// Methods
			public void SetPaused(bool newPaused, bool resetStartTime = false) {}
		}
	
		// Constructors
		public ComponentPropertyBinding() {}
	
		// Methods
		protected virtual void AddPossibleBinding(UnityEngine.Component component, PropertyInfo info, string name, Modifier mod = Modifier.None, bool setAsMyBinding = false, string onlyTakeVectorPart = null) {}
		public Dictionary<string, object> GetPossibleWatchMethods() => default;
		protected virtual bool IsTypeValidForBinding(System.Type typeToCheck) => default;
		public override void Init(bool force = false) {}
		public void UpdateBoundVariable(object newValue) {}
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		private void SetTargetToValue(object newValue) {}
		private double GetCurrentInterpolatedValue() => default;
		protected void StartInterpolationLoop() {}
		protected void StopInterpolationLoop() {}
		public void DoInterpolation() {}
		private object getCurrentValue() => default;
		public override void UpdateTarget() {}
		public override void OnDestroy() {}
	}
