// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions.TextFilters
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InlineFiltersInterpreter : MonoBehaviour
	{
		// Fields
		private static Dictionary<string, BaseTextFilter> inlineableFilterTypes;
		private Dictionary<string, BaseTextFilter> inlineTextFilters;
		private string lastResult;
		private string previousValue;
		private TMP_Text textComponent;
		private Action<string> updateCallback;
	
		// Constructors
		public InlineFiltersInterpreter() {}
	
		// Methods
		private void Awake() {}
		protected void OnEnable() {}
		private void OnDestroy() {}
		public void RegisterUpdateCallback(Action<string> callback) {}
		public string RenderInlinedFilters(string valueToParse, bool forceRefresh = false) => default;
		public void UpdateState() {}
		private BaseTextFilter GetFilterForReplacement(string replacement, System.Type type) => default;
	}
