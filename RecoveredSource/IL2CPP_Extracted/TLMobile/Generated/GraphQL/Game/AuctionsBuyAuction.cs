// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionsBuyAuction : AuctionInterface, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _highestBidder;
		[ObservableValue]
		private int _minBid;
		[ObservableValue]
		private HighestBidderTag _highestBidderTag;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player highestBidder { get => default; set {} }
		[ObservableValue]
		public int minBid { get => default; set {} }
		[ObservableValue]
		public HighestBidderTag highestBidderTag { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AuctionsBuyAuction() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionsBuyAuctionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionsBuyAuctionDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static AuctionsBuyAuction GetById(object dtoObject) => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
