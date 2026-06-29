// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TLMViewModel : ViewModel
	{
		// Fields
		private readonly List<ObserveInfo> savedObservers;
	
		// Nested types
		private struct ObserveInfo : IEquatable<ObserveInfo>
		{
			// Fields
			public ServerObject objectToObserve;
			public System.Action callback;
			public string propertyToObserve;
	
			// Methods
			public override bool Equals(object obj) => default;
			public override int GetHashCode() => default;
			public bool Equals(ObserveInfo other) => default;
		}
	
		// Constructors
		public TLMViewModel() {}
	
		// Methods
		protected virtual void OnEnable() {}
		protected virtual void OnDisable() {}
		protected override void OnDestroy() {}
		protected void StopObserving(bool alsoClearList = true) {}
		public override void ObserveWhole(ServerObject obj, System.Action callback, bool deepObserve = true, bool instantlyCallWhenFilled = true) {}
		public override void StopObserving(ServerObject obj) {}
		private MemberInfo GetMemberOutOfExpression(Expression<Func<object>> expr) => default;
		protected void ObserveProperty(ServerObject obj, Expression<Func<object>> expr, System.Action callback) {}
		protected void StopObserveProperty(ServerObject obj, Expression<Func<object>> expr) {}
	}
