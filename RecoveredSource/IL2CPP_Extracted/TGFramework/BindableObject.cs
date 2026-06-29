// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BindableObject
	{
		// Fields
		public string identifier;
		public string inspectorName;
		public UnityEngine.Component parentComponent;
		public object parentObject;
		public MemberInfoWrapper memberInfo;
		public ModifierType modifier;
		public bool isObservable;
		public BindableObject parentBindableObject;
		public BindableObject waitsForObject;
		public bool parentChanged;
		public bool isRootParent;
		public bool hasToBeChecked;
		public bool watched;
		public object lastFetchedValue;
		public List<System.Type> methodParameterType;
		public BindableObject nextBindableObject;
		public object oldValue;
		private static ObjectPool<BindableObject> bindableObjectPool;
		private List<object> oldParents;
		private bool hasFirstRealValue;
		private List<BindableObject> flattenedList;
	
		// Nested types
		public enum ModifierType
		{
			None = 0,
			ListCount = 1,
			ListElement = 2,
			Constant = 3,
			DictElement = 4,
			ClassName = 5,
			Repeatable = 6,
			RepeatObject = 7,
			RepeatIndex = 8,
			EnumName = 9
		}
	
		// Constructors
		public BindableObject() {}
		public BindableObject(string identifier, object parent, MemberInfo info, ModifierType modifier, BindableObject parentBindableObject) {}
	
		// Methods
		public static BindableObject GetPooledFor(string identifier, object parent, MemberInfo info, ModifierType modifier, BindableObject parentBindableObject) => default;
		public void Setup(string identifier, object parent, MemberInfo info, ModifierType modifier, BindableObject parentBindableObject) {}
		public static bool IsNumericType(System.Type t) => default;
		public BindableObject Copy() => default;
		public BindableObject DeepCopy(object parentObjectToSet = null) => default;
		public string GetTypeName() => default;
		public System.Type GetElementType() => default;
		public void SetValue(object newVal) {}
		public object GetValue(bool ignoreListIndex = false) => default;
		public override string ToString() => default;
		public void FillObjects() {}
	}
