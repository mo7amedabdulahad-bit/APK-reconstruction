// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameTrackingService : MonoBehaviour, TLMobile.Scripts.Interfaces.Services.ITrackingService
	{
		// Fields
		private const string LastHeroLevelPlayerPrefsKey = "LastHeroLevelPlayerPrefsKey";
		private const string LastAllianceIdPlayerPrefsKey = "LastAllianceIdPlayerPrefsKey";
		private const string VillageCountPlayerPrefsKey = "VillageCountPlayerPrefsKey";
		private const string AdventuresCompletedCountPlayerPrefsKey = "AdventuresCountPlayerPrefsKey";
		private const string HasLoggedInDuringEndGamePlayerPrefsKey = "HasLoggedInDuringEndGamePlayerPrefsKey";
		private const int EndGameGracePeriodInDays = 7;
		private static readonly HashSet<int> HeroLevelsToFireEvents;
		private static readonly HashSet<int> VillageCountToFireEvents;
		private static readonly HashSet<int> AdventuresCompletedToFireEvent;
		private int adventuresCompletedCount;
		private string allianceId;
		private int heroLevel;
		private string userAccountIdentifier;
		private int villageCount;
		public const string PropertyUserAccountID = "user_account_id";
	
		// Constructors
		public GameTrackingService() {}
		static GameTrackingService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public void RegistrationStarted() {}
		public void RegistrationConfirmed() {}
		public void TutorialCompleted() {}
		public void SetUserAccountIdentifier(string userAccountIdentifier) {}
		public void AdStarted() {}
		public void AdFinished() {}
		public void SessionStart() {}
		private void GatherAndSendLoginData(string serverUUID) {}
		private void CheckLoginDuringEndGame() {}
		private bool HasAlreadyLoggedInDuringEndGame() => default;
		private long GetServerEndTime() => default;
		private bool IsLoggingInDuringEndGame(long serverEndTime) => default;
		private void TrackLoginDuringEndGame() {}
		private void CheckPlayerLevel() {}
		private void OnHeroLevelChanged() {}
		private void ReportHighestHeroLevel(int lastLevel, int currentLevel) {}
		private void CheckAllianceId() {}
		private void OnAllianceIdChanged() {}
		private void FireAllianceIdChangeEvent(string allianceId) {}
		private void CheckVillageCount() {}
		private void OnVillageCountChanged() {}
		private void ReportHighestVillageCount(int lastCount, int currentCount) {}
		private void CheckAdventuresCompletedCount() {}
		private void OnAdventuresCompletedCountChanged() {}
		private void ReportHighestAdventuresCompletedCount(int lastCount, int currentCount) {}
		private static string GetMethod() => default;
	}
