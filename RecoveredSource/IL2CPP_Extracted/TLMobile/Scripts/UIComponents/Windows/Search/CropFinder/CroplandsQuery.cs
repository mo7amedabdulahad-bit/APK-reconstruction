// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search.CropFinder
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CroplandsQuery : IPaginatedDataQuery<Cropland>
	{
		// Fields
		private readonly CroplandBonus? croplandBonus;
		private readonly int croplandsFirst;
		private readonly CroplandType? croplandType;
		private readonly bool onlyShowUnoccupied;
		private readonly StartPosition startPosition;
		private readonly GreyZoneFilter? greyZone;
		private readonly MapQuadrant? quadrant;
	
		// Constructors
		public CroplandsQuery() {} // Dummy constructor
		public CroplandsQuery(int croplandsFirst, StartPosition startPosition, CroplandType? croplandType, CroplandBonus? croplandBonus, bool onlyShowUnoccupied, GreyZoneFilter? greyZone, MapQuadrant? quadrant) {}
	
		// Methods
		public IPaginatedObject<Cropland> GetPaginationPage(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<Cropland> GetPaginationPageBefore(string cursor, int amount, bool forceRefresh = false) => default;
		public IPaginatedObject<Cropland> GetPageForResult(ServerObject obj) => default;
	}
