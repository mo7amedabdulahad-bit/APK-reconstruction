// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DebuggingService : MonoBehaviour, IDebuggingService
	{
		// Fields
		private const float MemoryWarningThreshold = 0.1f;
		private const float MemoryErrorThreshold = 0.02f;
		private const float MemoryUsageRepeatCallInterval = 10f;
		private long launchManagedMemory;
		private long launchTotalAllocatedMemory;
		private long launchTotalReservedMemory;
		private long launchTotalUnusedReservedMemory;
		private long managedMemory;
		private int systemMemorySize;
		private long totalAllocatedMemory;
		private long totalReservedMemory;
		private long totalUnusedReservedMemory;
		private long unmanagedMemory;
	
		// Constructors
		public DebuggingService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		private void CheckMemoryUsage() {}
		private void OnLowMemory() {}
		private void TryToFreeMemory() {}
		private string GetMemorySnapShot() => default;
		private string FormatBytesToMB(long bytes) => default;
	}
