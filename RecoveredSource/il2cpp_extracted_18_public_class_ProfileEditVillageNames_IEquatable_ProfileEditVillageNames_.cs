	public class ProfileEditVillageNames : IEquatable<ProfileEditVillageNames>
	{
		// Properties
		[DataMember(Name = "id", EmitDefaultValue = true)]
		public int Id { get; set; }
		[DataMember(Name = "name", EmitDefaultValue = true)]
		public string Name { get; set; }
	
		// Constructors
		[JsonConstructor]
		protected ProfileEditVillageNames() {}
		public ProfileEditVillageNames(int id = 0, string name = null) {}
	
		// Methods
		public override string ToString() => default;
		public virtual string ToJson() => default;
		public override bool Equals(object input) => default;
		public bool Equals(ProfileEditVillageNames input) => default;
		public override int GetHashCode() => default;
	}
