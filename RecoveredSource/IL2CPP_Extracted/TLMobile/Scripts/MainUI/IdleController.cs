// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class IdleController : MonoBehaviour
	{
		// Fields
		public float isIdlingDelay;
		public bool isIdling;
		private float nextIdleStart;
	
		// Events
		public static event Action<bool> OnIsIdlingChanged;
	
		// Constructors
		public IdleController() {}
	
		// Methods
		private void Awake() {}
		private void Update() {}
		private void UpdateIsIdling(bool isIdling) {}
		private void RestartIdleDelay() {}
	}
