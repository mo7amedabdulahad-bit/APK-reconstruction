// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroPortraitController : InjectableViewModel
	{
		// Fields
		public OwnHero.Query imageQuery;
		public bool portraitOnly;
		private readonly int[] downFrontItems;
		private readonly int[] upFrontItems;
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		private Generated.GraphQL.Game.Hero _heroObject;
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		private OwnHero _ownHeroObject;
		[ObservableValue]
		private bool _portraitMode;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.HeroAppearance _appearance;
		[ObservableValue]
		private Gender _gender;
		[ObservableValue]
		private string _heroBackSpriteHairKey;
		[ObservableValue]
		private string _heroBackWithoutHelmetSpriteHairKey;
		[ObservableValue]
		private string _heroFrontHairSpriteKey;
		[ObservableValue]
		private string _heroFrontHairWithoutHelmetSpriteKey;
		[ObservableValue]
		private string _heroBaseSpriteKey;
		[ObservableValue]
		private string _heroLeftArmSpriteKey;
		[ObservableValue]
		private string _heroRightArmSpriteKey;
		[ObservableValue]
		private string _heroEarsSpriteKey;
		[ObservableValue]
		private string _heroJawSpriteKey;
		[ObservableValue]
		private string _heroEyesBaseSpriteKey;
		[ObservableValue]
		private string _heroEyesSpriteKey;
		[ObservableValue]
		private string _heroMouthSpriteKey;
		[ObservableValue]
		private string _heroNoseSpriteKey;
		[ObservableValue]
		private string _heroBrowsBaseSpriteKey;
		[ObservableValue]
		private string _heroBrowsSpriteKey;
		[ObservableValue]
		private string _heroTattooSpriteKey;
		[ObservableValue]
		private string _heroScarSpriteKey;
		[ObservableValue]
		private string _heroBeardSpriteKey;
		[ObservableValue]
		private string _heroBodySpriteKey;
		[ObservableValue]
		private string _heroHelmetSpriteKey;
		[ObservableValue]
		private string _heroBootsSpriteKey;
		[ObservableValue]
		private string _heroBackLeftItemSpriteKey;
		[ObservableValue]
		private string _heroBackRightItemSpriteKey;
		[ObservableValue]
		private string _heroFrontLeftItemSpriteKey;
		[ObservableValue]
		private string _heroFrontRightItemSpriteKey;
		private Generated.GraphQL.Game.Hero oldHeroObject;
		private HeroEquipment oldOwnEquipment;
		private OwnHero oldOwnHeroObject;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public Generated.GraphQL.Game.Hero heroObject { get => default; set {} }
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public OwnHero ownHeroObject { get => default; set {} }
		[ObservableValue]
		public bool portraitMode { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.HeroAppearance appearance { get => default; set {} }
		[ObservableValue]
		public Gender gender { get => default; set {} }
		[ObservableValue]
		public string heroBackSpriteHairKey { get => default; set {} }
		[ObservableValue]
		public string heroBackWithoutHelmetSpriteHairKey { get => default; set {} }
		[ObservableValue]
		public string heroFrontHairSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroFrontHairWithoutHelmetSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBaseSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroLeftArmSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroRightArmSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroEarsSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroJawSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroEyesBaseSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroEyesSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroMouthSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroNoseSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBrowsBaseSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBrowsSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroTattooSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroScarSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBeardSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBodySpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroHelmetSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBootsSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBackLeftItemSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroBackRightItemSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroFrontLeftItemSpriteKey { get => default; set {} }
		[ObservableValue]
		public string heroFrontRightItemSpriteKey { get => default; set {} }
	
		// Nested types
		public enum ArmPosition
		{
			Base = 0,
			Fist = 1,
			Up = 2
		}
	
		// Constructors
		public HeroPortraitController() {}
	
		// Methods
		protected override void Awake() {}
		public override void OnInjectedValueChanged() {}
		public void SetAppearance(TLMobile.Generated.GraphQL.Game.HeroAppearance appearance, Gender gender, bool hasHelmet = false, ArmPosition leftArm = ArmPosition.Base, ArmPosition rightArm = ArmPosition.Base, Equipment equipment = null) {}
		private void SetAppearanceInternal(TLMobile.Generated.GraphQL.Game.HeroAppearance appearance, Gender gender, Equipment equipment = null, bool hasHelmet = false, ArmPosition leftArm = ArmPosition.Base, ArmPosition rightArm = ArmPosition.Base) {}
		private void UpdateWithHero() {}
		private void UpdateWithOwnHero() {}
		private void UpdateWithOwnHeroNotSprites() {}
		private void UpdateWithOwnHeroAndEquipment() {}
		private void UpdateOwnEquipment() {}
		private void UpdateSprites(bool hasHelmet, ArmPosition leftArm, ArmPosition rightArm) {}
		private bool CheckHair(TLMobile.Generated.GraphQL.Game.HeroAppearance.AppearanceReplacementType type, bool hasHelmet) => default;
		public void PopulateWithEquipment(Equipment equipment) {}
		private void SetItemSprites(Equipment equipment) {}
	}
