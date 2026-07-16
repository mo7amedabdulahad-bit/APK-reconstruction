// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.RateThisApp
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoogleReviewManager : IReviewManager
	{
		// Fields
		private PlayReviewInfo _playReviewInfo;
		private ReviewManager _reviewManager;
	
		// Constructors
		public GoogleReviewManager() {}
	
		// Methods
		public void Initialize() {}
		public void LaunchReviewFlow() {}
		private void OnReviewFlowCompleted(PlayAsyncOperation<PlayReviewInfo, ReviewErrorCode> requestFlowOperation) {}
		private void OnLaunchFlowOperationCompleted(PlayAsyncOperation<VoidResult, ReviewErrorCode> launchFlowOperation) {}
	}
