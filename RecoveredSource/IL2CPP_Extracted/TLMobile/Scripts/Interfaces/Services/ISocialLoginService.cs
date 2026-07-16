// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ISocialLoginService : IService
	{
		// Properties
		string CurrentVerifier { get; set; }
		string CurrentCode { get; set; }
	
		// Methods
		void LaunchGoogleLogin(Action<Func<Promise<AuthorisationSuccess>>, SocialRegistrationError> socialLoginResults);
		void SignOutGoogle();
		void LaunchFacebookLogin(Action<Func<Promise<AuthorisationSuccess>>, SocialRegistrationError> socialLoginResults);
		void LaunchAppleLogin(Action<Func<Promise<AuthorisationSuccess>>, SocialRegistrationError> socialLoginResults);
	}
