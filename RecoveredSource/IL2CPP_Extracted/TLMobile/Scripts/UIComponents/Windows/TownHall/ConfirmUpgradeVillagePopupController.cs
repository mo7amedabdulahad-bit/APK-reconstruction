// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TownHall
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmUpgradeVillagePopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnVillage _ownVillage;
		[ObservableValue]
		private float _timeToUpgrade;
		private System.Action confirmVillageUpgradeCallback;
	
		// Properties
		[ObservableValue]
		public OwnVillage ownVillage { get => default; set {} }
		[ObservableValue]
		public float timeToUpgrade { get => default; set {} }
	
		// Constructors
		public ConfirmUpgradeVillagePopupController() {}
	
		// Methods
		public void Setup(OwnVillage ownVillage, System.Action confirmCallback) {}
		[UICallable]
		public void ConfirmUpgradeVillage() {}
	}
