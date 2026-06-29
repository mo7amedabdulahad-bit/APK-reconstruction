// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BBCodeMedals : IBBCode
	{
		// Fields
		private Alliance alliance;
		private TLMobile.Generated.GraphQL.Game.Player player;
	
		// Properties
		public bool BreaksText { get => default; }
	
		// Constructors
		public BBCodeMedals() {}
	
		// Methods
		public string Wrap(string text) => default;
		public TextPart Replace(string text) => default;
		public void ReplaceTextWithLineBreak(List<TextPart> textParts) {}
		public void FetchAsync(int allianceId, int playerId, System.Action afterFetchCallback) {}
		private void ReplaceAllianceMedals(List<TextPart> textParts) {}
		private void ReplacePlayerMedals(List<TextPart> textParts) {}
		private void InsertMedalsInTextParts(string medalTextMatch, List<TextPart> textParts, Func<GameObject> createMedalGameObject) {}
	}
