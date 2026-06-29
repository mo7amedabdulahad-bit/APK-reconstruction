// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS.GoldTransfer
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AvatarGameworldInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private string _avatarName;
		[ObservableValue]
		private string _gameworldName;
	
		// Properties
		[ObservableValue]
		public string avatarName { get => default; set {} }
		[ObservableValue]
		public string gameworldName { get => default; set {} }
		public string AvatarUuid { get; }
		public string GameWorldUuid { get; }
	
		// Constructors
		private AvatarGameworldInfo() {}
		public AvatarGameworldInfo(string avatarUuid, string gameWorldUuid, string avatarName, string gameworldName) {}
	}
