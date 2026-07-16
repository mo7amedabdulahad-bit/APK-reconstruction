// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LayoutChangeListener : MonoBehaviour, ILayoutElement
	{
		// Fields
		public System.Action OnLayoutChange;
	
		// Properties
		public float minWidth { get; }
		public float preferredWidth { get; }
		public float flexibleWidth { get; }
		public float minHeight { get; }
		public float preferredHeight { get; }
		public float flexibleHeight { get; }
		public int layoutPriority { get; }
	
		// Constructors
		public LayoutChangeListener() {}
	
		// Methods
		public void CalculateLayoutInputHorizontal() {}
		public void CalculateLayoutInputVertical() {}
	}
