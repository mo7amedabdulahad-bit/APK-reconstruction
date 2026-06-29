// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class PromiseHelper
	{
		// Methods
		public static IPromise<T> RetryNTimes<T>(Func<IPromise<T>> promiseToTry, Func<Exception, bool> retryCondition, int retryCount, float delayBetweenRetries = 0f) => default;
		public static IPromise RetryNTimes(Func<IPromise> promiseToTry, Func<Exception, bool> retryCondition, int retryCount, float delayBetweenRetries = 0f) => default;
		public static IPromise Delay(float delay) => default;
		public static IPromise Delay(int delay) => default;
		private static void Retry<T>(Promise<T> originalPromise, Func<IPromise<T>> promiseToTry, Func<Exception, bool> retryCondition, int retryCount, float delay) {}
		private static void Retry(Promise originalPromise, Func<IPromise> promiseToTry, Func<Exception, bool> retryCondition, int retryCount, float delay) {}
		public static IPromise WaitUntil(Func<bool> condition, CancellationTokenSource cancellationTokenSource = null) => default;
		private static async System.Threading.Tasks.Task WaitUntil(Func<bool> condition, Promise promise, CancellationToken cancellationToken = default) => default;
	}
