	public class AssetBundleProvider : ResourceProviderBase
	{
		// Fields
		internal static Dictionary<string, AssetBundleUnloadOperation> m_UnloadingBundles;
	
		// Properties
		protected internal static Dictionary<string, AssetBundleUnloadOperation> UnloadingBundles { get => default; internal set {} }
		internal static int UnloadingAssetBundleCount { get => default; }
		internal static int AssetBundleCount { get => default; }
	
		// Constructors
		public AssetBundleProvider() {}
		static AssetBundleProvider() {}
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init() {}
		internal static void WaitForAllUnloadingBundlesToComplete() {}
		public override void Provide(ProvideHandle providerInterface) {}
		public override System.Type GetDefaultType(IResourceLocation location) => default;
		public override void Release(IResourceLocation location, object asset) {}
		public virtual bool ShouldRetryDownloadError(UnityWebRequestResult uwrResult) => default;
		internal virtual IOperationCacheKey CreateCacheKeyForLocation(UnityEngine.ResourceManagement.ResourceManager rm, IResourceLocation location, System.Type desiredType) => default;
	}
