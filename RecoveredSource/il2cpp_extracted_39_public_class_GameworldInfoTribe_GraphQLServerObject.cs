	public class GameworldInfoTribe : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
	
		// Nested types
