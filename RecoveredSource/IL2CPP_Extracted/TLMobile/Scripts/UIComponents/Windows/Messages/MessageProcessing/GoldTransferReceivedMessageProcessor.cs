// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages.MessageProcessing
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldTransferReceivedMessageProcessor : MessageProcessor
	{
		// Fields
		private const string JavaScriptMethodName = "Travian.Game.GoldTransferDialog";
	
		// Constructors
		public GoldTransferReceivedMessageProcessor() {}
	
		// Methods
		public override bool TryProcessMessage(MessageFullViewController viewController, TLMobile.Generated.GraphQL.Game.Message inputMessage, ref ProcessedMessage processedMessage) => default;
		private void Decide(GoldTransferDecideRequestBody.DecisionEnum decision, int messageId, string transactionCode, MessageFullViewController viewController) {}
	}
