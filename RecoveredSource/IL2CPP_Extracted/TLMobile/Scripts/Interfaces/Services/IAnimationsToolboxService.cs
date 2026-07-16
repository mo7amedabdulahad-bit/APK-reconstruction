// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IAnimationsToolboxService : IService
	{
		// Properties
		ICloudsController CloudsController { get; }
	
		// Events
		event LoadingAnimationHandler OnLoadingAnimation;
	
		// Nested types
		public delegate void LoadingAnimationHandler(bool visible);
	
		// Methods
		void SetLoadingAnimationState(bool visible, string reason, bool forceCallback = false);
	}
