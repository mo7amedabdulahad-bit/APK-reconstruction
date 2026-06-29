// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Residence
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CapitalChangeToggleButtonController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private bool _madeRequest;
		private ChangeCapitalPopupController capitalController;
		private OwnPlayer ownPlayer;
		private OwnVillage village;
	
		// Properties
		[ObservableValue]
		public bool madeRequest { get => default; set {} }
	
		// Constructors
		public CapitalChangeToggleButtonController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDestroy() {}
		private void OnMainVillageChanged() {}
		private void ChangeMadeRequest(bool value) {}
		private void OnRequest(CapitalChangeRequestState state) {}
		[UICallable]
		public virtual DetailWindowController ShowCapitalChangePopup() => default;
	}
