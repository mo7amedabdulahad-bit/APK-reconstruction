// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DeepLinkActionService : MonoBehaviour, IDeepLinkActionService
	{
		// Fields
		private const string DeepLinkPrefix = "travian.com://#";
		private const string DeepLinkGameworldPrefix = "gw";
		public const string DeepLinkNewsIDPrefix = "id";
		private static readonly Dictionary<ActionKey, string> DeepLinks;
		private const float ExtraEqualDeeplinkCoolDown = 2f;
		private Dictionary<string, Func<Dictionary<string, string>, bool>> actionDictionary;
		private UniversalDeepLinkingService.LinkActivationResult lastLinkActivation;
	
		// Nested types
		public enum ActionKey
		{
			Activation = 0,
			SetNewPassword = 1,
			Registration = 2,
			LoginLobby = 3,
			GameworldOverview = 4,
			JoinGameworld = 5,
			Calendar = 6,
			News = 7,
			ConfirmNewEmail = 8,
			TransferGold = 9
		}
	
		// Constructors
		public DeepLinkActionService() {}
		static DeepLinkActionService() {}
	
		// Methods
		public static string GetDeepLink(ActionKey key) => default;
		private void OnDestroy() {}
		private void SetupActionDictionary() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private static void OnLinkActivationResultChanged(UniversalDeepLinkingService.LinkActivationResult lastLinkActivation) {}
		private void OpenUnRecognizedLinkPopup(UniversalDeepLinkingService.LinkActivationResult linkActivationResult) {}
		public bool TryResumeWithLastUnRecognizedLink(UniversalDeepLinkingService.LinkActivationResult lastLinkActivation, out LinkNotWorkingPopupController linkNotWorkingPopupController) {
			linkNotWorkingPopupController = default;
			return default;
		}
		private Action<Dictionary<string, string>> DeepLinkAction(KeyValuePair<string, Func<Dictionary<string, string>, bool>> action) => default;
		public bool TryResumeWithLastRecognizedDeeplinkAction() => default;
		private bool Activation(Dictionary<string, string> queryStrings) => default;
		private bool SetNewPassword(Dictionary<string, string> queryStrings) => default;
		private bool LoginLobby(Dictionary<string, string> queryStrings) => default;
		private bool Registration(Dictionary<string, string> queryStrings) => default;
		private bool GameworldOverview(Dictionary<string, string> queryStrings) => default;
		private bool JoinGameworld(Dictionary<string, string> queryStrings) => default;
		private bool Calendar(Dictionary<string, string> queryStrings) => default;
		private bool News(Dictionary<string, string> queryStrings) => default;
		private bool ConfirmNewEmail(Dictionary<string, string> queryStrings) => default;
		private bool TransferGold(Dictionary<string, string> queryStrings) => default;
		private bool HandleDeepLink<TWindow>(Action<TWindow> setupAction, Func<bool> actionCondition, System.Action onConditionFailed)
			where TWindow : DetailWindowController => default;
		private bool AreConditionsMet(params Func<bool>[] conditions) => default;
		private bool IsNotLoggedInToLobby() => default;
		private bool IsNotLoggedIntoGameworld() => default;
		private void TryAtLaterGameState() {}
		private void LogoutAndRetry() {}
	}
