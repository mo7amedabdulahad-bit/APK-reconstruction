// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroForgeProbabilityController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private ObservableDictionary<int, float> _chancesRarity;
		[ObservableValue]
		private ObservableDictionary<int, float> _chancesQuality;
		private CraftingItems crafting;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<int, float> chancesRarity { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, float> chancesQuality { get => default; set {} }
	
		// Constructors
		public HeroForgeProbabilityController() {}
	
		// Methods
		private void _chancesRarityNotify(object sender, PropertyChangedEventArgs args) {}
		private void _chancesQualityNotify(object sender, PropertyChangedEventArgs args) {}
		public void UpdateForgingChances(int m1, int m2, int m3) {}
		public void UpdateForgingChancesWithServerReply(List<QualityProbability> qualityList, List<RarityProbability> rarityList) {}
	}
