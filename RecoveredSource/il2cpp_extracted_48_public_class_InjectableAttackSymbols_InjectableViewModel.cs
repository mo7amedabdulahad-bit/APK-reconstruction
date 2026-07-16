	public class InjectableAttackSymbols : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private AttackSymbols _attackSymbols;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public AttackSymbols attackSymbols { get => default; set {} }
	
		// Constructors
		public InjectableAttackSymbols() {}
	}
