// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ToastMessageController : MonoBehaviour, IToastMessageController, IBootable
	{
		// Fields
		public float totalTime;
		public float initialPhase;
		public float pauseAfterInitialPhase;
		public float secondPhase;
		public float staticTime;
		public int maxMessages;
		public ToastMessageAnimator animatorSample;
		public Transform topAnchoredParent;
		private List<ToastMessageAnimator> animatorsPool;
		private int visibleMessagesCount;
	
		// Properties
		private List<System.Action> MessagesQueue { get; }
	
		// Nested types
		[IsReadOnly]
		public struct ToastMessage
		{
			// Properties
			public string Message { get; }
			public ToastMessageType MessageType { get; }
	
			// Constructors
			public ToastMessage(string message, ToastMessageType messageType) : this() {}
		}
	
		// Constructors
		public ToastMessageController() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void ShowMessage(string messageText, ToastMessageType messageType) {}
		public void ShowMessageOverHeader(string messageText, ToastMessageType messageType) {}
		public int QueueCurrentSize() => default;
		private void ShowNext() {}
		private void DisplayMessage(ToastMessage message, bool anchorToTop = false) {}
		private ToastMessageAnimator GetAnimator() => default;
	}
