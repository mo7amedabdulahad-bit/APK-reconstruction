// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class ViewModelWithPolling : TLMViewModel
	{
		// Fields
		protected static Dictionary<System.Type, Dictionary<FieldInfo, PollForUpdates>> fieldsWithPolling;
		private readonly Dictionary<IGraphQLFetchable, Dictionary<int, PollForUpdates>> currentlyPolled;
		private IGraphQLDataPollingManager pollingManager;
	
		// Nested types
		[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
		protected sealed class PollForUpdates : System.Attribute
		{
			// Properties
			public float PollingInterval { get; }
			public float PollingIntervalLowBandwidth { get; }
			public int QueryToUse { get; }
	
			// Constructors
			public PollForUpdates() {} // Dummy constructor
			public PollForUpdates(float pollingInterval, int queryType = 0, float pollingIntervalLowBandwidth = -1f) {}
		}
	
		// Constructors
		protected ViewModelWithPolling() {}
		static ViewModelWithPolling() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void SetupPollingForThisViewModel(IGraphQLDataPollingManager pollingManagerInstance) {}
		public void StartPollingOnFieldsWithAttribute() {}
		private void UpdatePolledObjects() {}
		public void PausePollingOnFieldsWithAttribute() {}
		private Dictionary<FieldInfo, PollForUpdates> GetFieldsWithPollingAttributes() => default;
	}
