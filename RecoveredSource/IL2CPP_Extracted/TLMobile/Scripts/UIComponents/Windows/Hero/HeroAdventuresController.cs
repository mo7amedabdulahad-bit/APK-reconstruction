// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAdventuresController : DetailWindowTabController
	{
		// Fields
		private const int MovementSpeedupDistance = 20;
		[ObservableValue]
		private int _currentVillageId;
		[ObservableValue]
		private OwnVillage _selectedVillage;
		[ObservableValue]
		private bool _otherVillagesExpanded;
		[ObservableValue]
		private bool _sendButtonActive;
		[ObservableValue]
		private bool _relocateButtonActive;
		[ObservableValue]
		private int _durationToSelectedVillage;
		[ObservableValue]
		private ObservableList<AdventureWithDuration> _adventuresWithDuration;
		[ObservableValue]
		private bool _heroCentricAdventures;
		[ObservableValue]
		private OwnHero _ownHero;
		private GraphQLFetchableList<Adventure> adventures;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public int currentVillageId { get => default; set {} }
		[ObservableValue]
		public OwnVillage selectedVillage { get => default; set {} }
		[ObservableValue]
		public bool otherVillagesExpanded { get => default; set {} }
		[ObservableValue]
		public bool sendButtonActive { get => default; set {} }
		[ObservableValue]
		public bool relocateButtonActive { get => default; set {} }
		[ObservableValue]
		public int durationToSelectedVillage { get => default; set {} }
		[ObservableValue]
		public ObservableList<AdventureWithDuration> adventuresWithDuration { get => default; set {} }
		[ObservableValue]
		public bool heroCentricAdventures { get => default; set {} }
		[ObservableValue]
		public OwnHero ownHero { get => default; set {} }
	
		// Nested types
		public enum eWatchVideoType
		{
			ReduceAdventureDuration = 0,
			IncreaseAdventureDanger = 1
		}
	
		// Constructors
		public HeroAdventuresController() {}
	
		// Methods
		private void _adventuresWithDurationNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnDisable() {}
		public override void OnOpen(int tabNumber) {}
		private void UpdateAdventures() {}
		[UICallable]
		public void ToggleVillageExpanded() {}
		[UICallable]
		public void StartAdventure(Adventure adv) {}
		[UICallable]
		public void SendHeroToSelectedVillage() {}
		private void SendHeroSomewhere(SendTroopsRequestBody.EventTypeEnum eventTypeEnum, int targetMapId, bool relocate) {}
		[UICallable]
		public void OpenMyVillagesPopup() {}
		[UICallable]
		public void WatchVideo(eWatchVideoType type) {}
		private void TriggerAdventureDifficultyRewardAd(Action<string> onSuccess) {}
		private void TriggerAdventureDurationRewardAd(Action<string> onSuccess) {}
	}
