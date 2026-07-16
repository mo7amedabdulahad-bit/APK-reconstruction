// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapCellRenderer : MonoBehaviour, IPoolableOperations
	{
		// Fields
		private const int DefaultCoreRadius = 22;
		private const float DefaultIconOffset = 0.34f;
		private const float RegionColorOverlayAlpha = 0.25f;
		[SerializeField]
		private SpriteRenderer groundBaseSpriteRenderer;
		[SerializeField]
		private SpriteRenderer groundDetailSpriteRenderer;
		[SerializeField]
		private SpriteRenderer villageSpriteRenderer;
		[SerializeField]
		private SpriteRenderer overlaySprite;
		[SerializeField]
		private SpriteByStringCfg spriteConfig;
		[SerializeField]
		private SpriteRenderer regionOverlaySprite;
		[SerializeField]
		private Texture gridTexture;
		private Dictionary<int, Adventure> adventures;
		private List<MapShape> blockMapShapesData;
		private MapPlayerData cellPlayerData;
		private bool hasRegion;
		private MapCell mapCellData;
		private SpriteRenderer renderedAnimation1;
		private SpriteRenderer renderedAnimation2;
		private SpriteRenderer settlerRenderer;
		private List<SpriteRenderer> renderedGrounds;
		private List<SpriteRenderer> renderedShapes;
		private Dictionary<string, Tweener> spriteTweeners;
		private Vector3 topLeftIconPosition;
	
		// Properties
		public Vector2 GridSpriteSize { get => default; }
	
		// Nested types
		private enum SaveAs
		{
			None = 0,
			Ground = 1,
			Shape = 2
		}
	
		// Constructors
		public MapCellRenderer() {}
	
		// Methods
		public void DisablePooledObject() {}
		public virtual void Init(MapCell mapCellData, Vector3 cellPosition, Dictionary<int, Adventure> adventures, MapPlayerData mapCellPlayerData, UnityEngine.Color regionColor) {}
		private void InitCellData(MapCell mapCellData, Vector3 cellPosition) {}
		private void RenderCell() {}
		private void RenderGround() {}
		private void RenderShapes() {}
		private void RenderVillages() {}
		private void RenderMapEdges() {}
		private void RenderRegionsEdges() {}
		private void RenderAdventures() {}
		private void RenderOases() {}
		private void RenderPlayerMark() {}
		public virtual void UpdateOverlay(bool isZoomedOut) {}
		private void RenderCellFlags() {}
		private void RenderMovementTypes(bool isZoomedOut) {}
		private void RenderAnimatedShape(string sprite1Path, string sprite2Path, Vector3 position, float size, int sortingOrder) {}
		private void RenderMapBorderSprite(NeighborsDirection borderDirection, string spritePath, IPoolingService poolingService) {}
		private void RenderRegionEdgeSprite(NeighborsDirection direction, string spritePath, IPoolingService poolingService) {}
		private void RenderShape(SpriteRenderer shapeRenderer, string spritePath, Vector3 position, float size, int sortingOrder, SaveAs saveAs = SaveAs.Shape) {}
		private void SetGrasslandSprite(int useLandDistribution) {}
		public static bool IsCellDeathZone(int x, int y) => default;
		private static int Radius(int x, int y) => default;
		private static int RandomDeterministicSuffix(int x, int y, int variationCount) => default;
		private void SetSpriteFromResourcesPath(string path, SpriteRenderer spriteRenderer) {}
		private void SetAndShowSprite(string spritePath, SpriteRenderer spriteRenderer) {}
	}
