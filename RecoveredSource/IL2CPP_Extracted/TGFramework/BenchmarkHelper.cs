// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class BenchmarkHelper
	{
		// Fields
		private static Stack<int> runningCategory;
		private static Stack<int> runningTypeHash;
		private static Stopwatch globalCPU1;
		private static Stopwatch globalCPU2;
		private static Stopwatch globalCPU3;
		private static Stopwatch globalCPU4;
		private static Stopwatch globalGPU;
		private static Stack<Stopwatch> runningBenchmarks;
		private static Dictionary<int, Dictionary<int, Stopwatch>> benchmarkPerType;
		private static Dictionary<int, Dictionary<int, int>> callsPerType;
		private static Dictionary<int, Dictionary<int, string>> typeToString;
		private static Dictionary<int, string> registeredCategories;
		private static bool didHookIntoPlayer;
		private static float lastTime;
		private static MonoBehaviour objToHookCoroutines;
	
		// Constructors
		static BenchmarkHelper() {}
	
		// Methods
		private static void Init() {}
		public static void WatchForFrameEnd(MonoBehaviour objectToHookTo) {}
		[IteratorStateMachine(typeof(_WaitFrameEnd_d__17))]
		private static IEnumerator WaitFrameEnd() => default;
		public static void Start(int category, object something) {}
		private static bool Start(int category, int typeHash) => default;
		public static void Stop() {}
		public static void Reset() {}
		public static void RegisterCategory(int category, string name) {}
		public static void OutputAndReset() {}
	}
