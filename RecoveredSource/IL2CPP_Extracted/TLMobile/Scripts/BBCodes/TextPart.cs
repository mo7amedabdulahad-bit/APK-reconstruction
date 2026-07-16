// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public struct TextPart
	{
		// Properties
		public Type CurrentType { get; }
		public string StringValue { get; }
		public GameObject GameObject { get; }
	
		// Nested types
		public enum Type
		{
			String = 0,
			Object = 1
		}
	
		// Constructors
		public TextPart(string pureString) : this() {}
		public TextPart(GameObject gameObject) : this() {}
	}
