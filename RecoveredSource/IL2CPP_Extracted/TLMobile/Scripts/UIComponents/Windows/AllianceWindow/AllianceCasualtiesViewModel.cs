// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceCasualtiesViewModel : TLMViewModel
	{
		// Fields
		public CanvasBarChart barChart;
		public CanvasBarChart barChart2;
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private bool _hadError;
	
		// Properties
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public bool hadError { get => default; set {} }
	
		// Constructors
		public AllianceCasualtiesViewModel() {}
	
		// Methods
		public void Setup(int allianceId, string compareWithAllianceId) {}
	}
