// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TownHall
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CelebrationWithError : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Celebration _celebration;
		[ObservableValue]
		private GeneralErrorType _errorType;
		[ObservableValue]
		private long _enoughResourcesTime;
		[ObservableValue]
		private ResourcesCostInfo _resourcesCostInfo;
	
		// Properties
		[ObservableValue]
		public Celebration celebration { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType errorType { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTime { get => default; set {} }
		[ObservableValue]
		public ResourcesCostInfo resourcesCostInfo { get => default; set {} }
	
		// Constructors
		[Obsolete("Only for data binding purposes")]
		public CelebrationWithError() {}
		public CelebrationWithError(Celebration celebration, TLMobile.Generated.GraphQL.Game.Resource resourceInVillage, int ongoingCelebrations) {}
	
		// Methods
		public void UpdateError(TLMobile.Generated.GraphQL.Game.Resource resourceInVillage, int ongoingCelebrations) {}
	}
