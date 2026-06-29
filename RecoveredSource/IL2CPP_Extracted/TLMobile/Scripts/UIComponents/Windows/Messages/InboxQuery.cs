// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InboxQuery : DefaultMessageQuery
	{
		// Fields
		private readonly IncomingMessagesFilter filter;
	
		// Constructors
		public InboxQuery() {} // Dummy constructor
		public InboxQuery(IncomingMessagesFilter filter) {}
	
		// Methods
		public override IPaginatedObject<TLMobile.Generated.GraphQL.Game.Message> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
	}
