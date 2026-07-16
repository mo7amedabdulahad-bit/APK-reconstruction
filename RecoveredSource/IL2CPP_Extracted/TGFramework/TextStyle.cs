// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextStyle : MonoBehaviour
	{
		// Fields
		public FontStyleCfg style;
		public FontStyleOverride fontStyleOverride;
		[HideInInspector]
		[Obsolete]
		public UnityEngine.Color multiplyColor;
		[HideInInspector]
		[Obsolete]
		public UnityEngine.Color addColor;
		[HideInInspector]
		[Obsolete]
		public float multiplyFontSize;
		[HideInInspector]
		[Obsolete]
		public float addFontSize;
		[HideInInspector]
		[Obsolete]
		public float addLineHeight;
		private Wrapper textWrapper;
		private TextMeshHelper.Properties properties;
		private TextMeshProUGUI is2dText;
		private static Dictionary<Material, Material> copiedMaterials;
	
		// Properties
		public FontStyleCfg UsedStyle { get => default; set {} }
		public UnityEngine.Color MultiplyColor { get => default; set {} }
		public UnityEngine.Color AddColor { get => default; set {} }
	
		// Constructors
		public TextStyle() {}
		static TextStyle() {}
	
		// Methods
		public void Awake() {}
		private Material GetMaterialCopyFor2D(Material original) => default;
		public Wrapper GetWrapper() => default;
		public void UpdateText() {}
	}
