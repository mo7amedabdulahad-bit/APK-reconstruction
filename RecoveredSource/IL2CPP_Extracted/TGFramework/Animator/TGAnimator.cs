// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Animator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TGAnimator : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private List<State> states;
		[SerializeField]
		private int currentState;
		[SerializeField]
		public TGAnimator parentAnimatorObject;
		[SerializeField]
		public List<TGAnimator> childAnimatorObjects;
		[SerializeField]
		public string[] flagName;
		public int[] flagStates;
		[SerializeField]
		public int[] flagStatesDefaults;
		public bool pureAnimation;
		private UnityEngine.Component[] allComponents;
		private int nextState;
		private float animationStart;
		private bool animationInProgress;
	
		// Nested types
		[Serializable]
		public class PropertyChange
		{
			// Fields
			public string componentName;
			public string keyName;
			[SerializeField]
			public TGSerializable obj;
			public bool hasOwnCurve;
			[SerializeField]
			public AnimationCurve curve;
			[NonSerialized]
			public TGSerializable oldObj;
			[NonSerialized]
			public TGSerializable referenceObj;
			public PropertyInfo property;
			public UnityEngine.Component component;
	
			// Constructors
			public PropertyChange() {}
	
			// Methods
			public object Lerp(float p) => default;
			public PropertyChange GetCopy(bool takeOldValue = false) => default;
		}
	
		[Serializable]
		public class State
		{
			// Fields
			public string name;
			public bool isAnimated;
			public bool continueToNext;
			[SerializeField]
			public AnimationCurve curve;
			[SerializeField]
			public List<PropertyChange> changes;
			[SerializeField]
			public int[] flagTriggers;
			public bool expandedInEditor;
	
			// Constructors
			public State() {}
		}
	
		// Constructors
		public TGAnimator() {}
	
		// Methods
		private void InitStates() {}
		private void Awake() {}
		private void OnEnable() {}
		private void OnDestroy() {}
		private void OnDisable() {}
		public void ChangeState(bool instant = false) {}
		public void ChangeState(string stateName) {}
		public void ChangeState(int stateNr, bool instant = false) {}
		public void SetFlagTo(int flagNr, int newValue) {}
		public void SetFlagToggle(int flagNr) {}
		public void SetFlagFalse(int flagNr) {}
		public void SetFlagTrue(int flagNr) {}
		private void DoAnimation(bool instant = false) {}
		private void Update() {}
	}
