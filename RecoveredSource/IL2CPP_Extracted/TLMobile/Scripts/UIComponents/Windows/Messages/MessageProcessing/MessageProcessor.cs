// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages.MessageProcessing
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class MessageProcessor
	{
		// Fields
		protected const string ParameterRegexGroup = "params";
	
		// Constructors
		protected MessageProcessor() {}
	
		// Methods
		public abstract bool TryProcessMessage(MessageFullViewController viewController, TLMobile.Generated.GraphQL.Game.Message inputMessage, ref ProcessedMessage processedMessage);
		protected Regex GetJavascriptHyperlinksRegex(string javascriptFunctionName, bool includeTrailingBrs = true) => default;
		protected string[] ExtractJavascriptParameters(System.Text.RegularExpressions.Match regexMatch) => default;
		protected string GetRegexPatternForJavascriptHyperlink(string javascriptFunctionName, bool includeTrailingBrs = true) => default;
	}
