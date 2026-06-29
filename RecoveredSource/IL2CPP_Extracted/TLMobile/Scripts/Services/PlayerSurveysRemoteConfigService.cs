// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerSurveysRemoteConfigService : MonoBehaviour, IPlayersSurveysService
	{
		// Fields
		private const string LastCompletedSurveyKey = "LastSurveyComplete";
		private const string LastOpenedSurveyKey = "LastSurveyOpened";
		private const string RemoteConfigSurveyKey = "player_survey";
		private const string RemoteConfigSurveyRewardKey = "player_survey_reward";
	
		// Properties
		public bool IsSurveyAvailable { get => default; }
		public bool IsNewSurvey { get => default; }
		public string CurrentSurveyLink { get => default; }
		public string RemoteConfigSurveyLink { get => default; }
		public bool SurveyIsReward { get => default; }
	
		// Events
		public event System.Action SurveyStateChanged;
	
		// Constructors
		public PlayerSurveysRemoteConfigService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void MarkCurrentSurveyViewed() {}
		public void MarkCurrentSurveyComplete() {}
	}
