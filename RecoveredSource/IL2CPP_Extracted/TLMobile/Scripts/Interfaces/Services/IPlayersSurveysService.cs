// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IPlayersSurveysService : IService
	{
		// Properties
		string RemoteConfigSurveyLink { get; }
		bool IsSurveyAvailable { get; }
		bool IsNewSurvey { get; }
		string CurrentSurveyLink { get; }
		bool SurveyIsReward { get; }
	
		// Events
		event System.Action SurveyStateChanged;
	
		// Methods
		void MarkCurrentSurveyViewed();
		void MarkCurrentSurveyComplete();
	}
