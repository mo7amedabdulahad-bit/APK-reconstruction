// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorEquipmentDTO
	{
		// Fields
		public int? tribeId;
		public List<CombatSimulatorEquipmentSlotDTO> leftHand;
		public List<CombatSimulatorEquipmentSlotDTO> rightHand;
		public List<CombatSimulatorEquipmentSlotDTO> body;
		public CombatSimulatorEquipmentSlotDTO bag;
	
		// Constructors
		public CombatSimulatorEquipmentDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
