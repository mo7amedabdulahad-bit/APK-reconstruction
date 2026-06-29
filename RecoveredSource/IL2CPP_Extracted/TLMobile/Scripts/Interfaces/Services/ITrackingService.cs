// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ITrackingService : IService
	{
		// Methods
		void TutorialCompleted();
		void RegistrationStarted();
		void RegistrationConfirmed();
		void SetUserAccountIdentifier(string userAccountIdentifier);
		void AdStarted();
		void AdFinished();
	}
