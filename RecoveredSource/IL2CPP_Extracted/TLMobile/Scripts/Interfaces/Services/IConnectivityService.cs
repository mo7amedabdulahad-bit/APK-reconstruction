// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IConnectivityService : IService
	{
		// Properties
		bool HasInternetConnection { get; }
		Action<bool> OnInternetConnectionChanged { get; set; }
	
		// Methods
		System.Threading.Tasks.Task WaitForOrTimeout(Func<bool> condition, System.Action onSuccess, System.Action onFail, int timeoutSeconds = 10, int? checkAvailabilityInterval = default);
	}
