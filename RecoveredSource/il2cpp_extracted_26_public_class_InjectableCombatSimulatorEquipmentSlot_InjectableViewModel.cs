	public class InjectableCombatSimulatorEquipmentSlot : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private CombatSimulatorEquipmentSlot _combatSimulatorEquipmentSlot;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public CombatSimulatorEquipmentSlot combatSimulatorEquipmentSlot { get => default; set {} }
	
		// Constructors
		public InjectableCombatSimulatorEquipmentSlot() {}
	}
