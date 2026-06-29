// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MedalsPicker : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<MedalData> _medals;
		private Action<string> onMedalSelected;
	
		// Properties
		[ObservableValue]
		public ObservableList<MedalData> medals { get => default; set {} }
	
		// Nested types
		public class MedalData : ObservableModel
		{
			// Fields
			[ObservableValue]
			private string _categoryName;
			[ObservableValue]
			private int _id;
			[ObservableValue]
			private string _imgUrl;
			[ObservableValue]
			private string _medalCode;
			[ObservableValue]
			private MedalType _medalType;
			[ObservableValue]
			private int _rank;
			[ObservableValue]
			private int _spriteIndex;
			[ObservableValue]
			private int _week;
	
			// Properties
			[ObservableValue]
			public string categoryName { get => default; set {} }
			[ObservableValue]
			public int id { get => default; set {} }
			[ObservableValue]
			public string imgUrl { get => default; set {} }
			[ObservableValue]
			public string medalCode { get => default; set {} }
			[ObservableValue]
			public MedalType medalType { get => default; set {} }
			[ObservableValue]
			public int rank { get => default; set {} }
			[ObservableValue]
			public int spriteIndex { get => default; set {} }
			[ObservableValue]
			public int week { get => default; set {} }
	
			// Constructors
			public MedalData() {}
		}
	
		public enum MedalType
		{
			AllianceMedal = 0,
			GameworldMedal = 1,
			GloriaMedal = 2
		}
	
		// Constructors
		public MedalsPicker() {}
	
		// Methods
		private void _medalsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(IList<MedalData> availableMedals, Action<string> callback) {}
		[UICallable]
		public void SelectMedal(MedalData medal) {}
		public static string GetMedalCode(string medalId, bool isGloriaMedal) => default;
	}
