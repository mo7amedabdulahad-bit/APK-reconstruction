// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions.TextFilters
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilterBBCodes : BaseTextFilter
	{
		// Fields
		private readonly List<GameObject> createdChildObjects;
		private readonly IBBCode lineBreaksHandler;
		private readonly List<IBBCode> validCodes;
		protected GameObject gameObject;
		private string lastRenderedString;
		private string lastTranslatedString;
	
		// Properties
		public override int Id { get => default; }
		public override string ShortName { get => default; }
		public override string Name { get => default; }
		public override string NeededParameterName { get => default; }
		public override string NeededParameterName2 { get => default; }
		public override string NeededBoolParameterName { get => default; }
		public override bool Inlineable { get => default; }
	
		// Constructors
		public TextFilterBBCodes() {}
		public TextFilterBBCodes(List<IBBCode> validCodes) {}
	
		// Methods
		public override string FilterInput(string textToFilter, int parameter = 0, int secondParameter = 0, TextFilter component = null) => default;
		private string DoFilter(string textToFilter, TextFilter component, bool putTextInASeparateBox) => default;
		private static TMP_Text GetConfiguredGameObjWithText(string name, bool useTextPrefab, UnityEngine.Component sourceStyle = null) => default;
		private void SetMouseBehaviours() {}
		private void HandleLongPress(PointerEventData d) {}
	}
