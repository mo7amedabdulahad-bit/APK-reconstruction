// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class EquipmentBenefitsPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<string> _equipmentBenefits;
	
		// Properties
		[ObservableValue]
		public ObservableList<string> equipmentBenefits { get => default; set {} }
	
		// Constructors
		public EquipmentBenefitsPopupController() {}
	
		// Methods
		private void _equipmentBenefitsNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Setup(HeroEquipment heroEquipment) {}
		private void UpdateEquipment(HeroEquipment equipment) {}
	}
