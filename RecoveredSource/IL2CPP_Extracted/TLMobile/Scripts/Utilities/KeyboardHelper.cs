// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class KeyboardHelper : TLMViewModel
	{
		// Fields
		[SerializeField]
		private NativeKeyboard nativeKeyboard;
		[ObservableValue]
		private float _height;
		private KeyboardState lastState;
	
		// Properties
		[ObservableValue]
		public float height { get => default; set {} }
	
		// Constructors
		public KeyboardHelper() {}
	
		// Methods
		private void Update() {}
	}
