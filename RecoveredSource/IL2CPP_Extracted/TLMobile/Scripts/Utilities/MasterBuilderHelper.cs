// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class MasterBuilderHelper
	{
		// Fields
		public const int MaxTasksForMasterBuilder = 3;
		private const int MaxSlotsForPlusMemberRomanTribe = 3;
		private const int MaxSlotsForFreeMemberRomanTribe = 2;
		private const int MaxSlotsForPlusMemberOtherTribes = 2;
		private const int MaxSlotsForFreeMemberOtherTribes = 1;
	
		// Methods
		public static void GetMasterBuilderState(OwnPlayer ownPlayer, Building.TypeId currentBuildingType, out bool masterBuilderVisible, out bool masterBuilderFull) {
			masterBuilderVisible = default;
			masterBuilderFull = default;
		}
		private static bool HandleRomanTribeBonus(Building.TypeId currentBuildingType, bool isTravianPlus, int totalBuildEventsInQueue, int totalResourceBuildEventsInQueue, int totalBuildingBuildEventsInQueue) => default;
		private static bool IsResourceField(Building.TypeId typeId) => default;
	}
