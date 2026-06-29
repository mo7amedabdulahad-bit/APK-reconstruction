// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.PlayerTasks
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerTasksController : DetailWindowTabController
	{
		// Fields
		public RewardMessage RewardMessage;
		private readonly Dictionary<Category, string> categoryLocalizedKeyMap;
		[ObservableValue]
		private Category _selectedCategory;
		[ObservableValue]
		private GraphQLFetchableList<TLMobile.Generated.GraphQL.Game.Task> _globalTasks;
		[ObservableValue]
		private GraphQLFetchableList<TLMobile.Generated.GraphQL.Game.Task> _villageTasks;
		[ObservableValue]
		private string _selectedCategoryLocalizedKey;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Task _selectedTask;
		[ObservableValue]
		private bool _showTaskDetails;
		private int lastForceFetch;
	
		// Properties
		[ObservableValue]
		public Category selectedCategory { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<TLMobile.Generated.GraphQL.Game.Task> globalTasks { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<TLMobile.Generated.GraphQL.Game.Task> villageTasks { get => default; set {} }
		[ObservableValue]
		public string selectedCategoryLocalizedKey { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Task selectedTask { get => default; set {} }
		[ObservableValue]
		public bool showTaskDetails { get => default; set {} }
	
		// Nested types
		public enum Category
		{
			Village = 0,
			Global = 1
		}
	
		// Constructors
		public PlayerTasksController() {}
	
		// Methods
		private void _globalTasksNotify(object sender, PropertyChangedEventArgs args) {}
		private void _villageTasksNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Setup(OwnVillage village) {}
		[UICallable]
		public async UniTask CollectRewardWithTaskLevel(TLMobile.Generated.GraphQL.Game.Task task, TaskLevel taskLevel) => default;
		[UICallable]
		public async UniTask CollectReward(TLMobile.Generated.GraphQL.Game.Task task) => default;
		[UICallable]
		public async UniTask CollectAllRewardsForTask(TLMobile.Generated.GraphQL.Game.Task task) => default;
		[UICallable]
		public async UniTask CollectAllRewards() => default;
		private async UniTask SendTaskCollectionRequest(TLMobile.Generated.GraphQL.Game.Task task, TaskLevel taskLevel) => default;
		private void OnTaskCollectionCompleted(TaskLevel[] value) {}
		[UICallable]
		public void SwitchCategory(Category category) {}
		[UICallable]
		public int Compare(TLMobile.Generated.GraphQL.Game.Task x, TLMobile.Generated.GraphQL.Game.Task y) => default;
		[UICallable]
		public bool Filter(TLMobile.Generated.GraphQL.Game.Task t) => default;
		[UICallable]
		public void ShowTaskDetails(TLMobile.Generated.GraphQL.Game.Task task) {}
		[UICallable]
		public void HideTaskDetails() {}
		[UICallable]
		public int CompareTaskLevel(TaskLevel x, TaskLevel y) => default;
		[UICallable]
		public bool FilterLevel(TaskLevel t) => default;
	}
