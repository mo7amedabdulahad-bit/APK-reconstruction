// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SpriteReferenceByStringCfg : BaseSpriteConfig
	{
		// Fields
		[SerializeField]
		public StringSpriteReferenceDictionary sprites;
	
		// Constructors
		public SpriteReferenceByStringCfg() {}
	
		// Methods
		public void AddToSprites(string key, AssetReference sprite) {}
		public override SerializableDictionary<T, TM> GetSprites<T, TM>() => default;
		public override List<T> GetIndicesAsObservableList<T>() => default;
	}
