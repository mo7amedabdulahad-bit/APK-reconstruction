// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CloudsController : MonoBehaviour, ICloudsController
	{
		// Fields
		[SerializeField]
		private UnityEngine.Animator animator;
		[SerializeField]
		private string cloudingAnimationName;
		[SerializeField]
		private string clearingAnimationName;
		[SerializeField]
		private string cloudingScaledAnimationName;
		[SerializeField]
		private SpriteRenderer solidColorBackground;
		[SerializeField]
		private UnityEngine.Color solidColor;
		[SerializeField]
		private float animationSpeed;
		private int clearingHash;
		private int cloudingHash;
		private int cloudingScaledHash;
	
		// Properties
		private UnityEngine.Animator Animator { get; set; }
		private bool InitCalled { get; set; }
		public float AnimationSpeed { get => default; }
	
		// Constructors
		public CloudsController() {}
	
		// Methods
		private void Awake() {}
		public void SetClouding(bool scaled = false) {}
		public void SetClearing() {}
		public void Init(UnityEngine.Animator animatorToUse, string cloudingAnimationTriggerName, string clearingAnimationTriggerName, string cloudingScaledTriggerName) {}
	}
