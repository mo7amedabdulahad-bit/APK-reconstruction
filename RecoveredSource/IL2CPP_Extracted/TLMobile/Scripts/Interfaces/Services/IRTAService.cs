// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IRTAService : IService
	{
		// Properties
		bool ShowRTAButton { get; }
		bool ShowIntermediatePopup { get; }
		System.Action OnShowRTAButtonTriggered { get; set; }
		Action<bool> OnShowRTAButtonStateChanged { get; set; }
		Action<RTAService.ePopUpCloseReason> OnIntermediatePopupClosed { get; set; }
		RTAConfig.ConfigData Config { get; }
	
		// Methods
		void DebugResetRTAButton();
		void Initialize();
		void TriggerLocation(string location);
		bool CanTriggerAttributeLocation(string location, int currentPoints, int addedPoints);
		void IntermediatePopupClosed(RTAService.ePopUpCloseReason closeReason);
		void LaunchReviewFlow();
	}
