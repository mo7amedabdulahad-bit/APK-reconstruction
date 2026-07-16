// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Shared
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

public class TGLayoutElement : LayoutElement
{
	// Fields
	public float maxHeight;
	public float maxWidth;
	public bool useMaxWidth;
	public bool useMaxHeight;
	public LayoutGroup copyPreferredFromGroup;
	public LayoutElement copyPreferredFromLayout;
	public RectTransform copyMinHeightFromRect;
	private bool ignoreOnGettingPreferedSize;

	// Properties
	private ILayoutElement copyFrom { get => default; }
	public override int layoutPriority { get => default; set {} }
	public override float preferredHeight { get => default; set {} }
	public override float preferredWidth { get => default; set {} }
	public override float minHeight { get => default; set {} }

	// Constructors
	public TGLayoutElement() {}
}
