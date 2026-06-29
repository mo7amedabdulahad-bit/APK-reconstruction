// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PermanentGameObjectSaver : MonoBehaviour, IBootable
	{
		// Fields
		private static PermanentGameObjectSaver instance;
	
		// Constructors
		public PermanentGameObjectSaver() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		private static void DestroyPreviousGameObject(PermanentGameObjectSaver permanentGameObjectSaver) {}
		private static void SavePermanentGameObjectFromSceneReload() {}
	}
