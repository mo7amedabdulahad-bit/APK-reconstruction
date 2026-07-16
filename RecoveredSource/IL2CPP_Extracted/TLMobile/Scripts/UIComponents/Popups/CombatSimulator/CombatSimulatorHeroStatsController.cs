// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorHeroStatsController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private int _combatSimulatorHealth;
		[ObservableValue]
		private CombatSimulatorHero _combatSimulatorHero;
		[ObservableValue]
		private ObservableList<HeroAttributeItem> _heroAttributes;
		private Action<CombatSimulatorHero> callback;
		private OwnHero realHero;
		private CombatSimulatorParticipant.Role role;
	
		// Properties
		[ObservableValue]
		public int combatSimulatorHealth { get => default; set {} }
		[ObservableValue]
		public CombatSimulatorHero combatSimulatorHero { get => default; set {} }
		[ObservableValue]
		public ObservableList<HeroAttributeItem> heroAttributes { get => default; set {} }
	
		// Constructors
		public CombatSimulatorHeroStatsController() {}
	
		// Methods
		private void _heroAttributesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(CombatSimulatorHero hero, CombatSimulatorParticipant.Role role, Action<CombatSimulatorHero> callback) {}
		private void AttributePointInputChanged() {}
		private void HealthInputChanged() {}
		[UICallable]
		public void SaveHeroStats() {}
	}
