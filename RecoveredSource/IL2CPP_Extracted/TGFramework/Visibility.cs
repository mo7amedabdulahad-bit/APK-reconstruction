// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Visibility : DatabindingWithLogic
	{
		// Fields
		private bool addedUpdateCallback;
		private bool combinedActive;
		private bool combinedNeedsLoop;
		protected object compareTo;
		private bool didStartVisibility;
		private bool originalVisible;
		public bool firstVisible;
		public List<VisibilitySlave> slaves;
		private static GameObject isCurrentlyActivatingChildren;
		private string debugGameObjectName;
		protected bool visible;
		protected Visibility[] allVisibilityComponents;
		private const int OPERATOR_AND = 0;
		private const int OPERATOR_OR = 1;
		private const int OPERATOR_USE_NEW_SYSTEM = 2;
		public int boolOperator;
	
		// Events
		public event Action<bool> VisibilityChanged;
	
		// Constructors
		public Visibility() {}
	
		// Methods
		public override void Start() {}
		public void DisableForRepeat() {}
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		public override void UpdateTarget() {}
		public override void Reset() {}
		public virtual void UpdateCompareTo(object newVal) {}
		protected virtual bool IsInitialized() => default;
		public virtual void UpdateValue(object newVal, bool changeVisibilityIfNecessary = true) {}
		public void UpdateSlaves() {}
		public void RegisterUpdateCallback() {}
		public void UnregisterUpdateCallback() {}
		public override void OnDestroy() {}
	}
