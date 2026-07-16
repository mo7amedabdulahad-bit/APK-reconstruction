// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IArtefactService : IService
	{
		// Properties
		bool UseAncientPowers { get; }
		GraphQLFetchableList<Artefact> StoredArtefacts { get; }
		Generated.GraphQL.Game.Treasury Treasury { get; }
		AncientPowerManagement AncientPowerManagement { get; }
	
		// Methods
		float GetActiveBonus(PlaceBonusInterface.Type type);
		void UpdateService();
	}
