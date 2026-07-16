// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ViewModel : MonoBehaviour, ITGObservable
	{
		// Fields
		private bool didInitialize;
		public static int instancesWaitingForStart;
		public static int observes;
		private static bool manuallyTriggerNotifications;
		private Dictionary<System.Type, ViewModel> parentViewModels;
		private List<KeyValuePair<ServerObject, Action<ServerObject>>> observers;
		private List<KeyValuePair<ServerObject, System.Action>> observersWithoutParameter;
		private Dictionary<ServerObject, Dictionary<string, HashSet<System.Action>>> objectPropertyObservers;
		private Dictionary<string, HashSet<System.Action>> ownPropertyObservers;
		protected Dictionary<string, Dictionary<int, System.Action>> propertyObservers;
		protected Dictionary<string, PropertyChangedEventHandler> propertiesWithChangedNotifyer;
		protected HashSet<string> lateNotifications;
		protected static HashSet<ITGObservable> manualTriggersToRun;
		public static System.Action TriggerAllNotificationsCallback;
		protected bool notifyWholeObjectObservers;
		protected Queue<System.Action> scheduledNotifications;
		protected HashSet<int> scheduledCallbackHashes;
		private Stopwatch scheduledNotificationsTimer;
		protected Dictionary<INotifyPropertyChanged, List<PropertyChangedEventHandler>> propertyChangedDelegates;
		public static Dictionary<System.Type, List<ViewModel>> instances;
	
		// Events
		public event System.Action OnDestroyEvent;
		public event Action<ViewModel> OnDestroyEventArg;
	
		// Constructors
		static ViewModel() {}
		public ViewModel() {}
	
		// Methods
		public void StopObserving<T>(Expression<Func<T>> expr, System.Action callback) {}
		public void ObservePropertyByName(string name, System.Action callback) {}
		public void StopObserving(string name, System.Action callback) {}
		public void StopObserving(string name) {}
		protected void RequestLateNotifyObservers(string name) {}
		private void LateNotifyObservers() {}
		public static void TriggerAllNotifications() {}
		protected virtual List<string> GetAllPropertsToNotify() => default;
		public void NotifyAllPropertyObservers() {}
		protected virtual void NotifyObserversScheduled(string name) {}
		protected double ExecuteScheduledNotifications(double timeBudgetInMs = 14) => default;
		private void RegisterPropertyChangedHandlers(INotifyPropertyChanged oldObject, INotifyPropertyChanged newObject, PropertyChangedEventHandler propertyChangedCallback) {}
		public virtual void NotifyObservers(string name, object newValue = null, object oldValue = null, PropertyChangedEventHandler hasPropertyChangedCallback = null) {}
		protected void RemovePropertyChangedDelegate(INotifyPropertyChanged value, PropertyChangedEventHandler handler) {}
		protected void AddPropertyChangedDelegate(INotifyPropertyChanged value, PropertyChangedEventHandler handler) {}
		private void ClearPropertyChangedDelegates() {}
		public void RegisterOwnPropertyObserver(string name, System.Action callback) {}
		public void ObserveProperty<T>(Expression<Func<T>> expr, System.Action callback) {}
		public void ClearPropertyObservers(bool onlyOwnObservers = true) {}
		protected virtual void Awake() {}
		protected virtual void OnDestroy() {}
		public void ObserveObjectProperty<T>(ServerObject obj, Expression<Func<T>> expression, System.Action callback) {}
		public void StopObserveObjectProperties(ServerObject obj) {}
		private void RecursivelyAddTypeToInstances(System.Type t) {}
		private void RecursivelyRemoveTypeFromInstances(System.Type t) {}
		public void GetObserverStats(ref Dictionary<string, int> counter) {}
		public static void AnalyzeObserverStats(ref Dictionary<string, int> counter) {}
		public static List<T> GetInstancesOf<T>()
			where T : ViewModel => default;
		public static List<ViewModel> GetInstancesOf(System.Type type) => default;
		public static T GetInstanceOf<T>(bool onlyActive = false)
			where T : ViewModel => default;
		public void ObserveWholeOnly(ServerObject obj, System.Action callback, bool deepObserve = true) {}
		public void ObserveWholeOnly(ServerObject obj, Action<ServerObject> callback, bool deepObserve = true) {}
		public virtual void ObserveWhole(ServerObject obj, Action<ServerObject> callback, bool deepObserve = true) {}
		public virtual void ObserveWhole(ServerObject obj, System.Action callback, bool deepObserve = true, bool instantlyCallWhenFilled = true) {}
		public virtual void StopObserving(ServerObject obj) {}
		protected void FindParentViewModels(bool force = false) {}
		public void ClearObservers(bool withoutPropertyChanged = false) {}
		protected bool IsObservingProperty<T>(Expression<Func<T>> expr, System.Action observerCallback = null) => default;
		protected bool IsObservingObject(ServerObject sObj, System.Action observerCallback = null) => default;
		protected T GetParentViewModel<T>(bool useCache = true)
			where T : ViewModel => default;
		protected virtual void AddEventListeners() {}
		protected virtual void RemoveEventListeners() {}
		protected void LogWithContext(object message, bool logTimeAndFrame = true) {}
		protected virtual string GetDebugContextName() => default;
	}
