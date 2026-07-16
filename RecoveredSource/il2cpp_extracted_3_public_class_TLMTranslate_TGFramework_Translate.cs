	public class TLMTranslate : TGFramework.Translate
	{
		// Fields
		[SerializeField]
		[Tooltip("Enabled by default. When the UI layout is not mirrored in RTL, this flips the prefix and suffix to match RTL reading (e.g., \':\u0645\u0646\u0637\u0642\u0629 \u0627\u0644\u062A\u0648\u0642\u064A\u062A\' becomes \'\u0645\u0646\u0637\u0642\u0629 \u0627\u0644\u062A\u0648\u0642\u064A\u062A:\'). If the layout *is* mirrored, disable this \u2014 as prefix/suffix will appear in the correct order naturally.")]
		private bool flipPrefixAndSuffixForRTL;
		public string addPrefix;
		public string addSuffix;
		public string removePrefix;
		public string removeSuffix;
		public TextFilterFirstLetter.ChangeType changeFirstLetter;
	
		// Constructors
		public TLMTranslate() {}
	
		// Methods
		protected override void PostprocessTranslationResult(TranslationResult intermediateResult, bool _ = false) {}
	}
