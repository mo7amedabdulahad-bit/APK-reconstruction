// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DonationStatistics : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private DonationStatisticsEntry _myWeekPosition;
		[ObservableValue]
		private GraphQLObservableList<DonationStatisticsEntry> _week;
		[ObservableValue]
		private DonationStatisticsEntry _myAllTimePosition;
		[ObservableValue]
		private GraphQLObservableList<DonationStatisticsEntry> _allTime;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public DonationStatisticsEntry myWeekPosition { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<DonationStatisticsEntry> week { get => default; set {} }
		[ObservableValue]
		public DonationStatisticsEntry myAllTimePosition { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<DonationStatisticsEntry> allTime { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public DonationStatistics() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(DonationStatisticsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(DonationStatisticsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListWeek(GraphQLObservableList<DonationStatisticsEntry> to, List<DonationStatisticsEntryDTO> from, int query) => default;
		private bool CopyValuesFromDtoListAllTime(GraphQLObservableList<DonationStatisticsEntry> to, List<DonationStatisticsEntryDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _weekNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allTimeNotify(object sender, PropertyChangedEventArgs args) {}
	}
