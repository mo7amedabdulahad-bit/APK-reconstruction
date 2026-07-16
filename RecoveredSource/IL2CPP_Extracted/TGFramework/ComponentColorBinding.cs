// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ComponentColorBinding : ComponentObjectBinding
	{
		// Fields
		public ColorCfg colorsFromConfig;
		[SerializeField]
		public UnityEngine.Color[] availableColors;
		[SerializeField]
		public IntColorDictionary availableColorsDict;
		public UnityEngine.Color _multiplyColor;
		public UnityEngine.Color _addColor;
	
		// Properties
		public override System.Type typeToWorkOn { get => default; }
		public ColorCfg colorConfigSetter { set {} }
		public UnityEngine.Color multiplyColor { get => default; set {} }
		public UnityEngine.Color addColor { get => default; set {} }
	
		// Constructors
		public ComponentColorBinding() {}
	
		// Methods
		protected override void UpdateTargetWithIndex(int index) {}
	}
