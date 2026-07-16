// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportsSurroundingTabController : DetailWindowTabController
	{
		// Fields
		public ScrollRect scrollRect;
		[ObservableValue]
		private PaginatedListProvider<SurroundingReport> _reportsPaginatedData;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public PaginatedListProvider<SurroundingReport> reportsPaginatedData { get => default; set {} }
	
		// Constructors
		public ReportsSurroundingTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage currentVillage) {}
		private void ScrollChanged(Vector2 arg0) {}
	}
