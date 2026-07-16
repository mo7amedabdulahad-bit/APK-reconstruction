// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GraphQLObjectInfos
	{
		// Fields
		private Dictionary<int, long> updateTimes;
		public bool saveLastRawData;
		public string lastReceivedJsonString;
		public object lastReceivedDtoObject;
	
		// Properties
		public List<int> OutstandingQueryTypes { get; }
		public List<ExpectedResponse> ExpectedResponses { get; }
	
		// Nested types
		public class ExpectedResponse
		{
			// Properties
			public string RequestAlias { get; set; }
			public int Query { get; set; }
	
			// Constructors
			public ExpectedResponse() {} // Dummy constructor
			public ExpectedResponse(string requestAlias, int query) {}
		}
	
		// Constructors
		public GraphQLObjectInfos() {}
	
		// Methods
		public long GetLastUpdateTime(int queryType) => default;
		public void SetLastUpdateTime(int queryType, long timestampOfLastUpdate) {}
	}
