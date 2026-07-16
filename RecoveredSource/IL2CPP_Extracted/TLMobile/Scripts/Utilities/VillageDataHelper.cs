// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class VillageDataHelper
	{
		// Fields
		public const int BuildingsAidStart = 19;
		public const int MaxBuildingsAidForVillages = 50;
		private static readonly HashSet<Building.TypeId> ExcludedBuildingTypesForRearranging;
		private static readonly HashSet<BuildingSlotType> ExcludedBuildingSlotTypesForRearranging;
		private static readonly HashSet<Building.TypeId> ExcludedBuildingTypesForDemolish;
		private static readonly HashSet<BuildingSlotType> ExcludedBuildingSlotTypesForDemolish;
	
		// Constructors
		static VillageDataHelper() {}
	
		// Methods
		public static bool IsExcludedFromRearranging(Building.TypeId buildingTypeId) => default;
		public static bool IsExcludedFromRearranging(BuildingSlotType buildingSlotType) => default;
		public static bool IsExcludedFromDemolish(Building.TypeId buildingTypeId) => default;
		public static bool IsExcludedFromDemolish(BuildingSlotType buildingSlotType) => default;
	}
