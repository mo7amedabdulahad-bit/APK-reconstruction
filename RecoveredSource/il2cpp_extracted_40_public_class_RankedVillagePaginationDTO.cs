	public class RankedVillagePaginationDTO
	{
		// Fields
		public int? totalCount;
		public List<RankedVillageEdgeDTO> edges;
		public PageInfoDTO pageInfo;
	
		// Constructors
		public RankedVillagePaginationDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
