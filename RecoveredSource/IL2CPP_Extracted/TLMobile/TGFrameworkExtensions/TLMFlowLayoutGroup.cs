// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.TGFrameworkExtensions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TLMFlowLayoutGroup : FlowLayoutGroup
	{
		// Fields
		[SerializeField]
		private bool adjustToRTL;
		private TextAnchor? textAnchorLTR;
		private RectOffset originalPadding;
	
		// Constructors
		public TLMFlowLayoutGroup() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void OnLanguageChanged(bool isRTL) {}
		private void ApplyRTL(bool rtl) {}
	}
