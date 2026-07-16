// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

public class SpriteReferenceCfg : BaseSpriteConfig
{
	// Fields
	[SerializeField]
	public IntSpriteReferenceDictionary sprites;
	[SerializeField]
	private LanguageOverride[] languageOverrides;
	private bool useOverrides;
	private string currentLocale;
	private IntSpriteReferenceDictionary overrideSprites;

	// Nested types
	[Serializable]
	public struct LanguageOverride
	{
		// Fields
		public string language;
		public int keyToOverride;
		public int overrideWithKey;
	}

	// Constructors
	public SpriteReferenceCfg() {}

	// Methods
	private void OnEnable() {}
	public void AddToSprites(int key, AssetReference sprite) {}
	public override SerializableDictionary<T, TM> GetSprites<T, TM>() => default;
	public override List<T> GetIndicesAsObservableList<T>() => default;
	public void CheckForLanguageOverrides(string locale) {}
}
