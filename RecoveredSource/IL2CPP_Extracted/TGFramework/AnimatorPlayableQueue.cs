// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AnimatorPlayableQueue
	{
		// Fields
		private const float VerticalSortTolerance = 0.05f;
		private readonly Queue<AnimatorPlayable> queue;
	
		// Properties
		public int Count { get => default; }
	
		// Constructors
		public AnimatorPlayableQueue() {}
	
		// Methods
		public bool Enqueue(AnimatorPlayable entry) => default;
		public AnimatorPlayable Dequeue() => default;
		public AnimatorPlayable Peek() => default;
		public bool Remove(AnimatorPlayable entry) => default;
		private void StartQueue() {}
		private void SortQueue() {}
		private void ScheduleNext(float timeCredit = 0f) {}
		private void ProcessQueueHead(float timeCredit) {}
	}
