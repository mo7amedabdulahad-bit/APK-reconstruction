// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.SceneInclude
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SceneIncludeAnchor : MonoBehaviour
	{
		// Fields
		[Help("This GameObject here will be transferred to the other scene. Optionally you can define an anchorObject on your own, but that is really not needed.")]
		public GameObject anchorObject;
	
		// Events
		public event System.Action AnchorIncluded;
	
		// Constructors
		public SceneIncludeAnchor() {}
	
		// Methods
		public void Awake() {}
		public void AnchorWasIncluded() {}
	}
