// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BBCodeCasualties : AbstractBBCodeLineBreakRegex, IBBCodeInsertable, IBBCodeNeedsAllianceId
	{
		// Fields
		private int allianceId;
	
		// Properties
		public override string TagId { get => default; }
		public string Name { get => default; }
		public string Description { get => default; }
		public string Example { get => default; }
	
		// Constructors
		public BBCodeCasualties() {}
	
		// Methods
		public void SetAllianceId(int allianceId) {}
		protected override GameObject GetNewValue(System.Text.RegularExpressions.Match match) => default;
	}
