// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RewardMessage : TLMViewModel
	{
		// Fields
		public UnityEngine.Animator Animator;
		private const int ItemIdWood = 145;
		private const int ItemIdClay = 146;
		private const int ItemIdIron = 147;
		private const int ItemIdCrop = 148;
		private const string StatePlay = "Play";
		private static readonly int ParameterPlay;
		private static readonly int ParameterSkip;
		[ObservableValue]
		private ObservableList<RewardMessageItem> _rewardMessageItems;
	
		// Properties
		[ObservableValue]
		public ObservableList<RewardMessageItem> rewardMessageItems { get => default; set {} }
	
		// Constructors
		public RewardMessage() {}
		static RewardMessage() {}
	
		// Methods
		private void _rewardMessageItemsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void PlayAnimation(int wood, int clay, int iron, int crop, int resourcesAll, int xp) {}
		public void PlayAnimation(QuestReward[] questRewards) {}
		[UICallable]
		public void OnSkipClicked() {}
		private void Add(rewardType rewardType, int id, int amount) {}
	}
