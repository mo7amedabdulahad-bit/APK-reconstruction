// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerObject : TGObservable
	{
		// Fields
		private ServerObjectInfos _objectInfos;
		public static int deepOutput;
		public static bool msgPackDebug;
		private static HashSet<ServerObject> objectsToCallAfterFrame;
		private static List<ServerObject> copyToIterate;
		public static Action<ServerObject, object> FillServerObject;
		public static Action<ServerObject, object> FillCollection;
		public static Action<ServerObject, object> FillCollectionWithDto;
		private static List<System.Type> alreadyPrintedTypes;
		protected List<Observer> observers;
	
		// Properties
		public ServerObjectInfos objectInfos { get => default; }
		public virtual bool isFilled { get => default; set {} }
		protected virtual bool isCollection { get => default; }
	
		// Nested types
		public class Observer
		{
			// Fields
			public System.Action callbackWithoutParameter;
			public Action<ServerObject> callback;
			public bool isOneTime;
			public bool deepObserving;
	
			// Constructors
			public Observer() {}
		}
	
		public class ServerObjectInfos
		{
			// Fields
			public string serverId;
			public int serialNumber;
			public bool isFilled;
			public long lastRequestedTime;
			public long lastFilledTime;
			public int lastFilledSerial;
			public bool isDeleted;
			public GameObject debugRepresentation;
			private ServerObject objectReference;
	
			// Constructors
			public ServerObjectInfos() {} // Dummy constructor
			public ServerObjectInfos(ServerObject o) {}
	
			// Methods
			public List<Observer> GetObservers() => default;
			public Dictionary<string, Dictionary<int, System.Action>> GetPropertyObservers() => default;
		}
	
		// Constructors
		static ServerObject() {}
		public ServerObject() {}
	
		// Methods
		private static void CallAfterFrameNotifications() {}
		public int GetAmountOfObservers() => default;
		public virtual void CallSetter(PropertyInfo propertyInfo, object newValue) {}
		public virtual object CallGetter(PropertyInfo propertyInfo) => default;
		public virtual void Fill(object someData) {}
		private void CallWithExceptionHandling(System.Action callback) {}
		private void CallWithExceptionHandling(Action<ServerObject> callback) {}
		public virtual void NotifyObservers(bool onlyPropertyChanged = false, bool onlyNotifyServerData = false) {}
		private StringBuilder FieldToString(object key, System.Type checkType, object something, bool asJson) => default;
		public string ToString(bool deepOutput = false, bool asJson = false) => default;
		public override string ToString() => default;
		public void ObserveWhole(Action<ServerObject> callback, bool instantlyCallWhenFilled = true, bool deepObserve = true) {}
		public void ObserveWhole(System.Action callback, bool instantlyCallWhenFilled = true, bool deepObserve = true) {}
		public void ObserveOnce(Action<ServerObject> callback, bool onlyReactOnServerData = false) {}
		public void ObserveOnce(System.Action callback) {}
		public void StopObserving(Action<ServerObject> callback) {}
		public void StopObserving(System.Action callback) {}
		public void TriggerNotifications() {}
		public override void NotifyObservers(string name, object newValue = null, object oldValue = null, PropertyChangedEventHandler hasPropertyChangedCallback = null) {}
		public virtual void AfterServerDataCallback(object data = null) {}
		public virtual void AfterServerDataCallback() {}
		public void CopyCommonPropertiesOverTo(object otherObject) {}
		public virtual bool ShouldDiscard(object dtObj) => default;
		public virtual void FillWithDTO(object dtObj, bool beSilent = false) {}
	}
