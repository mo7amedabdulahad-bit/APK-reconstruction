// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class Databinding : DatabindingSelectableObjectsBase
	{
		// Fields
		private bool didStart;
		protected bool alreadyStartedViaRestartDatabindings;
		private int retryCount;
		private bool firstUpdateCall;
		protected bool needsUpdateLoop;
		protected bool thisComponentReallyNeedsUpdateLoop;
		private static ReInitializeInformations reInitInfos;
		private static List<Databinding> dbs;
		private List<BoundWatch> watches;
		private List<object> watchedObjects;
	
		// Events
		public event System.Action OnUpdateTarget;
	
		// Nested types
		public enum Operation
		{
			LessThan = 0,
			LessOrEqual = 1,
			Equal = 2,
			NotEqual = 3,
			GreaterOrEqual = 4,
			GreaterThan = 5,
			Null = 6,
			NotNull = 7,
			True = 8,
			False = 9,
			Bit = 10,
			NotBit = 11,
			ListContains = 12
		}
	
		private class ReInitializeInformations
		{
			// Fields
			public GameObject rootObject;
			public int globalNumber;
			public int startingNumber;
			public List<GameObject> alreadyProcessedGOs;
			public List<Databinding> databindingsToAppend;
			public HashSet<Databinding> alreadyProcessedDBs;
			public int initializedObjects;
			public List<Databinding> temporaryDatabindings;
	
			// Constructors
			public ReInitializeInformations() {}
		}
	
		private class BoundWatch
		{
			// Fields
			public ITGObservable observedObject;
			public string observedName;
			public System.Action callback;
	
			// Constructors
			public BoundWatch() {}
		}
	
		// Constructors
		protected Databinding() {}
		static Databinding() {}
	
		// Methods
		public static void ReInitializeAllUnder(GameObject go, bool ignoreOwnVisibilities = false, bool reinitialiseOnlyVisibilitiesOnDisabledObjects = false) {}
		public virtual void Reset() {}
		protected virtual void OnEnable() {}
		public virtual void Start() {}
		public virtual void OnDestroy() {}
		public virtual void UpdateTarget() {}
		protected virtual bool BindingSuccessful() => default;
		public virtual bool BindingSuccessfulInEditor() => default;
		private void CallUpdateTarget() {}
		protected void CallOnUpdateTargetListeners() {}
		public virtual void DoUpdateLoop() {}
		public bool DoesNeedUpdateLoop() => default;
		private void AddAllWatches() {}
		private void RemoveAllWatches() {}
		private void AddWatch(ITGObservable observedObject, string observedName, System.Action callback, object currentValue = null) {}
		private void OnParentChange() {}
	}
