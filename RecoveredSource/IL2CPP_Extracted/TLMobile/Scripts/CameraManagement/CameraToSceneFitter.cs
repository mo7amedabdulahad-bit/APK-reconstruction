// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.CameraManagement
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CameraToSceneFitter : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private Camera targetCamera;
		[SerializeField]
		private ScreenConfigurationProvider screenConfiguration;
		[SerializeField]
		private float maxAspectRatio;
		[SerializeField]
		private bool ignoreSafeAreaSides;
	
		// Constructors
		public CameraToSceneFitter() {}
	
		// Methods
		private void Awake() {}
		public void SetOptimalConfiguration(Camera cameraToSetup, IScreenConfiguration screenConfiguration, float? actualScreenAspectRatio = default) {}
	}
