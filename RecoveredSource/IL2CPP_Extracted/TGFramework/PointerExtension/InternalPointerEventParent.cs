// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.PointerExtension
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InternalPointerEventParent : MonoBehaviour
	{
		// Fields
		public bool isPointerOver;
		protected List<Action<PointerEventData>> callbacks;
	
		// Constructors
		public InternalPointerEventParent() {}
	
		// Methods
		public void AddCallback(Action<PointerEventData> callback) {}
		public void RemoveCallback(Action<PointerEventData> callback) {}
		protected void CallCallbacks(PointerEventData e) {}
		public void AddCallbackAtIndex(Action<PointerEventData> callback, int index = 0) {}
	}
