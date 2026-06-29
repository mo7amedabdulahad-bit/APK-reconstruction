// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Task : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _description;
		[ObservableValue]
		private float? _percentageToComplete;
		[ObservableValue]
		private int _progressValue;
		[ObservableValue]
		private int _currentLevel;
		[ObservableValue]
		private int _nextLevelValue;
		[ObservableValue]
		private int _nextLevel;
		[ObservableValue]
		private int? _progressTarget;
		[ObservableValue]
		private string _type;
		[ObservableValue]
		private TaskScope _scope;
		[ObservableValue]
		private bool _alwaysOnTop;
		[ObservableValue]
		private TaskMetadata _metadata;
		[ObservableValue]
		private GraphQLObservableList<TaskLevel> _levels;
		[ObservableValue]
		private int? _taskIndex;
		private int ownVillageIdListFromOwnVillageTasks;
		[ObservableValue]
		private string _descriptionDecoded;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private float _calculatedCompletionPercent;
		[ObservableValue]
		private TaskLevel _currentLevelInfo;
		[ObservableValue]
		private int _tasksAvailableToCollectCount;
		[ObservableValue]
		private int _tasksAvailableToCollectResourceTotal;
		[ObservableValue]
		private int _tasksAvailableToCollectXpTotal;
		[ObservableValue]
		private CollectButtonState _collectButtonState;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string description { get => default; set {} }
		[ObservableValue]
		public float? percentageToComplete { get => default; set {} }
		[ObservableValue]
		public int progressValue { get => default; set {} }
		[ObservableValue]
		public int currentLevel { get => default; set {} }
		[ObservableValue]
		public int nextLevelValue { get => default; set {} }
		[ObservableValue]
		public int nextLevel { get => default; set {} }
		[ObservableValue]
		public int? progressTarget { get => default; set {} }
		[ObservableValue]
		public string type { get => default; set {} }
		[ObservableValue]
		public TaskScope scope { get => default; set {} }
		[ObservableValue]
		public bool alwaysOnTop { get => default; set {} }
		[ObservableValue]
		public TaskMetadata metadata { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TaskLevel> levels { get => default; set {} }
		[ObservableValue]
		public int? taskIndex { get => default; set {} }
		[ObservableValue]
		public string descriptionDecoded { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public float calculatedCompletionPercent { get => default; set {} }
		[ObservableValue]
		public TaskLevel currentLevelInfo { get => default; set {} }
		[ObservableValue]
		public int tasksAvailableToCollectCount { get => default; set {} }
		[ObservableValue]
		public int tasksAvailableToCollectResourceTotal { get => default; set {} }
		[ObservableValue]
		public int tasksAvailableToCollectXpTotal { get => default; set {} }
		[ObservableValue]
		public CollectButtonState collectButtonState { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TaskListSource
		{
			FromOwnPlayerTasks = 0,
			FromOwnVillageTasks = 1
		}
	
		public enum CollectButtonState
		{
			Hidden = 0,
			ShowCollect = 1,
			ShowCollectDisabled = 2,
			ShowCollectAll = 3
		}
	
		// Constructors
		public Task() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TaskDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TaskDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListLevels(GraphQLObservableList<TaskLevel> to, List<TaskLevelDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<Task> CollectionGetNoFetchFromOwnPlayerTasks(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Task>> PromiseCollectionGetFromOwnPlayerTasks(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Task>> PromiseCollectionGetFromOwnPlayerTasks(out GraphQLFetchableList<Task> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Task> CollectionGetFromOwnPlayerTasks(Query query = Query.All) => default;
		public static GraphQLFetchableList<Task> CollectionGetFromOwnPlayerTasks(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Task> CollectionFetchFromOwnPlayerTasks(TaskListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerTasks(object dummy = null) => default;
		public static GraphQLFetchableList<Task> CollectionGetNoFetchFromOwnVillageTasks(int ownVillageId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Task>> PromiseCollectionGetFromOwnVillageTasks(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Task>> PromiseCollectionGetFromOwnVillageTasks(out GraphQLFetchableList<Task> cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Task> CollectionGetFromOwnVillageTasks(int ownVillageId, Query query = Query.All) => default;
		public static GraphQLFetchableList<Task> CollectionGetFromOwnVillageTasks(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		private static GraphQLFetchableList<Task> CollectionFetchFromOwnVillageTasks(TaskListSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnVillageTasks(int ownVillageId, object dummy = null) => default;
		private void _levelsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
