// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceSearchPopupController : GenericSearchPopupControllerWithRecentlySelectedObjects<Alliance>
	{
		// Properties
		protected override string searchType { get => default; }
		protected override int requiredCharsForSearch { get => default; }
	
		// Constructors
		public AllianceSearchPopupController() {}
	
		// Methods
		protected override IPromise<Alliance> GetPromise(int allianceId, bool forceFetch = true) => default;
		protected override Alliance Get(int allianceId) => default;
		protected override int Id(Alliance alliance) => default;
		protected override void DoBackendSearch() {}
	}
