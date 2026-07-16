// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class DatabindingInspectorBase : MonoBehaviour
	{
		// Fields
		protected Dictionary<string, BindableObject> selectableObjects;
		protected static Dictionary<int, List<BindableObject>> selectableNameCache;
		protected bool foundFilteredMatch;
	
		// Constructors
		protected DatabindingInspectorBase() {}
	
		// Methods
		protected List<string> GetAllNumberTypes() => default;
		protected List<string> GetAllListTypes() => default;
		public virtual BindableObject GetSelectableObject(string name) => default;
		public virtual List<BindableObject> GetSelectableObjects(BindableObject listObject) => default;
		public virtual List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		protected List<BindableObject> FilterSelectableObjects(string nameFilter, string negativeNameFilter, List<string> validTypes, List<string> invalidTypes) => default;
	}
