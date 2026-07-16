// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IVillageChangeService : IService
	{
		// Events
		event OnConnectedDelegate OnVillageChange;
	
		// Nested types
		public delegate void OnConnectedDelegate(OwnVillage village);
	
		// Methods
		void CallWithNewVillageData(OnConnectedDelegate callback);
		IPromise<ApiResponse<object>> VillageChangeCurrent(int villageId);
	}
