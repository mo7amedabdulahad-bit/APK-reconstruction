// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Profile : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<MedalGameworld> _medalsGameworld;
		[ObservableValue]
		private GraphQLObservableList<MedalLifetime> _medalsLifetime;
		[ObservableValue]
		private bool _ownProfile;
		[ObservableValue]
		private bool _isNPC;
		[ObservableValue]
		private bool _allowEdit;
		[ObservableValue]
		private Gender? _gender;
		[ObservableValue]
		private string _location;
		[ObservableValue]
		private string _personalNote;
		[ObservableValue]
		private string _language;
		[ObservableValue]
		private GraphQLObservableList<string> _additionalLanguages;
		[ObservableValue]
		private bool _showCountryFlag;
		[ObservableValue]
		private CountryFlag _countryFlag;
		[ObservableValue]
		private Description _descriptionPlain;
		[ObservableValue]
		private Description _descriptionHtml;
		[ObservableValue]
		private bool _interactionPossible;
		[ObservableValue]
		private bool _ignoredListIsFull;
		[ObservableValue]
		private bool _allowedToIgnore;
		[ObservableValue]
		private bool _isPlayerIgnoring;
		[ObservableValue]
		private bool _isPlayerInvited;
		[ObservableValue]
		private bool _isAllianceMember;
		[ObservableValue]
		private int _daysPlaying;
		private static readonly string[] namesInNestedResponseFromOwnPlayerProfile;
		[ObservableValue]
		private ObservableList<CountryFlagEnum> _languagesEnum;
		[ObservableValue]
		private string _personalNoteDecoded;
		[ObservableValue]
		private bool _isDescriptionAvailable;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ProfileSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<MedalGameworld> medalsGameworld { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MedalLifetime> medalsLifetime { get => default; set {} }
		[ObservableValue]
		public bool ownProfile { get => default; set {} }
		[ObservableValue]
		public bool isNPC { get => default; set {} }
		[ObservableValue]
		public bool allowEdit { get => default; set {} }
		[ObservableValue]
		public Gender? gender { get => default; set {} }
		[ObservableValue]
		public string location { get => default; set {} }
		[ObservableValue]
		public string personalNote { get => default; set {} }
		[ObservableValue]
		public string language { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<string> additionalLanguages { get => default; set {} }
		[ObservableValue]
		public bool showCountryFlag { get => default; set {} }
		[ObservableValue]
		public CountryFlag countryFlag { get => default; set {} }
		[ObservableValue]
		public Description descriptionPlain { get => default; set {} }
		[ObservableValue]
		public Description descriptionHtml { get => default; set {} }
		[ObservableValue]
		public bool interactionPossible { get => default; set {} }
		[ObservableValue]
		public bool ignoredListIsFull { get => default; set {} }
		[ObservableValue]
		public bool allowedToIgnore { get => default; set {} }
		[ObservableValue]
		public bool isPlayerIgnoring { get => default; set {} }
		[ObservableValue]
		public bool isPlayerInvited { get => default; set {} }
		[ObservableValue]
		public bool isAllianceMember { get => default; set {} }
		[ObservableValue]
		public int daysPlaying { get => default; set {} }
		[ObservableValue]
		public ObservableList<CountryFlagEnum> languagesEnum { get => default; set {} }
		[ObservableValue]
		public string personalNoteDecoded { get => default; set {} }
		[ObservableValue]
		public bool isDescriptionAvailable { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			PlayerWithProfileStubProfile = 1
		}
	
		public enum ProfileSource
		{
			FromOwnPlayerProfile = 0
		}
	
		// Constructors
		public Profile() {}
		static Profile() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ProfileDTO dtoValue) => default;
		private bool EqualToDTOPlayerWithProfileStubProfile(ProfileDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ProfileDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOPlayerWithProfileStubProfile(ProfileDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListMedalsGameworld(GraphQLObservableList<MedalGameworld> to, List<MedalGameworldDTO> from, int query) => default;
		private bool CopyValuesFromDtoListMedalsLifetime(GraphQLObservableList<MedalLifetime> to, List<MedalLifetimeDTO> from, int query) => default;
		private bool CopyValuesFromDtoListAdditionalLanguages(GraphQLObservableList<string> to, List<string> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Profile> PromiseGetFromOwnPlayerProfile(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Profile> PromiseGetFromOwnPlayerProfile(out Profile cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Profile GetNoFetchFromOwnPlayerProfile(Query query = Query.All) => default;
		public static Profile GetFromOwnPlayerProfile(bool forceRefresh, Query query = Query.All) => default;
		public static Profile GetFromOwnPlayerProfile(Query query = Query.All) => default;
		private static Profile FetchFromOwnPlayerProfile(ProfileSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerProfile(object dummy = null) => default;
		private void _medalsGameworldNotify(object sender, PropertyChangedEventArgs args) {}
		private void _medalsLifetimeNotify(object sender, PropertyChangedEventArgs args) {}
		private void _additionalLanguagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _languagesEnumNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
