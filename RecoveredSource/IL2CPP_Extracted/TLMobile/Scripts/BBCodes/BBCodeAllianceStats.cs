// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.BBCodes
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BBCodeAllianceStats : AbstractBBCodeLineBreakRegex, IBBCodeInsertable
	{
		// Fields
		private const string FightingPointsKey = "stats_fightingPoints";
		private const string FightingPowerKey = "stats_fightingPower";
	
		// Properties
		public override string TagId { get => default; }
		public virtual string Name { get => default; }
		public virtual string Description { get => default; }
		public virtual string Example { get => default; }
	
		// Constructors
		public BBCodeAllianceStats() {}
	
		// Methods
		protected override GameObject GetNewValue(System.Text.RegularExpressions.Match match) => default;
	}
