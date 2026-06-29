// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages.IconSelection
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class IconSelectionCategory : ObservableModel, IComparable<IconSelectionCategory>
	{
		// Fields
		[ObservableValue]
		[SerializeField]
		private string _translationKey;
		[ObservableValue]
		[SerializeField]
		private IconTypeSpriteCfg _spriteCfgType;
		[ObservableValue]
		private ObservableList<IconSelectionDataObject> _iconObjects;
	
		// Properties
		[ObservableValue]
		public string translationKey { get => default; set {} }
		[ObservableValue]
		public IconTypeSpriteCfg spriteCfgType { get => default; set {} }
		[ObservableValue]
		public ObservableList<IconSelectionDataObject> iconObjects { get => default; set {} }
	
		// Constructors
		public IconSelectionCategory() {}
	
		// Methods
		private void _iconObjectsNotify(object sender, PropertyChangedEventArgs args) {}
		public int CompareTo(IconSelectionCategory other) => default;
		public static bool operator ==(IconSelectionCategory a, IconSelectionCategory b) => default;
		public static bool operator !=(IconSelectionCategory a, IconSelectionCategory b) => default;
		public bool Equals(IconSelectionCategory other) => default;
		public override bool Equals(object obj) => default;
		public override int GetHashCode() => default;
	}
