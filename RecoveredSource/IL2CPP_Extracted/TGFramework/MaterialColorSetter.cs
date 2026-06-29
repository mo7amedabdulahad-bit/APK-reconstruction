// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MaterialColorSetter : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private int materialNumber;
		private Material[] materials;
		private Material[] originalMaterials;
		private Material originalMaterial;
		private UnityEngine.Color originalColor;
		private float originalFloatValue;
		private float originalFloatValue2;
		private Renderer myRenderer;
		[Header("Use a Component Color Binding to set the color dynamically.")]
		[SerializeField]
		private UnityEngine.Color _color;
		[SerializeField]
		private string _colorPropertyName;
		[SerializeField]
		private string _floatPropertyName;
		[SerializeField]
		private float _floatValue;
		[SerializeField]
		private string _floatPropertyName2;
		[SerializeField]
		private float _floatValue2;
		private static Dictionary<Material, Dictionary<int, Material>> materialCache;
	
		// Properties
		public UnityEngine.Color color { get => default; set {} }
		public string colorPropertyName { get => default; set {} }
		public string floatPropertyName { get => default; set {} }
		public float floatValue { get => default; set {} }
		public string floatPropertyName2 { get => default; set {} }
		public float floatValue2 { get => default; set {} }
	
		// Constructors
		public MaterialColorSetter() {}
		static MaterialColorSetter() {}
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init() {}
		private void UpdateMaterial() {}
		private void Awake() {}
		public void Reset() {}
	}
