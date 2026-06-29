// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Statistics
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StatisticsAllianceVPSubTabController : DetailWindowTabControllerWithPagination<VPRankedAlliance>
	{
		// Fields
		[ObservableValue]
		private Alliance _searchForAlliance;
		[ObservableValue]
		private Alliance _firstAlliance;
		[ObservableValue]
		private Alliance _secondAlliance;
		[ObservableValue]
		private Alliance _thirdAlliance;
		private Alliance ownAllianceObject;
		private VPRankedAlliancePagination top3Data;
	
		// Properties
		[ObservableValue]
		public Alliance searchForAlliance { get => default; set {} }
		[ObservableValue]
		public Alliance firstAlliance { get => default; set {} }
		[ObservableValue]
		public Alliance secondAlliance { get => default; set {} }
		[ObservableValue]
		public Alliance thirdAlliance { get => default; set {} }
		protected override bool AllowBackwardLoading { get => default; }
	
		// Constructors
		public StatisticsAllianceVPSubTabController() {}
	
		// Methods
		public void Init() {}
		[UICallable]
		public void OpenAllianceSearch() {}
		private void InitializeWithOwnRank() {}
		private void SetSubTab() {}
		private void LoadTop3() {}
		private void RefreshTop3() {}
	}
