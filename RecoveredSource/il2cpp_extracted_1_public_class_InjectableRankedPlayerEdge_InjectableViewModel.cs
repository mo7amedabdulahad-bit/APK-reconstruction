	public class InjectableRankedPlayerEdge : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private RankedPlayerEdge _rankedPlayerEdge;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public RankedPlayerEdge rankedPlayerEdge { get => default; set {} }
	
		// Constructors
		public InjectableRankedPlayerEdge() {}
	}
