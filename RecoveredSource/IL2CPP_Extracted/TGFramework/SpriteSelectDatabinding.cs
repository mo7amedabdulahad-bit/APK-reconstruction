// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SpriteSelectDatabinding : ComponentObjectBinding
	{
		// Fields
		public BaseSpriteConfig spritesFromConfig;
		public SpritePositioningCfg spritePositioning;
		public Sprite[] availableSprites;
		[SerializeField]
		public IntSpriteDictionary availableSpritesDict;
		private bool waitingForAddressable;
		protected bool hadCorrectSpriteOnce;
	
		// Properties
		public override System.Type typeToWorkOn { get => default; }
		public virtual BaseSpriteConfig UsedSpritesFromConfig { get => default; set {} }
	
		// Constructors
		public SpriteSelectDatabinding() {}
	
		// Methods
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		protected override void UpdateTargetWithIndex(int index) {}
		protected virtual void SetUpdatedSprite(Sprite newSprite) {}
		protected virtual void SetUpdatedPosition(Vector3 posConfig, SpritePositioningCfg.TargetValues targetValues) {}
		public override void UpdateTarget() {}
		private bool IsConfigByString() => default;
	}
