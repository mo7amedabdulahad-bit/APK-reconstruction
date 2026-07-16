// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ViewModelLinker : ViewModel
	{
		// Fields
		[Header("Drag a ViewModel here. This will be linked and Databindings in all the children can access it.")]
		public ViewModel linkedViewModel;
		[Header("Drag a ViewModel here. This will be destroyed on Awake and instead will be replaced by a link to an existing instance of the same Type. Useful for Prefabs that reference something on the outside. Be careful: This will take the first active instance it will find.")]
		public ViewModel disableThisAndTakeGlobalOne;
		[Header("Only searches for another ACTIVE instance of the same type.")]
		public bool targetHasToBeActive;
	
		// Constructors
		public ViewModelLinker() {}
	
		// Methods
		protected override void Awake() {}
	}
