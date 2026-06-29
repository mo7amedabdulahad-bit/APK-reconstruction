// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IDeepLinkActionService : IService
	{
		// Methods
		bool TryResumeWithLastRecognizedDeeplinkAction();
		bool TryResumeWithLastUnRecognizedLink(UniversalDeepLinkingService.LinkActivationResult lastLinkActivation, out LinkNotWorkingPopupController linkNotWorkingPopupController);
	}
