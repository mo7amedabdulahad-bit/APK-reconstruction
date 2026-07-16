// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SilverAccounting : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<SilverAccountingRecord> _silverInAuctions;
		[ObservableValue]
		private GraphQLObservableList<SilverAccountingRecord> _records;
		private static readonly string[] namesInNestedResponseFromOwnPlayerAuctionsSilverAccounting;
		[ObservableValue]
		private int _oldBalanceDate;
		[ObservableValue]
		private int _oldBalanceValue;
		[ObservableValue]
		private int _totalTiedSilver;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public SilverAccountingSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<SilverAccountingRecord> silverInAuctions { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<SilverAccountingRecord> records { get => default; set {} }
		[ObservableValue]
		public int oldBalanceDate { get => default; set {} }
		[ObservableValue]
		public int oldBalanceValue { get => default; set {} }
		[ObservableValue]
		public int totalTiedSilver { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum SilverAccountingSource
		{
			FromOwnPlayerAuctionsSilverAccounting = 0
		}
	
		// Constructors
		public SilverAccounting() {}
		static SilverAccounting() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SilverAccountingDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SilverAccountingDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListSilverInAuctions(GraphQLObservableList<SilverAccountingRecord> to, List<SilverAccountingRecordDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRecords(GraphQLObservableList<SilverAccountingRecord> to, List<SilverAccountingRecordDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<SilverAccounting> PromiseGetFromOwnPlayerAuctionsSilverAccounting(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<SilverAccounting> PromiseGetFromOwnPlayerAuctionsSilverAccounting(out SilverAccounting cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static SilverAccounting GetNoFetchFromOwnPlayerAuctionsSilverAccounting(Query query = Query.All) => default;
		public static SilverAccounting GetFromOwnPlayerAuctionsSilverAccounting(bool forceRefresh, Query query = Query.All) => default;
		public static SilverAccounting GetFromOwnPlayerAuctionsSilverAccounting(Query query = Query.All) => default;
		private static SilverAccounting FetchFromOwnPlayerAuctionsSilverAccounting(SilverAccountingSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerAuctionsSilverAccounting(object dummy = null) => default;
		private void _silverInAuctionsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _recordsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
