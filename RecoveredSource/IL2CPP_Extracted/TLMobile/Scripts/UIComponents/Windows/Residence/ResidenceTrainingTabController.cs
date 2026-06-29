// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Residence
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResidenceTrainingTabController : UnitsTrainingTabController
	{
		// Fields
		[ObservableValue]
		private bool _noMorePossible;
		private Expansion expansionInfo;
	
		// Properties
		[ObservableValue]
		public bool noMorePossible { get => default; set {} }
	
		// Constructors
		public ResidenceTrainingTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		public override void SetupCurrentVillage() {}
		public override int CalculateAvailableToBuild(TLMobile.Generated.GraphQL.Game.Resource currentResources, TLMobile.Generated.GraphQL.Game.Unit unit, ResourceAmounts blockedResources, float costMultiplicator = 1f, int maxAmount = 2147483647) => default;
		protected override void SetAmount() {}
	}
