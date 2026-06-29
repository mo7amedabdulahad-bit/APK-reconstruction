// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DatabindingWithLogic : Databinding
	{
		// Fields
		[HideInInspector]
		public List<Operation> operations;
		[HideInInspector]
		public List<LogicConnector> additionLogics;
		[HideInInspector]
		public Operation operation;
		[HideInInspector]
		public Operation operation2;
		[HideInInspector]
		public LogicConnector additionLogic;
	
		// Nested types
		public enum LogicConnector
		{
			None = 0,
			And = 1,
			Or = 2
		}
	
		// Constructors
		public DatabindingWithLogic() {}
	
		// Methods
		public virtual void ConvertDeprecatedValues() {}
		protected virtual bool EvaluateLogics() => default;
	}
