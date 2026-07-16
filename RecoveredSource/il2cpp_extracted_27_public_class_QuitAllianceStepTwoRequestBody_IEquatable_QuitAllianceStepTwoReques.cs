	public class QuitAllianceStepTwoRequestBody : IEquatable<QuitAllianceStepTwoRequestBody>
	{
		// Properties
		[DataMember(Name = "action", EmitDefaultValue = true)]
		public ActionEnum Action { get; set; }
		[DataMember(Name = "password", EmitDefaultValue = false)]
		[Obsolete("Is marked as deprecated")]
		public string Password { get; set; }
	
		// Nested types
		[JsonConverter(typeof(StringEnumConverter))]
