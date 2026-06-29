// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.DailyQuestsWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DailyQuestsController : DetailWindowController
	{
		// Fields
		public RewardMessage RewardMessage;
		private const int MobileAdQuestId = 13;
		private const int BrowserAdQuestId = 12;
		[ObservableValue]
		private DailyQuests _dailyQuests;
		[ObservableValue]
		private QuestData _selectedQuest;
		[ObservableValue]
		private bool _anythingToRedeem;
		[ObservableValue]
		private bool _showWatchVideoButton;
		[ObservableValue]
		private bool _disableWatchVideoButton;
	
		// Properties
		[ObservableValue]
		public DailyQuests dailyQuests { get => default; set {} }
		[ObservableValue]
		public QuestData selectedQuest { get => default; set {} }
		[ObservableValue]
		public bool anythingToRedeem { get => default; set {} }
		[ObservableValue]
		public bool showWatchVideoButton { get => default; set {} }
		[ObservableValue]
		public bool disableWatchVideoButton { get => default; set {} }
	
		// Constructors
		public DailyQuestsController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Setup() {}
		private void UpdateDailyQuests() {}
		public void SelectQuest(QuestData data) {}
		[UICallable]
		public int SortQuests(QuestData a, QuestData b) => default;
		[UICallable]
		public void CollectRewards() {}
		[UICallable]
		public void CollectReward(QuestReward questReward) {}
		private void OnRewardClaimed(QuestReward[] questRewards) {}
		[UICallable]
		public void ShowQuestDetails(QuestData data) {}
		[UICallable]
		public void WatchVideo() {}
		private void TriggerDailyQuestRewardedAd(Action<string> onSuccess, System.Action onFail) {}
		private void OnAdSuccess(string adSalesVrid) {}
	}
