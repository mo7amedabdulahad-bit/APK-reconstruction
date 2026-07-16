// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.ConstructImmediately
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingInProgress : ObservableModel
	{
		// Fields
		[ObservableValue]
		private int _buildingTypeId;
		[ObservableValue]
		private int _buildingSpriteIndex;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private bool _canBeCompleted;
		[ObservableValue]
		private int _endTimestamp;
	
		// Properties
		[ObservableValue]
		public int buildingTypeId { get => default; set {} }
		[ObservableValue]
		public int buildingSpriteIndex { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public bool canBeCompleted { get => default; set {} }
		[ObservableValue]
		public int endTimestamp { get => default; set {} }
	
		// Constructors
		public BuildingInProgress() {}
	}
