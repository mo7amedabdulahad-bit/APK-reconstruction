// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Tests.Editor.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroChangeListener : ViewModel
	{
		// Fields
		[ObservableValue]
		private int _changeSerial;
		private OwnHero hero;
		private string oldHash;
		private float oldHealth;
		private int oldPoints;
		private int oldStatus;
		private int oldXp;
	
		// Properties
		[ObservableValue]
		public int changeSerial { get => default; set {} }
	
		// Constructors
		public HeroChangeListener() {}
	
		// Methods
		public void Start() {}
		private void UpdateHero() {}
	}
