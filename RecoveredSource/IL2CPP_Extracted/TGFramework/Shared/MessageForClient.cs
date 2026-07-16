// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Shared
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageForClient
	{
		// Fields
		public int requestId;
		public int time;
		public object result;
		public List<SerializedObjectInformation> objects;
		public CacheOperation operation;
		public List<TGFramework.Shared.Error> errors;
		public List<APIMethodCall> calls;
	
		// Nested types
		public enum CacheOperation
		{
			ThisIsNoCollection = 0,
			Replace = 1,
			Add = 2,
			Remove = 3,
			InnerUpdate = 4,
			AddOrUpdate = 5
		}
	
		public enum SerializationMethod
		{
			JsonWrapper = 0,
			ProtoBuf = 1,
			MsgPack = 2
		}
	
		public class SerializedObjectInformation
		{
			// Fields
			public string uniqueId;
			public string className;
			public bool isCollection;
			public SerializationMethod serializationMethod;
			public object serzializedObject;
			public long timestamp;
			public int serial;
			public bool isDeleted;
	
			// Constructors
			public SerializedObjectInformation() {}
		}
	
		// Constructors
		public MessageForClient() {}
	}
