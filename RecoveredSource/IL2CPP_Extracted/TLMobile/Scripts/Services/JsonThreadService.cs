// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class JsonThreadService : MonoBehaviour, IJsonThreadService, IDisposable
	{
		// Fields
		private static JsonThreadService instance;
		private readonly ConcurrentQueue<Job> jobQueue;
		private readonly ConcurrentQueue<Job> pendingMainThreadCallbacks;
		private CancellationTokenSource cancellationTokenSource;
		private System.Threading.Tasks.Task workerTask;
		private readonly object taskLock;
		private bool disposed;
	
		// Properties
		public static JsonThreadService Instance { get => default; }
		public int WorkTotalCount { get => default; }
	
		// Nested types
		private class Job
		{
			// Fields
			public Action<object> callback;
			public string json;
			public object result;
			public System.Type type;
	
			// Constructors
			public Job() {}
		}
	
		// Constructors
		public JsonThreadService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void PauseChanged(bool isPaused) {}
		private void FocusChanged(bool hasFocus) {}
		private void TryOnResume() {}
		private void OnApplicationQuit() {}
		public void Dispose() {}
		protected virtual void Dispose(bool disposing) {}
		public void Add(System.Type t, string json, Action<object> callback) {}
		private System.Threading.Tasks.Task ProcessJobs() => default;
	}
