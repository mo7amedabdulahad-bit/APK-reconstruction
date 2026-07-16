// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilterCountdown : TextFilterDate
	{
		// Properties
		public override int Id { get => default; }
		public override string ShortName { get => default; }
		public override string Name { get => default; }
		public override string NeededParameterName { get => default; }
		public override int NeedsUpdateInterval { get => default; }
	
		// Constructors
		public TextFilterCountdown() {}
	
		// Methods
		protected virtual string GetCountdown(bool shortFormat = false) => default;
		protected virtual string GetTimeLeft(int secondsLeft) => default;
		public static string GetTimeLeftShort(int secondsLeft) => default;
		public override string FilterInput(string textToFilter, int parameter = 0, int secondParameter = 0, TextFilter component = null) => default;
	}
