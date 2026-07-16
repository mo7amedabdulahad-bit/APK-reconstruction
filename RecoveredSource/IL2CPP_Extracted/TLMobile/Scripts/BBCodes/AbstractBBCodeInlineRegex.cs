// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class AbstractBBCodeInlineRegex : IBBCode
	{
		// Properties
		public abstract string TagId { get; }
		public bool BreaksText { get; }
	
		// Constructors
		protected AbstractBBCodeInlineRegex() {}
	
		// Methods
		public string Wrap(string text) => default;
		public TextPart Replace(string text) => default;
		public void ReplaceTextWithLineBreak(List<TextPart> textParts) {}
		protected virtual MatchCollection GetMatches(string input, string tag) => default;
		protected abstract string GetNewValue(System.Text.RegularExpressions.Match match);
	}
