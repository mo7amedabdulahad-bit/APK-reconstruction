// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS.GoldTransfer
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldTransferVerifyOwnershipController : CamsEmailInputTabController
	{
		// Fields
		[ObservableValue]
		private string _errorMessage;
		[SerializeField]
		private GoldTransferWindowController goldTransferController;
	
		// Properties
		[ObservableValue]
		public string errorMessage { get => default; set {} }
	
		// Constructors
		public GoldTransferVerifyOwnershipController() {}
	
		// Methods
		public override bool HasInputError() => default;
		[UICallable]
		public void Verify() {}
	}
