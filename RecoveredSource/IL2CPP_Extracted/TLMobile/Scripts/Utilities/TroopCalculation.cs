// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class TroopCalculation
	{
		// Methods
		public static List<ShipAmount.ShipId> GetAllowedShipTypesForTroops(SelectableAmounts units, AttackType attackType) => default;
		public static int? GetBestSuitedShip(SelectableAmounts units, AttackType attackType, Dictionary<ShipAmount.ShipId, int> availableShips) => default;
		public static void ValidateAssignedShipForWave(SelectedAmountWithSendInfo wave, AttackType attackType) {}
		public static bool HasValidShipForWave(SelectedAmountWithSendInfo wave, AttackType attackType, Dictionary<ShipAmount.ShipId, int> availableShips) => default;
		public static ShipAmount.ShipId GetRecommendedShip(SelectedAmountWithSendInfo wave, AttackType attackType) => default;
	}
