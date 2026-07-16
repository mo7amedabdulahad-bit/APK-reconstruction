// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class DatabindingSelectableObjectsBase : DatabindingInspectorBase
	{
		// Fields
		protected const bool DeepProfile = false;
		protected const bool IncludeExactNameInProfile = false;
		protected bool isInitialized;
		protected bool freshlyResetted;
		private int stillNeededBindings;
		protected int nextBoundObjectIndexToGet;
		protected int usedBindings;
		private long hierarchyPositionHash;
		private StringBuilder stringBuilder;
		private List<ViewModel> parentViewModels;
		private Dictionary<System.Type, int> recursionPrevention;
		private UnityEngine.Component parentComponentForNewBindings;
		public List<string[]> bindedFieldNameParts;
		public List<BindableObject.ModifierType> bindedFieldNameModifiers;
		public List<string> bindedFieldNames;
		public List<string> bindedFieldDefaultValue;
		protected List<BindableObject> boundObjects;
		private static Dictionary<object, Dictionary<string, BindableObject>> cachedBindingsOnType;
		private static MemberInfo repeatableInfoRepeatObject;
		private static MemberInfo repeatableInfoIndex;
		private static MemberInfo repeatableInfoLastElement;
		private InitRepeatInfo initRepeatInfo;
		private static Dictionary<object, RepeatObjectNames> repeatedObjectNameCache;
	
		// Properties
		protected virtual bool isMethodCaller { get; }
	
		// Nested types
		private struct RepeatObjectNames
		{
			// Fields
			public string name;
			public string indexName;
			public string wholeObjectName;
			public string repeatableName;
			public string lastElementName;
		}
	
		private struct InitRepeatInfo
		{
			// Fields
			public bool searchForRepeat;
			public bool onlySearchForRepeat;
			public bool didInitialize;
			public Repeatable[] ownParentRepeatables;
		}
	
		// Constructors
		protected DatabindingSelectableObjectsBase() {}
		static DatabindingSelectableObjectsBase() {}
	
		// Methods
		public BindableObject GetBoundObject(int nr = 1) => default;
		public string GetBoundName(int nr = 1) => default;
		public string GetBoundDefaultValue(int nr = 1) => default;
		protected void SetBindableObject(int nr, BindableObject obj) {}
		public void SetDefaultValue(int nr, string value) {}
		protected void ResetNextBoundObjectIndexTo(int indexToGet) {}
		protected BindableObject GetNextBoundObject(int indexToGet = -1) => default;
		private BindableObject InsertNewBindingIntoList(Dictionary<string, BindableObject> list, string identifier, object parent, MemberInfo info, BindableObject.ModifierType modifier = BindableObject.ModifierType.None, BindableObject parentBindableObject = null, string inspectorPrefix = null, string removeOldPrefix = null) => default;
		private void IterateSubObject(Dictionary<string, BindableObject> subList, string prefix, MemberInfo info, object objContext, BindableObject prevBindableObject = null, string inspectorPrefix = null, string replacesPrefix = null) {}
		private static System.Type GetBoundSubObjectType(BindableObject otherTarget) => default;
		private Dictionary<string, BindableObject> GetSelectableObjectsIn(object obj, string prefix = "", string inspectorPrefix = null) => default;
		private List<UnityEngine.Component> GetRepeatsAlsoInInactiveParents(GameObject go, ref Repeatable[] ownParentRepeatables) => default;
		private BindableObject GetDatabindingTargetObject(Databinding otherBinding) => default;
		private void AddRepeatableComponent(UnityEngine.Component otherBinding, BindableObject listToWorkOn, Repeatable repeatable, string repeatedObjectInspectorName, string indexObjectInspectorName = null, string repeatableInspectorName = null, string lastElementBoolInspectorName = null) {}
		private void AddAllRepeatComponents() {}
		private BindableObject FillBindableObject(Dictionary<string, BindableObject> list, int nr, object injectParentObject = null) => default;
		public static void ClearCaches() {}
		public virtual void Init(bool forceInit = false) {}
		private void CheckEnumAndMethodBindings() {}
	}
