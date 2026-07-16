// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ObjectPool<T>
	{
		// Fields
		private Queue<T> instances;
		private readonly Func<T> _createFunc;
		private readonly Action<T> _leftPoolFunc;
		private readonly Action<T> _returnToPoolFunc;
	
		// Constructors
		public ObjectPool() {} // Dummy constructor
		public ObjectPool(Func<T> createFunc, Action<T> leftPoolFunc = null, Action<T> returnToPoolFunc = null, int initialSize = 0) {}
	
		// Methods
		public T Get() => default;
		public void Return(T instance) {}
		private void AddNewInstance() {}
	}
