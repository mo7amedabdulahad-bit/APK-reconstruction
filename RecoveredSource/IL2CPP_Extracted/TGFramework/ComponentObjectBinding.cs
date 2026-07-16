// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class ComponentObjectBinding : ComponentPropertyBinding
	{
		// Fields
		public bool useBooleanComparison;
	
		// Properties
		public abstract System.Type typeToWorkOn { get; }
	
		// Constructors
		protected ComponentObjectBinding() {}
	
		// Methods
		protected override bool IsTypeValidForBinding(System.Type typeToCheck) => default;
		protected override void AddPossibleBinding(UnityEngine.Component component, PropertyInfo info, string name, Modifier mod = Modifier.None, bool setAsMyBinding = false, string onlyTakeVectorPart = null) {}
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		protected abstract void UpdateTargetWithIndex(int index);
		public override void UpdateTarget() {}
	}
