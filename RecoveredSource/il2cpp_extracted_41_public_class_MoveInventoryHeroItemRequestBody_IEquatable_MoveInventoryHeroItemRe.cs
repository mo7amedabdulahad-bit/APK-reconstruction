	public class MoveInventoryHeroItemRequestBody : IEquatable<MoveInventoryHeroItemRequestBody>
	{
		// Properties
		[DataMember(Name = "action", EmitDefaultValue = true)]
		public ActionEnum Action { get; set; }
		[DataMember(Name = "itemId", EmitDefaultValue = true)]
		public int ItemId { get; set; }
		[DataMember(Name = "amount", EmitDefaultValue = true)]
		public int Amount { get; set; }
		[DataMember(Name = "targetPlaceId", EmitDefaultValue = true)]
		public int TargetPlaceId { get; set; }
	
		// Nested types
		[JsonConverter(typeof(StringEnumConverter))]
