// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAppearanceController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private Gender _selectedGender;
		[ObservableValue]
		private SkinColor _selectedSkinColor;
		[ObservableValue]
		private ObservableList<SkinColor> _skinColorOptions;
		[ObservableValue]
		private HeroAppearanceCategories _allCategories;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.HeroAppearance _temporaryHeroAppearance;
		[ObservableValue]
		private ChangedOptionsFlags _changedOptions;
		[SerializeField]
		private HeroPortraitController portraitController;
		[SerializeField]
		private float animationMovePosition;
		[SerializeField]
		private float animationMoveDuration;
		private OwnHero hero;
		private Gender originalGender;
		private TLMobile.Generated.GraphQL.Game.HeroAppearance tempFemaleAppearance;
		private TLMobile.Generated.GraphQL.Game.HeroAppearance tempMaleAppearance;
		private DG.Tweening.Sequence moveAnimationSequence;
	
		// Properties
		[ObservableValue]
		public Gender selectedGender { get => default; set {} }
		[ObservableValue]
		public SkinColor selectedSkinColor { get => default; set {} }
		[ObservableValue]
		public ObservableList<SkinColor> skinColorOptions { get => default; set {} }
		[ObservableValue]
		public HeroAppearanceCategories allCategories { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.HeroAppearance temporaryHeroAppearance { get => default; set {} }
		[ObservableValue]
		public ChangedOptionsFlags changedOptions { get => default; set {} }
	
		// Nested types
		[Flags]
		public enum ChangedOptionsFlags
		{
			None = 0,
			Gender = 1,
			SkinColor = 2,
			Appearance = 4
		}
	
		// Constructors
		public HeroAppearanceController() {}
	
		// Methods
		private void _skinColorOptionsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnDestroy() {}
		private void InitHeroData() {}
		private void ResetAppearanceToBackendState() {}
		private void ResetAppearance() {}
		[UICallable]
		public void SetGender(Gender gender) {}
		[UICallable]
		public void SetSkinColor(SkinColor skinColor) {}
		[UICallable]
		public void RandomizeAppearance() {}
		private string ChooseRandomColor(IEnumerable<HeroAppearanceCategory> categories, CategoryCode categoryCode) => default;
		private int? ChooseRandomOption(IEnumerable<HeroAppearanceCategory> categories, CategoryCode categoryCode) => default;
		private TLMobile.Generated.GraphQL.Game.HeroAppearance GetSavedAppearance(Gender gender) => default;
		[UICallable]
		public void SaveChanges() {}
		private RestAPI.Game.Model.HeroAppearance ConvertHeroAppearanceForRestApi(TLMobile.Generated.GraphQL.Game.HeroAppearance appearance) => default;
		private void SetChanged(ChangedOptionsFlags flag, bool hasFlagChanged) {}
		private void PlayChangeGenderAnimation(Gender newGender) {}
		private void UpdateAppearance() {}
	}
