// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PoolingService : MonoBehaviour, IPoolingService
	{
		// Fields
		private readonly Dictionary<System.Type, int> newPoolBatchSizes;
		private readonly Dictionary<System.Type, List<UnityEngine.Component>> pooledObjects;
		private readonly Dictionary<System.Type, UnityEngine.Component> pooledObjectsPrefab;
		private readonly Dictionary<System.Type, Transform> poolsParentTransform;
	
		// Properties
		public ReadOnlyDictionary<System.Type, Transform> PoolsParentTransform { get => default; }
	
		// Constructors
		public PoolingService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void CreatePool<T>(int startingPoolSize, int newPoolBatchSize, Transform poolParentTransform, T pooledObjectPrefab)
			where T : UnityEngine.Component {}
		public void ClearPool<T>()
			where T : UnityEngine.Component {}
		public void AddToPool<T>(T objectToAdd)
			where T : UnityEngine.Component {}
		public void AddRangeToPool<T>(List<T> newObjects)
			where T : UnityEngine.Component {}
		public T GetObject<T>()
			where T : UnityEngine.Component => default;
		public int GetCurrentPoolSize<T>()
			where T : UnityEngine.Component => default;
		private void CreateNewPool<T>(int startingPoolSize)
			where T : UnityEngine.Component {}
		private void CreatePoolObject<T>()
			where T : UnityEngine.Component {}
		private void ResetPoolObject<T>(UnityEngine.Component objectToReset)
			where T : UnityEngine.Component {}
	}
