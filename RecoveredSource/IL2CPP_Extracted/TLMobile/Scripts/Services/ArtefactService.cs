// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ArtefactService : MonoBehaviour, IArtefactService
	{
		// Fields
		private OwnVillage village;
	
		// Properties
		public bool UseAncientPowers { get; private set; }
		public GraphQLFetchableList<Artefact> StoredArtefacts { get; private set; }
		public Generated.GraphQL.Game.Treasury Treasury { get; private set; }
		public AncientPowerManagement AncientPowerManagement { get; private set; }
	
		// Constructors
		public ArtefactService() {}
	
		// Methods
		private void OnDisable() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public void UpdateService() {}
		public float GetActiveBonus(PlaceBonusInterface.Type type) => default;
		private void InitPlaceBonus() {}
		private void OnVillageChanged(OwnVillage village) {}
		private float? GetActiveArtefactBonus(PlaceBonusInterface.Type type) => default;
		private float? GetActiveAncientPowerBonus(int type) => default;
		private float CompareBestEffectValue(float? bestBonus, PlaceBonusInterface placeBonus) => default;
	}
