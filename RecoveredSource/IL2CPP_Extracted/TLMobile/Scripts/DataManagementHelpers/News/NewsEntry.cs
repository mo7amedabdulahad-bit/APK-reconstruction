// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.News
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NewsEntry : ObservableModel, IEquatable<NewsEntry>
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private string _previewImage;
		[ObservableValue]
		private string _headerImage;
		[ObservableValue]
		private string _title;
		[ObservableValue]
		private int _date;
		[ObservableValue]
		private string _previewText;
		[ObservableValue]
		private string _fullHTMLText;
	
		// Properties
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public string previewImage { get => default; set {} }
		[ObservableValue]
		public string headerImage { get => default; set {} }
		[ObservableValue]
		public string title { get => default; set {} }
		[ObservableValue]
		public int date { get => default; set {} }
		[ObservableValue]
		public string previewText { get => default; set {} }
		[ObservableValue]
		public string fullHTMLText { get => default; set {} }
	
		// Constructors
		public NewsEntry() {}
		public NewsEntry(NewsArticle article) {}
	
		// Methods
		public bool Equals(NewsEntry other) => default;
	}
