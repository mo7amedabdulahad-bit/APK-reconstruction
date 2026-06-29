	public class InjectablePlayerStatistics : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private PlayerStatistics _playerStatistics;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public PlayerStatistics playerStatistics { get => default; set {} }
	
		// Constructors
		public InjectablePlayerStatistics() {}
	}
