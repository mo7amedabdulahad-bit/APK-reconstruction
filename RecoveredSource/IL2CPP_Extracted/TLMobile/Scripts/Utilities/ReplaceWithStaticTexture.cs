// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReplaceWithStaticTexture : InjectableViewModel
	{
		// Fields
		[Help("Seconds that need to pass from object change to actual baking")]
		public float delayToBake;
		[Help("Set to true if you want to observe the injected object and bake on changes")]
		public bool observeInjectedValue;
		private readonly List<GameObject> bakedObjects;
		[InjectableValue]
		[ObservableValue]
		private object _changeWatcher;
		private Sprite hadSpriteOnRoot;
		private UnityEngine.UI.Image imgComponent;
		private Sprite lastRenderedSprite;
		private ServerObject oldObserve;
		private RenderTexture renderTexture;
		private GameObject temporaryCamGameObject;
		private GameObject temporaryParentGameObject;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public object changeWatcher { get => default; set {} }
	
		// Constructors
		public ReplaceWithStaticTexture() {}
	
		// Methods
		protected void OnEnable() {}
		public override void OnInjectedValueChanged() {}
		public void Revert() {}
		[ContextMenu("Bake")]
		public void Bake() {}
		private void CreateSprite() {}
		private void SetLayerRecursively(GameObject obj, int newLayer) {}
		private Rect RectTransformToScreenSpace(RectTransform transform) => default;
	}
