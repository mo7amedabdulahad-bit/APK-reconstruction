// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageChangeService : MonoBehaviour, IVillageChangeService
	{
		// Fields
		private OwnVillage currentVillage;
		private Wall ownWall;
		private OwnPlayer player;
	
		// Events
		public event IVillageChangeService.OnConnectedDelegate OnVillageChange;
	
		// Constructors
		public VillageChangeService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public void CallWithNewVillageData(IVillageChangeService.OnConnectedDelegate callback) {}
		public IPromise<ApiResponse<object>> VillageChangeCurrent(int villageId) => default;
		private void CurrentVillageChanged() {}
		private void VillageLoaded() {}
		public Delegate[] GetCallbackList() => default;
	}
