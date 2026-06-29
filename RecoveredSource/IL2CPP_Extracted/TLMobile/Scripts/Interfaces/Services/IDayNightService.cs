// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IDayNightService : IService
	{
		// Properties
		DayNightController DayNightController { get; set; }
	
		// Methods
		void SetDayNightDebugMode(bool debugMode);
		void ForceDayNightMode(bool isNight);
		void PauseDayNightCycle();
		void StartDayNightCycle();
	}
