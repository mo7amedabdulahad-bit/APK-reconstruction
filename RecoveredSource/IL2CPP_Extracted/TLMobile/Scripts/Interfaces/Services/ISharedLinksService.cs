// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ISharedLinksService : IService
	{
		// Properties
		WebViewLinkLocalized SupportHome { get; }
		WebViewLinkLocalized GameRules { get; }
		WebViewLinkLocalized GoldTransferInformation { get; }
	
		// Methods
		void JoinDiscord();
		void OpenDiscordChangeLog();
	}
