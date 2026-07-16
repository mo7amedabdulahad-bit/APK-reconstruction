// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IServerObjectUpdatingService : IService
	{
		// Methods
		void Register(IBackendUpdateable updateableObject, ITimedUpdater timedObject, int queryType = 0);
		void RegisterEarliest<T>(IBackendUpdateable updateableObject, IList<T> list, int queryType = 0, bool overrideCurrentTimer = true)
			where T : ITimedUpdater;
		int GetTimeForObject(IBackendUpdateable obj);
	}
