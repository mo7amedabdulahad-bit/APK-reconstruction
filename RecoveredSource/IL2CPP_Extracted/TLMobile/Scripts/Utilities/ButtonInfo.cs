// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ButtonInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private string _locaKey;
		[ObservableValue]
		private ColorCfg.Type _buttonColor;
		[ObservableValue]
		private bool _isDisabled;
		[ObservableValue]
		private string _blockClickReasonLoca;
	
		// Properties
		[ObservableValue]
		public string locaKey { get => default; set {} }
		[ObservableValue]
		public ColorCfg.Type buttonColor { get => default; set {} }
		[ObservableValue]
		public bool isDisabled { get => default; set {} }
		[ObservableValue]
		public string blockClickReasonLoca { get => default; set {} }
	
		// Events
		public event System.Action OnClick;
	
		// Constructors
		private ButtonInfo() {}
		public ButtonInfo(string locaKey, ColorCfg.Type color, System.Action clickCallback) {}
	
		// Methods
		public ButtonInfo SetDisabled() => default;
		public ButtonInfo BlockClick(string reasonLocaKey) => default;
		public void InvokeOnClick() {}
	}
