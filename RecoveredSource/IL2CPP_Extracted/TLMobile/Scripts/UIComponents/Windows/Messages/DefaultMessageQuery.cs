// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class DefaultMessageQuery : IPaginatedDataQuery<TLMobile.Generated.GraphQL.Game.Message>
	{
		// Constructors
		protected DefaultMessageQuery() {}
	
		// Methods
		public virtual IPaginatedObject<TLMobile.Generated.GraphQL.Game.Message> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public virtual IPaginatedObject<TLMobile.Generated.GraphQL.Game.Message> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public virtual IPaginatedObject<TLMobile.Generated.GraphQL.Game.Message> GetPageForResult(ServerObject obj) => default;
	}
