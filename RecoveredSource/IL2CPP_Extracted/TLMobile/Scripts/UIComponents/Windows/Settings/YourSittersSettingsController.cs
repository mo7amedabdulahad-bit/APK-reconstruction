// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class YourSittersSettingsController : BaseSitterSettingsController
	{
		// Fields
		[ObservableValue]
		private bool _sitterSettingsChanged;
	
		// Properties
		[ObservableValue]
		public bool sitterSettingsChanged { get => default; set {} }
	
		// Constructors
		public YourSittersSettingsController() {}
	
		// Methods
		protected override void SyncSitters() {}
		[UICallable]
		public void AddSitter() {}
		private void DoAddSitter(Sitter sitter, System.Action callback) {}
		[UICallable]
		public void RemoveSitter(Sitter sitter) {}
		private void DoRemoveSitter(Sitter sitter) {}
		[UICallable]
		public void SaveSitterPermissionChanges() {}
		[UICallable]
		public void SetSitterSettingsChanged() {}
	}
