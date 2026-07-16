// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.UpgradeQueue
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildEventInQueue : ObservableModel
	{
		// Fields
		[ObservableValue]
		private BuildEvent _buildEvent;
		[ObservableValue]
		private int _startTime;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private float _progress;
	
		// Properties
		[ObservableValue]
		public BuildEvent buildEvent { get => default; set {} }
		[ObservableValue]
		public int startTime { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public float progress { get => default; set {} }
	
		// Constructors
		public BuildEventInQueue(BuildEvent buildEvent) {}
		public BuildEventInQueue() {}
	
		// Methods
		public void UpdateProgress(int timestamp) {}
	}
