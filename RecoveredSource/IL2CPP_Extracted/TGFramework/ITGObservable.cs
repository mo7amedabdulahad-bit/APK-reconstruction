// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ITGObservable
	{
		// Methods
		void ObservePropertyByName(string name, System.Action callback);
		void StopObserving(string name, System.Action callback);
		void NotifyObservers(string name, object newValue = null, object oldValue = null, PropertyChangedEventHandler hasPropertyChangedCallback = null);
		void NotifyAllPropertyObservers();
	}
