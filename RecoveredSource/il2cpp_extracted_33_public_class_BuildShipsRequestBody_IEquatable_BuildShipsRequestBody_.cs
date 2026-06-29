	public class BuildShipsRequestBody : IEquatable<BuildShipsRequestBody>
	{
		// Properties
		[DataMember(Name = "action", EmitDefaultValue = true)]
		public ActionEnum Action { get; set; }
		[DataMember(Name = "ships", EmitDefaultValue = true)]
		public ShipsSet Ships { get; set; }
	
		// Nested types
		[JsonConverter(typeof(StringEnumConverter))]
