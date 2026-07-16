// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportInterface : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		protected string _objectId;
		[ObservableValue]
		protected int _time;
		[ObservableValue]
		protected int? _readStatus;
		[ObservableValue]
		protected string _title;
		[ObservableValue]
		protected int _ownerId;
		protected string thisTypeName;
		private string reportObjectIdByReport;
		private string reportAuthKeyByReport;
		private string allianceReportObjectIdByAllianceReport;
		private static readonly string[] namesInNestedResponseByReport;
		private static readonly string[] namesInNestedResponseByAllianceReport;
		private static Action<ReportInterface> additionalInjectedPostServerDataCallback;
		[ObservableValue]
		private int _iconIndex;
		[ObservableValue]
		private ReportType _reportType;
		[ObservableValue]
		private ReadStatus? _readStatusEnum;
		[ObservableValue]
		private string _translatedTitle;
		[ObservableValue]
		private TLMobile.Scripts.Enums.SelectionState _selected;
		[ObservableValue]
		private ReportTranslationInformation _translationInfo;
		[ObservableValue]
		private int _reportTypeBackground;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ReportInterfaceSource Source { get; set; }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public int time { get => default; set {} }
		[ObservableValue]
		public int? readStatus { get => default; set {} }
		[ObservableValue]
		public string title { get => default; set {} }
		[ObservableValue]
		public int ownerId { get => default; set {} }
		[ObservableValue]
		public int iconIndex { get => default; set {} }
		[ObservableValue]
		public ReportType reportType { get => default; set {} }
		[ObservableValue]
		public ReadStatus? readStatusEnum { get => default; set {} }
		[ObservableValue]
		public string translatedTitle { get => default; set {} }
		[ObservableValue]
		public TLMobile.Scripts.Enums.SelectionState selected { get => default; set {} }
		[ObservableValue]
		public ReportTranslationInformation translationInfo { get => default; set {} }
		[ObservableValue]
		public int reportTypeBackground { get => default; set {} }
		[ObservableValue]
		public string AuthKey { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ReportInterfaceSource
		{
			RootLevelByReport = 0,
			RootLevelByAllianceReport = 1
		}
	
		public enum ReadStatus
		{
			Unread = 0,
			Read = 1,
			Archived = 2
		}
	
		public enum ReportType
		{
			DefaultReport = 0,
			TraderArrivedReport = 1,
			AnimalsInCageReport = 2,
			AdventureReport = 3,
			ScoutingReport = 4,
			RaidReport = 5,
			ReinforcementReport = 6,
			AttackReport = 7,
			SettlingReport = 8,
			SettlingFailedReport = 9,
			AttackSupportReport = 10,
			GreetingReport = 11,
			VillageDeletedReport = 12
		}
	
		// Constructors
		public ReportInterface() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ReportInterfaceDTO dtoValue) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ReportInterfaceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public static string GetInterfaceType(JObject dtoData) => default;
		public static ReportInterface CreateInstance(string typename) => default;
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent) => default;
		public bool CopyValuesFromDTO(JObject newValues, Query query = Query.All, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(JObject dtoValue, Query query = Query.All) => default;
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<ReportInterface> PromiseGetByReport(string reportObjectId, string reportAuthKey = null, Query query = Query.All, bool forceFetch = true) => default;
		public static ReportInterface GetNoFetch(string typeName, string reportObjectId, string reportAuthKey = null, Query query = Query.All) => default;
		private static ReportInterface FetchByReport(string typeName, ReportInterfaceSource origin, string reportObjectId, string reportAuthKey = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<ReportInterface> PromiseGetByAllianceReport(string allianceReportObjectId, Query query = Query.All, bool forceFetch = true) => default;
		public static ReportInterface GetNoFetch(string typeName, string allianceReportObjectId, Query query = Query.All) => default;
		private static ReportInterface FetchByAllianceReport(string typeName, ReportInterfaceSource origin, string allianceReportObjectId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartByReport(string reportObjectId, string reportAuthKey = null, object dummy = null) => default;
		private static string GetRequestBodyPartByAllianceReport(string allianceReportObjectId, object dummy = null) => default;
		public static void AddAdditionalInjectedPostServerDataCallback(Action<ReportInterface> callback) {}
		public static void RemoveAdditionalInjectedPostServerDataCallback(Action<ReportInterface> callback) {}
		public override void AfterServerDataCallback() {}
		private void ExtractReportParticipantName(ReportParticipant reportParticipant, ReportVillageInformation infoObject) {}
		private void ExtractReportParticipantName(Village vill, ReportVillageInformation infoObject) {}
	}
