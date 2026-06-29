// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Barracks
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsTrainingListController : DetailWindowController
	{
		// Fields
		private readonly List<int> cancelledTrainingEvents;
		[ObservableValue]
		private ObservableList<TrainingBatch> _trainingTroops;
		[ObservableValue]
		private int _nextSolderReadyAt;
		[ObservableValue]
		private Building.TypeId _buildingType;
		private OwnVillage currentVillage;
		private Harbour harbour;
		private Hospital hospital;
		private Trapper trapper;
	
		// Properties
		[ObservableValue]
		public ObservableList<TrainingBatch> trainingTroops { get => default; set {} }
		[ObservableValue]
		public int nextSolderReadyAt { get => default; set {} }
		[ObservableValue]
		public Building.TypeId buildingType { get => default; set {} }
	
		// Constructors
		public TroopsTrainingListController() {}
	
		// Methods
		private void _trainingTroopsNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Setup(Building.TypeId buildingTypeId) {}
		protected override void OnDestroy() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void UpdateTrainingTroops() {}
		[UICallable]
		public void CancelTroopTraining(TrainingBatch batch) {}
		private void ForceRefreshList() {}
	}
