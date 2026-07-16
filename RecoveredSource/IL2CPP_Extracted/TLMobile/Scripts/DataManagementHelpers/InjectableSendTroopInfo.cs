// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableSendTroopInfo : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private SendTroopInfo _sendTroopInfo;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public SendTroopInfo sendTroopInfo { get => default; set {} }
	
		// Constructors
		public InjectableSendTroopInfo() {}
	}
