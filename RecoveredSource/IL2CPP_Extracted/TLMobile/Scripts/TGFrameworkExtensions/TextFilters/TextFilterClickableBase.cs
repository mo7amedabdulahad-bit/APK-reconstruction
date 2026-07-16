// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions.TextFilters
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class TextFilterClickableBase : BaseTextFilter
	{
		// Fields
		private static int nextLinkId;
		protected TextFilter currentTextFilter;
		protected GameObject gameObject;
		protected InlineFiltersInterpreter inlineFiltersInterpreter;
		protected int inputId;
		protected string invalidLinkTranslationKey;
		protected bool isClickable;
		protected bool linkIsInvalid;
		protected int myLinkId;
		protected string originalInputString;
		protected string outputString;
		protected int selectedColor;
	
		// Properties
		public override string NeededParameterName { get; }
		public override string NeededParameterName2 { get; }
		public override bool Inlineable { get; }
		public override bool InlineableButNeedsOwnObject { get; }
		public virtual string OutputWhenNull { get; }
	
		// Constructors
		protected TextFilterClickableBase() {}
		static TextFilterClickableBase() {}
	
		// Methods
		protected void SetLinkAsInvalid(string translateKey) {}
		protected string ValidateFilterInput(string textToFilter, int parameter = 0, int secondParameter = 0, TextFilter component = null) => default;
		public override string FilterInput(string textToFilter, int parameter = 0, int secondParameter = 0, TextFilter component = null) => default;
		protected abstract string GetOutputString(int id);
		protected abstract void ClickBehaviour();
		protected virtual string GetClickableString(string inputString) => default;
		protected void UpdateWithNewFilteredValue(string newString) {}
		protected void SetMouseBehaviours(bool isClickable) {}
		protected void CheckClickOnLink(PointerEventData data) {}
		public void InjectInlineFiltersInterpreter(InlineFiltersInterpreter interpreter) {}
	}
