// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class AbstractBBCodeLineBreakRegex : IBBCode
	{
		// Properties
		public abstract string TagId { get; }
		public bool BreaksText { get; }
	
		// Constructors
		protected AbstractBBCodeLineBreakRegex() {}
	
		// Methods
		public string Wrap(string text) => default;
		public TextPart Replace(string input) => default;
		public void ReplaceTextWithLineBreak(List<TextPart> textParts) {}
		protected virtual MatchCollection GetMatches(string input, string tag) => default;
		protected abstract GameObject GetNewValue(System.Text.RegularExpressions.Match match);
	}
