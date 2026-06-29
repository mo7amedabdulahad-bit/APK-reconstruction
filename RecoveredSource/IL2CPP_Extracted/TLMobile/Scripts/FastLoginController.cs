// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FastLoginController : ViewModel, IBootable
	{
		// Fields
		private static bool isFirstLaunch;
		private string buildVersion;
	
		// Constructors
		public FastLoginController() {}
		static FastLoginController() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void DoLoginLogic() {}
		private IPromise<System.Net.HttpStatusCode> CheckURLReachable() => default;
		private void DoDirectLogin() {}
		private void OnAvatarFetched(Avatar avatar) {}
		private bool ShouldDoAuthRefreshLobby() => default;
		private void DoAuthRefreshLobby() {}
		private IPromise<OwnIdentity> ValidCookieLoginCheck(string cookie) => default;
		private void OnCookieLoginValidated() {}
		private void GoToLogin(bool resetSavedData = true) {}
	}
