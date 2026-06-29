// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilterDate : BaseTextFilter
	{
		// Fields
		private const int ServerTimeOffsetHours = 1;
		protected long timestamp;
	
		// Properties
		public override int Id { get => default; }
		public override string ShortName { get => default; }
		public override string Name { get => default; }
		public override bool Inlineable { get => default; }
		public override string NeededParameterName { get => default; }
		public override string NeededBoolParameterName { get => default; }
	
		// Constructors
		public TextFilterDate() {}
	
		// Methods
		protected long AdjustTimestampToConfigTimezone(long timestamp) => default;
		protected string GetDate(bool hideYear) => default;
		private static string ReplaceDaysAndMonths() => default;
		public static string GetDayMonthPattern() => default;
		protected string GetTime(bool hideSec) => default;
		protected void PrepareFilter(string textToFilter, TextFilter component) {}
		public override string FilterInput(string textToFilter, int parameter = 0, int secondParameter = 0, TextFilter component = null) => default;
	}
