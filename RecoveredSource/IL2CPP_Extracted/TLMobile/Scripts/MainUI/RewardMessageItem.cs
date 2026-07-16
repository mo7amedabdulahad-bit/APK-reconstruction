// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RewardMessageItem : ObservableModel
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _amount;
		[ObservableValue]
		private rewardType _rewardType;
		[ObservableValue]
		private string _text;
	
		// Properties
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int amount { get => default; set {} }
		[ObservableValue]
		public rewardType rewardType { get => default; set {} }
		[ObservableValue]
		public string text { get => default; set {} }
	
		// Constructors
		public RewardMessageItem() {}
		public RewardMessageItem(rewardType rewardType, int id, int amount) {}
	}
