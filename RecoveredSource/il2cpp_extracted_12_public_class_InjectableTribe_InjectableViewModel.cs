	public class InjectableTribe : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private Tribe _tribe;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public Tribe tribe { get => default; set {} }
	
		// Constructors
		public InjectableTribe() {}
	}
