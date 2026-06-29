// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ISharedUIService : IService
	{
		// Properties
		BuildingRadialMenuController BuildingRadialMenuController { get; set; }
		MainUIStateController MainUIStateController { get; set; }
		SafeAreaAdapter SafeAreaAdapter { get; set; }
		GameObject DetailWindowsContainer { get; set; }
		GameObject PopupWindowsContainer { get; set; }
		WaitForBackendScreenController WaitForBackendScreenController { get; set; }
		IToastMessageController ToastMessageController { get; set; }
		INotificationController NotificationController { get; set; }
		DetailWindowsShowController DetailWindowsShowController { get; set; }
	
		// Methods
		void OnChangeView(SceneStatus status);
	}
