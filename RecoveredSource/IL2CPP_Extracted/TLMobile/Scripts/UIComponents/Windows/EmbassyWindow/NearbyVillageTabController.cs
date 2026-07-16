// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.EmbassyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NearbyVillageTabController : DetailWindowTabController
	{
		// Fields
		private const int NumberOfEntries = 50;
		[ObservableValue]
		private ObservableList<VillageData> _villages;
		[SerializeField]
		private ScrollRect scrollRect;
		private OwnVillage ownVillage;
		private TweenerCore<float, float, FloatOptions> scrollUpAnimation;
	
		// Properties
		[ObservableValue]
		public ObservableList<VillageData> villages { get => default; set {} }
	
		// Nested types
		public class VillageData : ObservableModel
		{
			// Fields
			[ObservableValue]
			private Village _village;
			[ObservableValue]
			private float _distance;
	
			// Properties
			[ObservableValue]
			public Village village { get => default; set {} }
			[ObservableValue]
			public float distance { get => default; set {} }
	
			// Constructors
			public VillageData() {}
		}
	
		// Constructors
		public NearbyVillageTabController() {}
	
		// Methods
		private void _villagesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private float CalculateDistance(Village village) => default;
		[UICallable]
		public void NavigateToTop() {}
	}
