// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CroplandsFilterDTO
	{
		// Fields
		[Nullable(2)]
		public StartPosition startPosition;
		public CroplandType? type;
		public CroplandBonus? minBonus;
		public bool? onlyFree;
		public GreyZoneFilter? greyZone;
		public MapQuadrant? quadrant;
	
		// Constructors
		public CroplandsFilterDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
