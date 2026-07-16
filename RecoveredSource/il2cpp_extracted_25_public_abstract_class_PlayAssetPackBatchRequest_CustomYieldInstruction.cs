	public abstract class PlayAssetPackBatchRequest : CustomYieldInstruction
	{
		// Fields
		public IDictionary<string, PlayAssetPackRequest> Requests;
	
		// Properties
		public bool IsDone { get; protected set; }
		public override bool keepWaiting { get; }
	
		// Events
		public virtual event Action<PlayAssetPackBatchRequest> Completed;
	
		// Constructors
		protected PlayAssetPackBatchRequest() {}
	
		// Methods
		protected void InvokeCompletedEvent() {}
	}
