// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DayNightController : TLMViewModel
	{
		// Fields
		private const int NightBeginHour = 22;
		private const int NightEndHour = 6;
		[ObservableValue]
		private float _dayPercent;
		[ObservableValue]
		private UnityEngine.Color _dayColor;
		[ObservableValue]
		private UnityEngine.Color _freeSpotColor;
		[ObservableValue]
		private UnityEngine.Color _nightColor;
		private bool debugDayNight;
		private bool debugDayNightWasForced;
		private bool? lastCheckWasNight;
	
		// Properties
		[ObservableValue]
		public float dayPercent { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color dayColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color freeSpotColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color nightColor { get => default; set {} }
	
		// Constructors
		public DayNightController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void SetDayPercent(float percent) {}
		public void ForceDayNightMode(bool isNight) {}
		public void PauseDayNightCycle() {}
		public void StartDayNightCycle() {}
		private void UpdateDayNight(bool instant) {}
		private bool IsNight() => default;
		public void SetDayNightDebugMode(bool debugMode) {}
		private void UpdateDayNight() {}
	}
