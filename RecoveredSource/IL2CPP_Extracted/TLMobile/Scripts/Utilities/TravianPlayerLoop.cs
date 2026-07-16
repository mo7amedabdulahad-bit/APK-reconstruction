// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

public class TravianPlayerLoop : ScriptableObject
{
	// Fields
	private TravianPlayerLoopData data;

	// Properties
	public int Count { get => default; }
	public int CountActive { get => default; }
	public List<string> Keys { get => default; }

	// Nested types
	[Serializable]
	private class TravianPlayerLoopData
	{
		// Fields
		public List<string> keys;
		public List<bool> usages;
		public List<int> depths;

		// Constructors
		public TravianPlayerLoopData() {}
	}

	// Constructors
	public TravianPlayerLoop() {}

	// Methods
	public void RecursiveInit(PlayerLoopSystem root, int depth = 0) {}
	private void add(PlayerLoopSystem system, int depth) {}
	public KeyValuePair<int, bool> Get(PlayerLoopSystem system) => default;
	public KeyValuePair<int, bool> Get(string system) => default;
	public void SetActive(PlayerLoopSystem system, bool enable) {}
	public void SetActive(string system, bool enable) {}
	private TravianPlayerLoopData FromJson(string json) => default;
	public string ToJson() => default;
	public void OverrideFromJson(string json) {}
	public bool SaveToFile(string filename = "") => default;
	public bool LoadFromFile(string filename = "") => default;
	private string getFullpath(string filename = "") => default;
}
