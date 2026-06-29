// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsMovementOverview : ObservableModel, IBackendUpdateable, ITimedUpdater, IDisposable
	{
		// Fields
		private static readonly DynamicInterval PollingInterval;
		private static readonly DynamicInterval PollingIntervalAtLowBandwidth;
		private static TroopsMovementOverview instance;
		private readonly List<IPromise<MovingTroopConnection>> allPromises;
		private readonly MovingTroopsFilter incomingAttackFilter;
		private readonly MovingTroopsFilter incomingReinforcementFilter;
		private readonly MovingTroopsFilter outgoingAttacksFilter;
		private readonly MovingTroopsFilter outgoingReinforcementFilter;
		private readonly MovingTroopsFilter returningTroopsFilter;
		[ObservableValue]
		private Generated.GraphQL.Game.TroopsOverview _troopsOverview;
		[ObservableValue]
		private bool _anyMovement;
		[ObservableValue]
		private int _nextMovement;
		[ObservableValue]
		private ObservableList<MovementInfo> _movementInfos;
		private MovingTroopConnection incomingAttack;
		private MovingTroopConnection incomingReinforcement;
		private MovingTroopConnection outgoingAttack;
		private MovingTroopConnection outgoingReinforcement;
		private MovingTroopConnection returningTroops;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public Generated.GraphQL.Game.TroopsOverview troopsOverview { get => default; set {} }
		[ObservableValue]
		public bool anyMovement { get => default; set {} }
		[ObservableValue]
		public int nextMovement { get => default; set {} }
		[ObservableValue]
		public ObservableList<MovementInfo> movementInfos { get => default; set {} }
	
		// Constructors
		public TroopsMovementOverview() {}
		static TroopsMovementOverview() {}
	
		// Methods
		public void Update(int query = 0) {}
		int ITimedUpdater.GetRequiredUpdateTime() => default;
		public static TroopsMovementOverview Get() => default;
		public static void ResetInstance() {}
		public void Init() {}
		private void OnLoggedOut() {}
		private void CurrentVillageChanged(OwnVillage currentVillage) {}
		private int CompareMovements(MovementInfo a, MovementInfo b) => default;
		private void TriggerUpdate() {}
		[Testable]
		private void UpdateTroopMovementData(OwnVillage currentVillage) {}
		private void SetupMovementInformationCollection() {}
		private void SetupPromises(OwnVillage currentVillage, ICollection<IPromise<MovingTroopConnection>> allPromises) {}
		private void UpdateAnyMovementFlag() {}
		private static int? GetFirstArrivalTime(MovingTroopConnection movingTroopConnection) => default;
		public void Dispose() {}
		private void _movementInfosNotify(object sender, PropertyChangedEventArgs args) {}
	}
