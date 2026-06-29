// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.PlayerDetails
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

public class PlayerEditProfilePopupController : DetailWindowController
{
	// Fields
	[ObservableValue]
	private TLMobile.Generated.GraphQL.Game.Profile _playerProfile;
	[ObservableValue]
	private string _currentLocation;
	[ObservableValue]
	private EditProfileGender _currentGender;

	// Properties
	[ObservableValue]
	public TLMobile.Generated.GraphQL.Game.Profile playerProfile { get => default; set {} }
	[ObservableValue]
	public string currentLocation { get => default; set {} }
	[ObservableValue]
	public EditProfileGender currentGender { get => default; set {} }

	// Nested types
	public enum EditProfileGender
	{
		Male = 0,
		Female = 1,
		Other = 2,
		NotSpecified = 3
	}

	// Constructors
	public PlayerEditProfilePopupController() {}

	// Methods
	protected override void OnEnable() {}
	public void ResetToProfile(TLMobile.Generated.GraphQL.Game.Profile profile) {}
	[UICallable]
	public void SetGender(EditProfileGender value) {}
	[UICallable]
	public void OpenLanguageSelection() {}
	[UICallable]
	public void Save() {}
}
