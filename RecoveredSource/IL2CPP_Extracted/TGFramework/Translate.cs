// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Translate : DatabindingWithLogic
	{
		// Fields
		protected string originalKey;
		private Tooltip tooltipToFeed;
		private RectTransformHelper orgRT;
		protected FilterInformation filterInfos;
		[Tooltip("This part of the translation key always remains. Even when you change the translation key via Databinding.")]
		public string prefix;
		[Tooltip("This part of the translation key always remains. Even when you change the translation key via Databinding.")]
		public string suffix;
		[Tooltip("When you don\'t use prefix+databinding to set a translation key, you have to set it here.")]
		public string defaultKey;
		[Tooltip("You don\'t have to touch this here. Usually this contains an embedded variable in the string like \"You have {{gold}} gold\"")]
		public string[] replacementKeys;
		[Tooltip("You don\'t have to touch this here. Here are the replacements for the variables above. Normally filled by the Databinding.")]
		public string[] replacementContent;
		[Tooltip("You don\'t have to touch this here. Filled in the inspector to filter the replacement contents.")]
		public string[] replacementFilters;
		[Tooltip("The key will be a boolean expression that evaluates to True or False")]
		public bool useBooleanComparison;
		public Operation booleanOperation;
		public bool hasActivationCondition;
		public bool hasGrammar;
		[NonSerialized]
		public string currentKey;
		private bool didCallUpdateDuringStart;
		private int needsUpdateInterval;
		private bool isInDestruction;
		private bool neverUpdatedText;
		private Dictionary<string, BaseTextFilter> inlineTextFilters;
		protected PooledSubText textParent;
		public static HashSet<string> usedKeys;
		private static Dictionary<string, System.Text.RegularExpressions.Match> cachedReplacementVars;
		private static Dictionary<System.Type, Queue<PooledSubText>> pooledSubTexts;
		private static Dictionary<string, KeyValuePair<int, BaseTextFilter>> possibleFilterList;
		private bool didResetOnDisable;
		private bool didRegisterObjectListener;
	
		// Nested types
		protected class FilterInformation
		{
			// Fields
			public GameObject textWrapper;
			public bool didCreateOwnWrapper;
			public int nextSibilingIndex;
			public List<PooledSubText> subObjects;
			public int subTextCount;
	
			// Constructors
			public FilterInformation() {}
		}
	
		protected class PooledSubText
		{
			// Fields
			public GameObject gameObject;
			public RectTransform rt;
			public TMP_Text textComponent;
			public TextFilter textFilter;
			public LayoutElement layoutElement;
			public CopyTextProperties copyComponent;
			public Wrapper helperWrapper;
	
			// Constructors
			public PooledSubText() {}
	
			// Methods
			public void SetText(string text) {}
			public void EnsureActive() {}
			public TextFilter EnsureTextFilter() => default;
			public static PooledSubText CreateFor(GameObject go, bool addLayoutElement = false) => default;
		}
	
		protected class TranslationResult
		{
			// Fields
			public string translatedText;
			public int needsUpdateInterval;
			public List<KeyValuePair<int, int>> insertFiltersAtPosition;
	
			// Constructors
			public TranslationResult() {}
		}
	
		// Constructors
		public Translate() {}
		static Translate() {}
	
		// Methods
		protected FilterInformation getFilterInfos() => default;
		public override void ConvertDeprecatedValues() {}
		public override void Start() {}
		private void ResetSubTexts() {}
		public override void Reset() {}
		public void SoftReset() {}
		protected override void OnEnable() {}
		private void DisableSubObject() {}
		protected void OnDisable() {}
		public override void OnDestroy() {}
		public bool AnalyzeKey() => default;
		public override List<BindableObject> GetSelectableObjects(int parameterNr, int refersToBindingNumer = -1) => default;
		public void SetNewKey(string newKey) {}
		public override void UpdateTarget() {}
		private PooledSubText CreateSubObject(string name = "") => default;
		private string ComputeFilter(int matchPos, string translatedText, int replacementNr, ref PooledSubText currentObject) => default;
		public static string DoTranslate(string key, string replaceKey, string replaceValue) => default;
		public static string DoTranslate(string key, Dictionary<string, string> replacements = null) => default;
		private static TranslationResult InnerUpdateTranslation(string completeKey, string[] replacementKeys, string[] replacementContent, string[] replacementFilters, bool overrideInlineableFilters = false, Translate translate = null, bool hasGrammar = false) => default;
		protected virtual void PostprocessTranslationResult(TranslationResult intermediateResult, bool flipPrefixAndSuffixForRTL = false) {}
		private static string FixColonPositionFromBrowserTranslation(string input, bool flipPrefixAndSuffixForRTL = false) => default;
		[ContextMenu("UpdateTranslation")]
		public void UpdateTranslation() {}
		private void TextFilterUpdateInterval() {}
		public static void CleanAllUnder(GameObject parent) {}
		public BaseTextFilter GetFilterForReplacement(string replacement, System.Type type) => default;
	}
