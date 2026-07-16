// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class AnimatorPlayable : MonoBehaviour
	{
		// Fields
		private static readonly AnimatorPlayableQueue delayQueue;
		[SerializeField]
		private bool autoStart;
		[SerializeField]
		private float playDelay;
		[SerializeField]
		private bool useDelayQueue;
	
		// Properties
		public abstract bool IsPlaying { get; }
		public float PlayDelay { get; }
	
		// Constructors
		protected AnimatorPlayable() {}
		static AnimatorPlayable() {}
	
		// Methods
		protected virtual void OnEnable() {}
		protected virtual void OnDisable() {}
		public void Play() {}
		public abstract void PlayWithoutDelay();
		public abstract void Stop();
		protected abstract void ResetAnimationValues();
	}
