// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ToggledPanel : FadedPanelController
	{
		// Fields
		[ObservableValue]
		private bool _shouldOpen;
		[ObservableValue]
		private bool _timedVisibilityTrigger;
		[SerializeField]
		private float visibleTime;
		private float visibleTimeLeft;
		private Coroutine visibilityCoroutine;
	
		// Properties
		[ObservableValue]
		public bool shouldOpen { get => default; set {} }
		[ObservableValue]
		public bool timedVisibilityTrigger { get => default; set {} }
	
		// Constructors
		public ToggledPanel() {}
	
		// Methods
		public override void Init(CanvasGroup canvasGroup, UnityEngine.UI.Image background) {}
		private void TriggerStatusChange() {}
		private void TriggerTimedVisibility() {}
		[IteratorStateMachine(typeof(_ShowAndHide_d__14))]
		private IEnumerator ShowAndHide() => default;
	}
