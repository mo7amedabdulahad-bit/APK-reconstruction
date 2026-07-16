	public class InjectableVillageRaidLists : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private VillageRaidLists _villageRaidLists;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public VillageRaidLists villageRaidLists { get => default; set {} }
	
		// Constructors
		public InjectableVillageRaidLists() {}
	}
