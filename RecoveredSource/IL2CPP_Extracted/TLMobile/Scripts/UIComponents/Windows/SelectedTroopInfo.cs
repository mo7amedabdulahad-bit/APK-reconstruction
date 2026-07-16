// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SelectedTroopInfo : ObservableModel, IComparable
	{
		// Fields
		[ObservableValue]
		private TroopInfo _info;
		[ObservableValue]
		private int _selectedAmount;
		[ObservableValue]
		private int _remainingAmount;
	
		// Properties
		[ObservableValue]
		public TroopInfo info { get => default; set {} }
		[ObservableValue]
		public int selectedAmount { get => default; set {} }
		[ObservableValue]
		public int remainingAmount { get => default; set {} }
	
		// Constructors
		public SelectedTroopInfo() {}
		public SelectedTroopInfo(bool startObserve) {}
	
		// Methods
		public int CompareTo(object obj) => default;
		private void SelectedAmountChanged() {}
		private void CalculateRemainingAmount() {}
	}
