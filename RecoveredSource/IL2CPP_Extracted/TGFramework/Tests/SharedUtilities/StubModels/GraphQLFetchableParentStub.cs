// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Tests.SharedUtilities.StubModels
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GraphQLFetchableParentStub : GraphQLFetchableStub
	{
		// Properties
		[ObservableValue]
		public int IntParentProperty { get; set; }
		[ObservableValue]
		public string StringParentProperty { get; set; }
		[ObservableValue]
		public GraphQLFetchableChildStub ChildStub { get; set; }
	
		// Constructors
		public GraphQLFetchableParentStub() {}
		public GraphQLFetchableParentStub(string serverId) {}
	
		// Methods
		private List<string> GetFetchedServerIdsFlexible() => default;
	}
