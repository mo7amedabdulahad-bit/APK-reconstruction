// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class BaseTextFilter
	{
		// Fields
		public string optionalStringValue;
		public string optionalStringValue2;
		public bool optionalBoolValue;
		public TextFilter component;
		public TGFramework.Translate translate;
		protected StringBuilder sb;
	
		// Properties
		public abstract int Id { get; }
		public abstract string ShortName { get; }
		public abstract string Name { get; }
		public abstract string NeededParameterName { get; }
		public virtual string NeededParameterName2 { get; }
		public virtual string NeededBoolParameterName { get; }
		public virtual string OptionalStringName { get; }
		public virtual string OptionalStringName2 { get; }
		public virtual int NeedsUpdateInterval { get; }
		public virtual bool Inlineable { get; }
		public virtual bool InlineableButNeedsOwnObject { get; }
		public virtual bool DoesNotNeedValue { get; }
	
		// Constructors
		protected BaseTextFilter() {}
	
		// Methods
		public virtual void OnDestroy() {}
		public abstract string FilterInput(string textToFilter, int parameter = 0, int secondParameter = 0, TextFilter component = null);
		protected double GetDoubleValue(string textToFilter) => default;
		protected int GetIntValue(string textToFilter) => default;
		protected StringBuilder GetStringBuilder() => default;
		public virtual void Reset() {}
	}
