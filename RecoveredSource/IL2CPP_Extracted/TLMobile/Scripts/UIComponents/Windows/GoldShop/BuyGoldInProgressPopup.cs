// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.GoldShop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuyGoldInProgressPopup : DetailWindowController
	{
		// Fields
		public UnityEngine.Animator Animator;
		private static readonly int IsError;
		private static readonly int IsSuccess;
		private static readonly int IsWaiting;
		[ObservableValue]
		private State _currentState;
		[ObservableValue]
		private bool _isTimeoutError;
	
		// Properties
		[ObservableValue]
		public State currentState { get => default; set {} }
		[ObservableValue]
		public bool isTimeoutError { get => default; set {} }
	
		// Nested types
		public enum State
		{
			WaitingForData = 0,
			Success = 1,
			Fail = 2
		}
	
		// Constructors
		public BuyGoldInProgressPopup() {}
		static BuyGoldInProgressPopup() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void SetCurrentState(State state) {}
		public void SetSuccess() {}
		public void SetFail(bool timeoutError = false) {}
		private void SetAnimatorState(bool isWaiting, bool isSuccess, bool isError) {}
	}
