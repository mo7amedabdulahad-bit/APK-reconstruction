// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnityMainThreadDispatcher : MonoBehaviour, IDisposable
	{
		// Fields
		private static UnityMainThreadDispatcher instance;
		private static ConcurrentQueue<System.Action> executionQueue;
		private static Queue<System.Action> localQueue;
	
		// Properties
		public static UnityMainThreadDispatcher Instance { get => default; }
	
		// Constructors
		public UnityMainThreadDispatcher() {}
		static UnityMainThreadDispatcher() {}
	
		// Methods
		private void Update() {}
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init() {}
		public static void Enqueue(IEnumerator coroutine) {}
		public static void Enqueue(System.Action action) {}
		public static System.Threading.Tasks.Task EnqueueAsync(System.Action action) => default;
		public void Dispose() {}
	}
