// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceDiplomacyViewModel : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private bool _anyAlly;
		[ObservableValue]
		private bool _anyNap;
		[ObservableValue]
		private bool _anyWar;
		[ObservableValue]
		private DisplayedInformation _currentlyShownInformation;
	
		// Properties
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public bool anyAlly { get => default; set {} }
		[ObservableValue]
		public bool anyNap { get => default; set {} }
		[ObservableValue]
		public bool anyWar { get => default; set {} }
		[ObservableValue]
		public DisplayedInformation currentlyShownInformation { get => default; set {} }
	
		// Nested types
		[Flags]
		public enum DisplayedInformation
		{
			War = 1,
			Nap = 2,
			Ally = 4,
			All = 7
		}
	
		// Constructors
		public AllianceDiplomacyViewModel() {}
	
		// Methods
		public void Setup(int allianceId, DisplayedInformation informationToDisplay) {}
		private void CheckRelationsCounts() {}
		[UICallable]
		public bool FilterWarRelations(OwnAllianceDiplomacyRelation relation) => default;
		[UICallable]
		public bool FilterNapRelations(OwnAllianceDiplomacyRelation relation) => default;
		[UICallable]
		public bool FilterConfederacyRelations(OwnAllianceDiplomacyRelation relation) => default;
		[UICallable]
		public bool FilterUnions(Alliance alliance) => default;
	}
