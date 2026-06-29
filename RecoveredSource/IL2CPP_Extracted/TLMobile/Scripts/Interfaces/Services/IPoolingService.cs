// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IPoolingService : IService
	{
		// Properties
		ReadOnlyDictionary<System.Type, Transform> PoolsParentTransform { get; }
	
		// Methods
		void CreatePool<T>(int startingPoolSize, int newPoolBatchSize, Transform poolParentTransform, T pooledObjectPrefab)
			where T : UnityEngine.Component;
		void ClearPool<T>()
			where T : UnityEngine.Component;
		void AddToPool<T>(T objectToAdd)
			where T : UnityEngine.Component;
		void AddRangeToPool<T>(List<T> newObjects)
			where T : UnityEngine.Component;
		T GetObject<T>()
			where T : UnityEngine.Component;
		int GetCurrentPoolSize<T>()
			where T : UnityEngine.Component;
	}
