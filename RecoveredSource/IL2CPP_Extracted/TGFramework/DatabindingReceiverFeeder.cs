// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DatabindingReceiverFeeder : Databinding
	{
		// Fields
		public InjectableViewModel receiver;
		public List<Injectable> injectableValues;
		private static Dictionary<System.Type, List<Injectable>> cachedInjectableInfos;
	
		// Nested types
		public class Injectable
		{
			// Fields
			public string name;
			public MemberInfoWrapper info;
			public InjectableValue definition;
	
			// Constructors
			public Injectable() {}
		}
	
		// Constructors
		public DatabindingReceiverFeeder() {}
		static DatabindingReceiverFeeder() {}
	
		// Methods
		public override void Init(bool forceInit = false) {}
		protected override bool BindingSuccessful() => default;
		public void InjectValue(object value, int variableNumber = 0) {}
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		public override void UpdateTarget() {}
		public void OverrideBoundObject(int index, BindableObject obj) {}
	}
