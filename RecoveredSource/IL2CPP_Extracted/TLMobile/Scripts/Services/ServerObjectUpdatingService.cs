// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerObjectUpdatingService : MonoBehaviour, IServerObjectUpdatingService
	{
		// Fields
		private readonly Dictionary<IBackendUpdateable, Tuple<int, int>> registeredObjects;
		private readonly Dictionary<IBackendUpdateable, int> valuesToUpdateAndRemove;
	
		// Constructors
		public ServerObjectUpdatingService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void Register(IBackendUpdateable updateableObject, ITimedUpdater timedObject, int queryType = 0) {}
		public void RegisterEarliest<T>(IBackendUpdateable updateableObject, IList<T> list, int queryType = 0, bool overrideCurrentTimer = true)
			where T : ITimedUpdater {}
		public int GetTimeForObject(IBackendUpdateable obj) => default;
		public void UpdateNeededObjects() {}
		private void Register(IBackendUpdateable updateableObject, int timeToUpdate, int queryType = 0, bool overwriteCurrentTime = true) {}
		private int GetEarliest<T>(IList<T> list)
			where T : ITimedUpdater => default;
	}
