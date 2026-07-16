	public class RankedPlayerPaginationQuery : IPaginatedDataQuery<RankedPlayer>
	{
		// Fields
		private readonly Ranking rankingToUse;
		private string askForName;
		private bool overrideForceFetch;
		private int? startFromRank;
	
		// Nested types
