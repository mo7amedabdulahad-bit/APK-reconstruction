	public class DiplomacySendOfferRequest : IEquatable<DiplomacySendOfferRequest>
	{
		// Properties
		[DataMember(Name = "type", EmitDefaultValue = true)]
		public TypeEnum Type { get; set; }
		[DataMember(Name = "allianceId", EmitDefaultValue = true)]
		public int AllianceId { get; set; }
	
		// Nested types
