// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MobileSettingsController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private ObservableDictionary<Option, bool> _currentSetting;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<Option, bool> currentSetting { get => default; set {} }
	
		// Nested types
		public enum Option
		{
			None = 0,
			Animations = 1,
			NightMode = 2,
			WinterMode = 3,
			VillagePanning = 4,
			PushNotifications = 5,
			EnergySaving = 6,
			DataSaving = 7,
			AnimationsPayoffs = 8
		}
	
		// Constructors
		public MobileSettingsController() {}
	
		// Methods
		private void _currentSettingNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		[UICallable]
		public void SwitchOption(Option option) {}
	}
