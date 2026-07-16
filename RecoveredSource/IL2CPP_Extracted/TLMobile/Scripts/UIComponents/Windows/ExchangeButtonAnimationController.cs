// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ExchangeButtonAnimationController : InjectableViewModel
	{
		// Fields
		public UnityEngine.UI.Image highlightObject;
		public float rotationValue;
		public float animationDuration;
		public float delayBetweenLoops;
		public float maxAlpha;
		private readonly UnityEngine.Color initColor;
		[InjectableValue]
		[ObservableValue]
		private ResourceAmounts _costs;
		private DG.Tweening.Sequence parentSequence;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public ResourceAmounts costs { get => default; set {} }
	
		// Constructors
		public ExchangeButtonAnimationController() {}
	
		// Methods
		private void OnEnable() {}
		private void OnDisable() {}
		protected override void OnDestroy() {}
		public override void OnInjectedValueChanged() {}
		private void TryPlayAnimation() {}
	}
