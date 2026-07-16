// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FloatingResourcesController : ToggledPanel
	{
		// Fields
		[SerializeField]
		private bool startsOpen;
		private bool skippedFirstTrigger;
	
		// Constructors
		public FloatingResourcesController() {}
	
		// Methods
		protected override void Awake() {}
		[UICallable]
		public void TriggerTimedResourcesVisibility() {}
		[UICallable]
		public void ToggleResourcesExpanded() {}
		public void ExpandPanel() {}
	}
