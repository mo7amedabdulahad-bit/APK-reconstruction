// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.BreweryWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BreweryWindowController : BuildingDetailWindowController
	{
		// Fields
		[ObservableValue]
		private float _effectValue;
		[ObservableValue]
		private Brewery _brewery;
		[ObservableValue]
		private GeneralErrorType _errorType;
		[ObservableValue]
		private long _enoughResourcesTime;
		[ObservableValue]
		private ResourcesCostInfo _resourcesCostInfo;
	
		// Properties
		[ObservableValue]
		public float effectValue { get => default; set {} }
		[ObservableValue]
		public Brewery brewery { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType errorType { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTime { get => default; set {} }
		[ObservableValue]
		public ResourcesCostInfo resourcesCostInfo { get => default; set {} }
	
		// Constructors
		public BreweryWindowController() {}
	
		// Methods
		[Testable]
		protected override void UpdateBuildingData(OwnVillage newVillage) {}
		private void ObserveOnCurrentVillage() {}
		private void StopObservingCurrentVillage() {}
		private void UpdateResourcesInfo() {}
		[Testable]
		private void UpdateError() {}
		private void UpdateBrewery() {}
		[UICallable]
		public void StartCelebration() {}
	}
