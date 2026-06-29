// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class AbstractBBCodeDiplomacy : AbstractBBCodeLineBreakRegex, IBBCodeNeedsAllianceId, IBBCodeInsertable
	{
		// Fields
		private int allianceId;
	
		// Properties
		protected abstract AllianceDiplomacyViewModel.DisplayedInformation DiplomacyType { get; }
		public abstract string TagId { get; }
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract string Example { get; }
	
		// Constructors
		protected AbstractBBCodeDiplomacy() {}
	
		// Methods
		public void SetAllianceId(int allianceId) {}
		protected override GameObject GetNewValue(System.Text.RegularExpressions.Match match) => default;
		protected override MatchCollection GetMatches(string input, string tag) => default;
	}
