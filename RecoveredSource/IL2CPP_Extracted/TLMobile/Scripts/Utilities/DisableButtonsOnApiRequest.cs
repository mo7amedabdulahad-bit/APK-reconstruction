// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DisableButtonsOnApiRequest : MonoBehaviour, IDoubleClickProtectionService
	{
		// Fields
		private readonly List<ToggledButton> buttonsWaitingToGetActiveAgain;
		private int runningRequests;
	
		// Properties
		public int RunningRequests { get => default; private set {} }
	
		// Constructors
		public DisableButtonsOnApiRequest() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void Update() {}
		private void OnDestroy() {}
		public void BlockButtonClicks(object blocker) {}
		public void UnblockButtonClicks(object blocker) {}
		public void ApiClientOnApiRequestSent(HTTPRequest request) {}
		public void ApiClientOnApiRequestFinished(HTTPRequest response) {}
		public void OnGraphQlRequestSent(GraphQLRequest request) {}
		public void OnGraphQlRequestFinished(GraphQLRequest response) {}
		public void AddButtonOnActivationWaitingList(GameObject clickedGameObject) {}
		public void ReEnableButton(ToggledButton toggledButton) {}
		private void ForceDataBindingUpdate(GameObject objectToUpdate) {}
	}
