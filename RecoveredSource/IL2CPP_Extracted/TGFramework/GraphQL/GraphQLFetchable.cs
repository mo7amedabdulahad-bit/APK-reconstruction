// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.GraphQL
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class GraphQLFetchable : GraphQLServerObject, IFetchableServerObject, IGraphQLFetchable
	{
		// Fields
		private readonly Dictionary<int, List<System.Action>> OneTimeObservers;
	
		// Properties
		public virtual int NestedDepth { get; set; }
		public ServerObjectInfos ObjectInfos { get; }
	
		// Constructors
		protected GraphQLFetchable() {}
	
		// Methods
		public abstract string[] GetNamesInNestedResponse();
		public abstract void Update(int queryType = 0);
		public void UpdateIfOlderThan(float ensureNotOlderThan = 600f, int queryType = 0) {}
		public bool IsOlderThan(float ensureNotOlderThan = 600f, int queryType = 0) => default;
		public virtual string GetServerId() => default;
		protected void ObserveOnce(int query, System.Action action, bool onlyReactOnServerData = true) {}
		protected void StopObserveOnce(int query, System.Action action) {}
		public void ResolveOneTimeObservers(int query) {}
		private void CallCallback(System.Action action) {}
	}
