// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilter : Databinding
	{
		// Fields
		public int modificationType;
		public int modificationParam;
		public int modificationParam2;
		public bool modificationBool;
		private Wrapper targetWrapper;
		private string _textToFilter;
		private int _optionalValue;
		private int _secondOptionalValue;
		private bool _optionalBinary;
		private DateTime _timestampToUse;
		public string optionalStringValue;
		public string optionalStringValue2;
		private int _overrideUpdateInterval;
		private string filteredValue;
		private bool updateNow;
		public static CultureInfo useCulture;
		private static List<BaseTextFilter> _allAvailableFilters;
		private BaseTextFilter _myFilterToUse;
		private bool initializedInterpolationLoop;
	
		// Properties
		public int optionalValue { get => default; set {} }
		public int secondOptionalValue { get => default; set {} }
		public bool optionalBinary { get => default; set {} }
		public string textToFilter { get => default; set {} }
		public DateTime timestampToUse { get => default; set {} }
		public int overrideUpdateInterval { get => default; set {} }
		public static List<BaseTextFilter> AllAvailableFilters { get => default; }
		private BaseTextFilter myFilterToUse { get => default; }
	
		// Constructors
		public TextFilter() {}
		static TextFilter() {}
	
		// Methods
		public void SetModificationType(int newType) {}
		public override void Reset() {}
		public void Filter(string source) {}
		private void SearchTargetComponent() {}
		public override void UpdateTarget() {}
		public override void Start() {}
		public void UpdateWithNewFilteredValue(string newString) {}
		private int GetUpdateInterval() => default;
		protected void StartInterpolationLoop() {}
		protected void StopInterpolationLoop() {}
		public override void DoUpdateLoop() {}
		public override void OnDestroy() {}
		public BaseTextFilter GetFilterConfig() => default;
	}
