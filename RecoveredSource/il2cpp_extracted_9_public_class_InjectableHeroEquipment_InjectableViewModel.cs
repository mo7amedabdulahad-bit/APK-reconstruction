	public class InjectableHeroEquipment : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private HeroEquipment _heroEquipment;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public HeroEquipment heroEquipment { get => default; set {} }
	
		// Constructors
		public InjectableHeroEquipment() {}
	}
