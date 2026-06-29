	public class DemolishImmediatelyRequest : IEquatable<DemolishImmediatelyRequest>
	{
		// Properties
		[DataMember(Name = "action", EmitDefaultValue = true)]
		public ActionEnum Action { get; set; }
		[DataMember(Name = "villageId", EmitDefaultValue = true)]
		public int VillageId { get; set; }
		[DataMember(Name = "slotId", EmitDefaultValue = true)]
		public int SlotId { get; set; }
	
		// Nested types
		[JsonConverter(typeof(StringEnumConverter))]
