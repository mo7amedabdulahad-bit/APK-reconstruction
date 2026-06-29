// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SharedSpriteService : MonoBehaviour, ISharedSpriteService
	{
		// Fields
		[SerializeField]
		private SpriteCfg generalIcons;
		[SerializeField]
		private SpriteCfg troopIcons;
		[SerializeField]
		private SpriteReferenceCfg buildingIcons;
	
		// Properties
		public SpriteCfg GeneralIcons { get => default; }
		public SpriteCfg TroopIcons { get => default; }
		public SpriteReferenceCfg BuildingIcons { get => default; }
	
		// Constructors
		public SharedSpriteService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
	}
