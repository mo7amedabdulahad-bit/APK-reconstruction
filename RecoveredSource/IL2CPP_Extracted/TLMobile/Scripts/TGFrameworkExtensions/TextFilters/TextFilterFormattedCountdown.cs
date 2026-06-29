// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions.TextFilters
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilterFormattedCountdown : TextFilterCountdown
	{
		// Fields
		private int secondParameter;
	
		// Properties
		private static double SecondsAWeek { get => default; }
		private static double SecondsADay { get => default; }
		private static double SecondsAHour { get => default; }
		public override int Id { get => default; }
		public override string ShortName { get => default; }
		public override string Name { get => default; }
		public override string NeededParameterName { get => default; }
		public override string NeededParameterName2 { get => default; }
		public override int NeedsUpdateInterval { get => default; }
		public override string NeededBoolParameterName { get => default; }
	
		// Constructors
		public TextFilterFormattedCountdown() {}
	
		// Methods
		protected override string GetCountdown(bool shortFormat = false) => default;
		protected override string GetTimeLeft(int secondsLeft) => default;
		public override string FilterInput(string textToFilter, int parameter = 0, int secondParameter = 3, TextFilter component = null) => default;
	}
