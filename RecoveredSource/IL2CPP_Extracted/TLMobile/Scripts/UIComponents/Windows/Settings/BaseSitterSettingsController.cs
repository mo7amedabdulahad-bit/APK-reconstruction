// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class BaseSitterSettingsController : TLMViewModel
	{
		// Fields
		[SerializeField]
		protected int maxSitters;
		[ObservableValue]
		protected ObservableList<Sitter> _newSitterSettings;
	
		// Properties
		[ObservableValue]
		public ObservableList<Sitter> newSitterSettings { get; set; }
	
		// Constructors
		protected BaseSitterSettingsController() {}
	
		// Methods
		private void _newSitterSettingsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		private void UpdateSitters() {}
		protected abstract void SyncSitters();
		protected void UpdateNewSitterSettings(ServerObject serverObject) {}
	}
