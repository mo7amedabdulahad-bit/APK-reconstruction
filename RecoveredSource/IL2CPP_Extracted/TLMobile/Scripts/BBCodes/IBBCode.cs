// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IBBCode
	{
		// Properties
		bool BreaksText { get; }
	
		// Methods
		string Wrap(string text);
		TextPart Replace(string text);
		void ReplaceTextWithLineBreak(List<TextPart> textParts);
	}
