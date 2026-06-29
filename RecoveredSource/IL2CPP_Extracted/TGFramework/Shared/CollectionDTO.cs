// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Shared
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CollectionDTO : IClientDTO
	{
		// Fields
		public List<object> elements;
		public Operation operation;
		public string id;
		public string typeString;
	
		// Nested types
		public enum Operation
		{
			Unknown = 0,
			Replace = 1,
			Add = 2,
			Remove = 3
		}
	
		// Constructors
		public CollectionDTO() {}
	
		// Methods
		public string GetId() => default;
	}
