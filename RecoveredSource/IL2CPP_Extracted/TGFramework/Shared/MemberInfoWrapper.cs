// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Shared
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MemberInfoWrapper
	{
		// Fields
		public MemberInfo info;
		public PropertyInfo propInfo;
		public FieldInfo fieldInfo;
		public MethodInfo methodInfo;
		public System.Type memberType;
		public bool isList;
		public System.Type listMemberType;
		public string name;
		public object lastFetchedValue;
		public bool isObservable;
		public static Func<object, System.Type, System.Type, object, object> AdditionalTypeConverter;
	
		// Constructors
		public MemberInfoWrapper() {} // Dummy constructor
		public MemberInfoWrapper(MemberInfo info) {}
	
		// Methods
		public static bool IsNumericType(System.Type t) => default;
		public static T TypeConvert<T>(object what, System.Type newValueTypeIfKnown = null, object existingValueIfKnown = null) => default;
		public static object TypeConvert(object sourceObject, System.Type destinationType, System.Type sourceTypeIfKnown = null, object destinationValueIfKnown = null) => default;
		public object GetValue(object context) => default;
		public void SetValue(object context, object newValue, System.Type newValueTypeIfKnown = null) {}
		public static string GetFriendlyTypeName(System.Type type) => default;
	}
