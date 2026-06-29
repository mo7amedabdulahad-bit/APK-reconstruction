// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IMapCellDataFetcherService : IService
	{
		// Methods
		List<MapCell> GetStaticBlock(int xStart, int yStart, int width, int height);
		MapBlock GetCellBlock(int xStart, int yStart, int width, int height, bool forceRefresh = true);
		IPromise<MapBlock> GetPromiseCellBlock(int xStart, int yStart, int width, int height, bool forceRefresh = true);
		MapBlock GetBlockHash(int xStart, int yStart, int width, int height, bool forceRefresh = true);
		IPromise<MapBlock> GetPromiseBlockHash(int xStart, int yStart, int width, int height, bool forceRefresh = true);
		MapBlock GetBlockPlayerData(int xStart, int yStart, int width, int height, bool forceRefresh = true);
		IPromise<MapBlock> GetPromiseBlockPlayerData(int xStart, int yStart, int width, int height, bool forceRefresh = true);
		TLMobile.Generated.GraphQL.Game.Player GetMapCellOwner(int playerId);
		Village GetMapCellVillage(int villageId);
	}
