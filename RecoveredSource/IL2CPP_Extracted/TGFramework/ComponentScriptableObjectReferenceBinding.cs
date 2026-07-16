// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ComponentScriptableObjectReferenceBinding : ComponentObjectBinding
	{
		// Fields
		[SerializeField]
		public AssetReferenceT<ScriptableObject>[] availableSOs;
	
		// Properties
		public override System.Type typeToWorkOn { get => default; }
	
		// Constructors
		public ComponentScriptableObjectReferenceBinding() {}
	
		// Methods
		protected override void UpdateTargetWithIndex(int index) {}
		private async void LoadSO(AssetReference reference) {}
		private void UpdateScriptableObject(ScriptableObject so) {}
	}
