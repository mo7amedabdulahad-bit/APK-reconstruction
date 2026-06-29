// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Layout3D : Layout3DElement
	{
		// Fields
		public float spacing;
		public Direction direction;
		public Positioning positioning;
		private float otherDirectionForcedFactor;
		private List<Layout3DElement> elements;
		private List<float> savedPreferedSize;
		private List<float> savedPreferedOtherSize;
		private int savedChildObjects;
		private Direction oldDirection;
		private Positioning oldPositioning;
		private float oldSpacing;
		private bool initialized;
	
		// Nested types
		public enum Direction
		{
			Horizontal = 0,
			Vertical = 1
		}
	
		public enum Positioning
		{
			Start = 0,
			Center = 1,
			End = 2
		}
	
		// Constructors
		public Layout3D() {}
	
		// Methods
		private void Awake() {}
		private void Update() {}
		private void RequestUpdateCheck() {}
		protected void ChildGotUpdated(Layout3DElement child) {}
		private void OnDestroy() {}
		private void CheckLayout() {}
	}
