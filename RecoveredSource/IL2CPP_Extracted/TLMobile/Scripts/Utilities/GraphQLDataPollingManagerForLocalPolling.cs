// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GraphQLDataPollingManagerForLocalPolling : IGraphQLDataPollingManager
	{
		// Fields
		public const float PollingUpdateLoopInterval = 1f;
		private static GraphQLDataPollingManagerForLocalPolling instance;
		private readonly Dictionary<IGraphQLFetchable, Dictionary<int, PollingInfos>> registeredPolling;
		private PlayerAppSettings.BandwidthMode bandwidthMode;
	
		// Properties
		public IReadOnlyDictionary<IGraphQLFetchable, Dictionary<int, PollingInfos>> RegisteredPollingIntervalsForServerIds { get => default; }
		public Coroutine UpdateLoopCoroutine { get; }
		public static GraphQLDataPollingManagerForLocalPolling Instance { get => default; }
	
		// Nested types
		public sealed class PollingInfos
		{
			// Fields
			public List<float> intervals;
			public List<float> intervalsLowBandwidth;
			public int nextFetch;
	
			// Constructors
			public PollingInfos() {}
		}
	
		// Constructors
		private GraphQLDataPollingManagerForLocalPolling() {}
	
		// Methods
		public void AddToPolling(IGraphQLFetchable serverObject, float interval, int queryType = 0, float intervalLowBandwidth = -1f) {}
		public void RemoveFromPolling(IGraphQLFetchable serverObject, float interval, int queryType = 0, float intervalLowBandwidth = -1f) {}
		public static void ResetInstance() {}
		public void PrintOutState() {}
		[Conditional("DEBUG_POLLING")]
		private void PrintOutShortState() {}
		public void SetBandwidthMode(PlayerAppSettings.BandwidthMode mode) {}
		[IteratorStateMachine(typeof(_UpdateLoop_d__18))]
		private IEnumerator UpdateLoop() => default;
	}
