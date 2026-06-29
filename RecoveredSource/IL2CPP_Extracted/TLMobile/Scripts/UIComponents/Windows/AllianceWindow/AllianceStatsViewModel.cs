// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceStatsViewModel : TLMViewModel
	{
		// Fields
		public CanvasBarChart barChart;
		[ObservableValue]
		private Type _type;
	
		// Properties
		[ObservableValue]
		public Type type { get => default; set {} }
	
		// Nested types
		public enum Type
		{
			Strength = 1,
			FightingPoints = 2
		}
	
		// Constructors
		public AllianceStatsViewModel() {}
	
		// Methods
		public void Setup(Type type) {}
	}
