	public class HeroAppearanceSetDTO
	{
		// Fields
		public HeroAppearanceDTO male;
		public HeroAppearanceDTO female;
		public HeroAppearanceCategoriesDTO category;
	
		// Constructors
		public HeroAppearanceSetDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
