	public class TradeRoutesUpdateRequestBodyTargetCoordinates : IEquatable<TradeRoutesUpdateRequestBodyTargetCoordinates>
	{
		// Properties
		[DataMember(Name = "x", EmitDefaultValue = true)]
		public int X { get; set; }
		[DataMember(Name = "y", EmitDefaultValue = true)]
		public int Y { get; set; }
	
		// Constructors
		[JsonConstructor]
		protected TradeRoutesUpdateRequestBodyTargetCoordinates() {}
		public TradeRoutesUpdateRequestBodyTargetCoordinates(int x = 0, int y = 0) {}
	
		// Methods
		public override string ToString() => default;
		public virtual string ToJson() => default;
		public override bool Equals(object input) => default;
		public bool Equals(TradeRoutesUpdateRequestBodyTargetCoordinates input) => default;
		public override int GetHashCode() => default;
	}
