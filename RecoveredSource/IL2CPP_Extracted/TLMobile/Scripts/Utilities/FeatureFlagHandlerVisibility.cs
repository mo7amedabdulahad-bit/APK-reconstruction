// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FeatureFlagHandlerVisibility : TGFramework.Visibility
	{
		// Fields
		public bool inverted;
		public bool additionalConditions;
		public LogicConnector additionalConditionsConnector;
		public FeatureFlagDictionary serializedData;
		private ServerSupportedFeatures serverSupportedFeatures;
	
		// Constructors
		public FeatureFlagHandlerVisibility() {}
	
		// Methods
		public override void Start() {}
		public override void UpdateTarget() {}
		protected override bool EvaluateLogics() => default;
		public override bool BindingSuccessfulInEditor() => default;
		private bool CheckHandlerState(out FeatureFlagWrapper wrapper) {
			wrapper = default;
			return default;
		}
	}
