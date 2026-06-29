// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceBonus : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _newMemberCurrentCooldown;
		[ObservableValue]
		private OwnAllianceBonusProgress _progress;
		[ObservableValue]
		private DonationStatistics _donationStatistics;
		[ObservableValue]
		private Type _type;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int newMemberCurrentCooldown { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonusProgress progress { get => default; set {} }
		[ObservableValue]
		public DonationStatistics donationStatistics { get => default; set {} }
		[ObservableValue]
		public Type type { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum Type
		{
			None = 0,
			TroopProductionSpeed = 1,
			CPProduction = 2,
			SmithyPower = 3,
			MerchantCapacity = 4,
			MerchantCapacityAndSpeed = 5
		}
	
		// Constructors
		public OwnAllianceBonus() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceBonusDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceBonusDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static ContributeResourcesRequestBody.BonusEnum BonusTypeToContributionEnum(Type bonusType) => default;
		public static ContributeResourcesX3RequestBody.BonusEnum BonusTypeTo3XContributionEnum(Type bonusType) => default;
	}
