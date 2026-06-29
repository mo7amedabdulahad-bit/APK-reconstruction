// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceNameEditBaseController : DetailWindowController
	{
		// Fields
		public const int TagMaximumLength = 5;
		public const int NameMaximumLength = 15;
		[ObservableValue]
		private string _allianceTag;
		[ObservableValue]
		private string _allianceName;
		[ObservableValue]
		private bool _allianceTagHasError;
		[ObservableValue]
		private bool _allianceNameHasError;
		[ObservableValue]
		private string _tagError;
		[ObservableValue]
		private string _nameError;
		[ObservableValue]
		private bool _nameTouched;
		[ObservableValue]
		private bool _tagTouched;
		[ObservableValue]
		private bool _nameAndTagAreValid;
	
		// Properties
		[ObservableValue]
		public string allianceTag { get => default; set {} }
		[ObservableValue]
		public string allianceName { get => default; set {} }
		[ObservableValue]
		public bool allianceTagHasError { get => default; set {} }
		[ObservableValue]
		public bool allianceNameHasError { get => default; set {} }
		[ObservableValue]
		public string tagError { get => default; set {} }
		[ObservableValue]
		public string nameError { get => default; set {} }
		[ObservableValue]
		public bool nameTouched { get => default; set {} }
		[ObservableValue]
		public bool tagTouched { get => default; set {} }
		[ObservableValue]
		public bool nameAndTagAreValid { get => default; set {} }
	
		// Nested types
		private enum InputError
		{
			None = 0,
			Empty = 1,
			TooLong = 2
		}
	
		// Constructors
		public AllianceNameEditBaseController() {}
	
		// Methods
		private void Start() {}
		protected override void OnEnable() {}
		public void NameChanged() {}
		protected void UpdateNameAndTagAreValid() {}
		private InputError GetError(string input, int maxLength, bool checkEmpty) => default;
		public void TagChanged() {}
	}
