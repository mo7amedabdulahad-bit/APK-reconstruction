// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DayNightService : MonoBehaviour, IDayNightService
	{
		// Properties
		public DayNightController DayNightController { get; set; }
	
		// Constructors
		public DayNightService() {}
	
		// Methods
		public void SetDayNightDebugMode(bool debugMode) {}
		public void ForceDayNightMode(bool isNight) {}
		public void PauseDayNightCycle() {}
		public void StartDayNightCycle() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
	}
