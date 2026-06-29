// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IGraphQLDataPollingManager
	{
		// Methods
		void AddToPolling(IGraphQLFetchable serverObject, float interval, int queryType = 0, float intervalLowBandwidth = -1f);
		void RemoveFromPolling(IGraphQLFetchable serverObject, float interval, int queryType = 0, float intervalLowBandwidth = -1f);
	}
