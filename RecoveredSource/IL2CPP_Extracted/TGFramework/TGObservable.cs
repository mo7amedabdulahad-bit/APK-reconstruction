// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TGObservable : ITGObservable
	{
		// Fields
		public static int observes;
		public static bool dontRegisterAfterFrameCallbacks;
		public static bool manuallyTriggerNotifications;
		protected Dictionary<string, Dictionary<int, System.Action>> propertyObservers;
		protected Dictionary<string, PropertyChangedEventHandler> propertiesWithChangedNotifyer;
		protected HashSet<string> lateNotifications;
		protected static HashSet<ITGObservable> manualTriggersToRun;
		public static System.Action TriggerAllNotificationsCallback;
		protected bool notifyWholeObjectObservers;
		protected Queue<System.Action> scheduledNotifications;
		protected HashSet<int> scheduledCallbackHashes;
		private Stopwatch scheduledNotificationsTimer;
	
		// Constructors
		public TGObservable() {}
	
		// Methods
		protected virtual void OnDestroy() {}
		protected void RemovePropertyChangedDelegate(INotifyPropertyChanged value, PropertyChangedEventHandler handler) {}
		protected void AddPropertyChangedDelegate(INotifyPropertyChanged value, PropertyChangedEventHandler handler) {}
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
		public void ObserveProperty<T>(Expression<Func<T>> expr, System.Action callback) {}
		public void AnalyzeObserverStats(ref Dictionary<string, int> counter) {}
		public void GetObserverStats() {}
		private void ClearObservers() {}
	}
