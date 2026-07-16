// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.ViewTransitions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class ViewTransition
	{
		// Fields
		public System.Action TransitionEnd;
		public System.Action TransitionStart;
		public System.Action ViewChange;
	
		// Constructors
		protected ViewTransition() {}
	
		// Methods
		public abstract void BeginTransition(bool scaled = false);
	}
