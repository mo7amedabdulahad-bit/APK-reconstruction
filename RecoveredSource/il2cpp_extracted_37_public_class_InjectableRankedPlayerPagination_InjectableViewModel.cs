	public class InjectableRankedPlayerPagination : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private RankedPlayerPagination _rankedPlayerPagination;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public RankedPlayerPagination rankedPlayerPagination { get => default; set {} }
	
		// Constructors
		public InjectableRankedPlayerPagination() {}
	}
