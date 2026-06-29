// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Repeat : Databinding
	{
		// Fields
		public IList list;
		public IDictionary dict;
		public bool ascending;
		public int poolInstanceAmount;
		public int poolInstanceRate;
		public int maxMsPerFrame;
		private BindableObject orderBy;
		private MemberInfo orderMember;
		public GameObject rowTemplate;
		private bool didStopRenderingLastFrame;
		private Dictionary<int, KeyValuePair<GameObject, Repeatable>> renderedObjects;
		private HashSet<int> currentlyInList;
		private int firstSiblingIndex;
		private int currentSiblingIndex;
		private ServerObject subscriptionObject;
		private BindableObject filterValueMethod;
		private BindableObject filterKeyMethod;
		private bool doFilter;
		private StringBuilder sb;
		private Queue<GameObject> pooledInstances;
		private Stopwatch reRenderWatch;
		private int lastReRenderedFrame;
		private int isPausedWithUpdates;
		[SerializeField]
		private int skipAmountOfElements;
		[SerializeField]
		private int limitAmountOfElements;
		public bool orderOfElementsMatter;
		public bool takeFirstInstanceAsNewTemplate;
		public bool containsVisibilityComponents;
		private static int nextDummyHashKey;
		private int currentElementCount;
		private bool didInitializeNewTemplate;
		private string benchmarkNewTemplateName;
		private bool reRenderOnEnable;
		private bool didRenderAtLeastOne;
		public UnityEvent OnReRender;
		private bool didRegisterObjectListener;
		private Repeatable lastRenderedElement;
	
		// Properties
		public int amountOfElements { get => default; set {} }
		public int skipElements { get => default; set {} }
		public bool PauseUpdates { get => default; set {} }
	
		// Constructors
		public Repeat() {}
	
		// Methods
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		private void Awake() {}
		public override void Start() {}
		public void ResetPooledInstances() {}
		private void CheckPoolInstances() {}
		private void UpdateWrapper(ServerObject x) {}
		public override void UpdateTarget() {}
		public override void OnDestroy() {}
		public void Clear(bool immediate = false) {}
		private bool FilterListElement(object elem, object index) => default;
		private void DeleteAddedGameObjects(GameObject original, GameObject copy) {}
		private int RenderListElement(object elem, object index) => default;
		public static void ReRenderAllUnder(GameObject parent) {}
		public static void CleanAllUnder(GameObject parent) {}
		private void EndRenderForThisFrame() {}
		protected override void OnEnable() {}
		public void ReRender() {}
		private bool AddToList(HashSet<int> list, object element, object index) => default;
		protected virtual int GetObjectIdentity(object elem) => default;
	}
