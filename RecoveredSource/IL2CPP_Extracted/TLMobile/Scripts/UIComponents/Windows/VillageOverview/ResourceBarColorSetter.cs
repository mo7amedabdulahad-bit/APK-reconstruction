// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceBarColorSetter : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private AdditionalResourceInfo _additionalResourceInfo;
		[ObservableValue]
		private Color _color;
		[ObservableValue]
		private bool _redBorder;
		private AdditionalResourceInfo oldValue;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public AdditionalResourceInfo additionalResourceInfo { get => default; set {} }
		[ObservableValue]
		public Color color { get => default; set {} }
		[ObservableValue]
		public bool redBorder { get => default; set {} }
	
		// Nested types
		public enum Color
		{
			Green = 0,
			Yellow = 1,
			Red = 2
		}
	
		// Constructors
		public ResourceBarColorSetter() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		private void UpdateColor() {}
	}
