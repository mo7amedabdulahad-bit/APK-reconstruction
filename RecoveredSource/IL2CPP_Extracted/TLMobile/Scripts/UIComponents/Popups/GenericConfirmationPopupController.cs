// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericConfirmationPopupController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private UnityEngine.Canvas popupCanvas;
		[ObservableValue]
		private string _titleKey;
		[ObservableValue]
		private string _buttonKey;
		[ObservableValue]
		private string _descriptionBold;
		[ObservableValue]
		private string _descriptionBold2;
		[ObservableValue]
		private string _descriptionNormal;
		[ObservableValue]
		private ButtonType _buttonType;
		[ObservableValue]
		private int _premiumCurrencyRequired;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public string titleKey { get => default; set {} }
		[ObservableValue]
		public string buttonKey { get => default; set {} }
		[ObservableValue]
		public string descriptionBold { get => default; set {} }
		[ObservableValue]
		public string descriptionBold2 { get => default; set {} }
		[ObservableValue]
		public string descriptionNormal { get => default; set {} }
		[ObservableValue]
		public ButtonType buttonType { get => default; set {} }
		[ObservableValue]
		public int premiumCurrencyRequired { get => default; set {} }
	
		// Nested types
		public enum ButtonType
		{
			Standard_Green = 0,
			Standard_Red = 1,
			Premium = 2
		}
	
		public struct PopupBuilderData
		{
			// Fields
			public string Title;
			public string Button;
			public string DescriptionBold;
			public string DescriptionBold2;
			public string DescriptionNormal;
			public ButtonType ButtonType;
			public int PremiumCurrencyRequired;
			public System.Action ConfirmCallback;
			public bool OverrideCanvasSortOrder;
			public int CanvasSortOrder;
		}
	
		// Constructors
		public GenericConfirmationPopupController() {}
	
		// Methods
		public void Setup(PopupBuilderData data) {}
		[UICallable]
		public void OnConfirmClicked() {}
	}
