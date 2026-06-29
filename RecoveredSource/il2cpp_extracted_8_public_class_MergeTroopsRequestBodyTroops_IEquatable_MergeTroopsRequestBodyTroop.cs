	public class MergeTroopsRequestBodyTroops : IEquatable<MergeTroopsRequestBodyTroops>
	{
		// Properties
		[DataMember(Name = "t1", EmitDefaultValue = true)]
		public int T1 { get; set; }
		[DataMember(Name = "t2", EmitDefaultValue = true)]
		public int T2 { get; set; }
		[DataMember(Name = "t3", EmitDefaultValue = true)]
		public int T3 { get; set; }
		[DataMember(Name = "t4", EmitDefaultValue = true)]
		public int T4 { get; set; }
		[DataMember(Name = "t5", EmitDefaultValue = true)]
		public int T5 { get; set; }
		[DataMember(Name = "t6", EmitDefaultValue = true)]
		public int T6 { get; set; }
	
		// Constructors
		[JsonConstructor]
		protected MergeTroopsRequestBodyTroops() {}
		public MergeTroopsRequestBodyTroops(int t1 = 0, int t2 = 0, int t3 = 0, int t4 = 0, int t5 = 0, int t6 = 0) {}
	
		// Methods
		public override string ToString() => default;
		public virtual string ToJson() => default;
		public override bool Equals(object input) => default;
		public bool Equals(MergeTroopsRequestBodyTroops input) => default;
		public override int GetHashCode() => default;
	}
