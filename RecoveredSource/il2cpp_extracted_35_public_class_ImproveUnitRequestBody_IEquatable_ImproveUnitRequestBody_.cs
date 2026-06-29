	public class ImproveUnitRequestBody : IEquatable<ImproveUnitRequestBody>
	{
		// Properties
		[DataMember(Name = "action", EmitDefaultValue = true)]
		public ActionEnum Action { get; set; }
		[DataMember(Name = "unit", EmitDefaultValue = true)]
		public UnitEnum Unit { get; set; }
		[DataMember(Name = "villageId", EmitDefaultValue = false)]
		public int VillageId { get; set; }
		[DataMember(Name = "as", EmitDefaultValue = false)]
		public string As { get; set; }
	
		// Nested types
		[JsonConverter(typeof(StringEnumConverter))]
