// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IPushNotificationsService : IService
	{
		// Properties
		bool ArePushNotificationsEnabled { get; }
		bool HasAskedForPermission { get; }
	
		// Methods
		void ReceivePushNotification(FirebaseMessage message);
		void RequestPermissionForPushNotifications(System.Action permissionRequestCallback);
		void OpenSystemSettings();
		void UpdateTopicStatus(string topic, bool shouldSubscribe, Action<bool> callback);
		bool GetTopicStatus(string topic);
		void EnablePushNotifications();
		void DisablePushNotifications();
	}
