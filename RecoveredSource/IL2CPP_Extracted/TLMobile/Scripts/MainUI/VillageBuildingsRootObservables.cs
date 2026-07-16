// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageBuildingsRootObservables : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private Academy _academy;
		[ObservableValue]
		private Smithy _smithy;
		private OwnVillage ownVillage;
	
		// Properties
		[ObservableValue]
		public Academy academy { get => default; set {} }
		[ObservableValue]
		public Smithy smithy { get => default; set {} }
	
		// Constructors
		public VillageBuildingsRootObservables() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
	}
