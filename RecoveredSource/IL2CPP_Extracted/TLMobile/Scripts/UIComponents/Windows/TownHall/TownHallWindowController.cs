// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TownHall
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TownHallWindowController : BuildingDetailWindowController
	{
		// Fields
		[ObservableValue]
		private Generated.GraphQL.Game.TownHall _townHall;
		[ObservableValue]
		private ObservableList<CelebrationWithError> _celebrationWithErrors;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Resource _resources;
		[ObservableValue]
		private bool _isCityEnabled;
	
		// Properties
		[ObservableValue]
		public Generated.GraphQL.Game.TownHall townHall { get => default; set {} }
		[ObservableValue]
		public ObservableList<CelebrationWithError> celebrationWithErrors { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Resource resources { get => default; set {} }
		[ObservableValue]
		public bool isCityEnabled { get => default; set {} }
	
		// Constructors
		public TownHallWindowController() {}
	
		// Methods
		private void _celebrationWithErrorsNotify(object sender, PropertyChangedEventArgs args) {}
		[Testable]
		protected override void UpdateBuildingData(OwnVillage newVillage) {}
		private void ObserveOnCurrentVillage() {}
		private void StopObservingCurrentVillage() {}
		private void UpdateTownHall() {}
		public void UpdateCelebrations() {}
		private void UpdateErrors() {}
		[UICallable]
		public void StartCelebration(Celebration celebration) {}
	}
