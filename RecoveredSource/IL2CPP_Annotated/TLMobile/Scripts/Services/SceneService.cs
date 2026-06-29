// TLMobile.dll - TLMobile.Scripts.Services.SceneService
// Extracted from IL2CPP metadata v39
// Method count: 46
// NOTE: Method bodies are stubs - require native decompilation

namespace TLMobile.Scripts.Services
{
    public class SceneService
    {
        #region Constructors
        // 0x04FF7218
        public SceneService() { }
        #endregion

        #region Methods
        // 0x04FF3EB0: IPromise Init(Object[])
        public IPromise Init(object) { return default; }
        // 0x04FF3EB8: IPromise Init(String)
        public IPromise Init(string) { return default; }
        // 0x04FF3FFC: IPromise BootInstance(Object[])
        public IPromise BootInstance(object) { return default; }
        // 0x04FF404C: Void OnDestroy()
        public void OnDestroy() { return default; }
        // 0x04FF40B0: Void CleanupTransitionHandlers()
        public void CleanupTransitionHandlers() { return default; }
        // 0x04FF4250: Void add_ViewChanged(Action`1[TLMobile.Scripts.Interfaces.Services.SceneStatus])
        public void add_ViewChanged(Action`1[TLMobile.Scripts.Interfaces.Services.SceneStatus]) { return default; }
        // 0x04FF4300: Void remove_ViewChanged(Action`1[TLMobile.Scripts.Interfaces.Services.SceneStatus])
        public void remove_ViewChanged(Action`1[TLMobile.Scripts.Interfaces.Services.SceneStatus]) { return default; }
        // 0x04FF43B0: Void add_LoggedOut(Action)
        public void add_LoggedOut(Action) { return default; }
        // 0x04FF444C: Void remove_LoggedOut(Action)
        public void remove_LoggedOut(Action) { return default; }
        // 0x04FF44E8: Void add_LoadMainSceneStarted(Action)
        public void add_LoadMainSceneStarted(Action) { return default; }
        // 0x04FF4584: Void remove_LoadMainSceneStarted(Action)
        public void remove_LoadMainSceneStarted(Action) { return default; }
        // 0x04FF4620: String get_MainSceneName()
        public string get_MainSceneName() { return default; }
        // 0x04FF4628: Void set_MainSceneName(String)
        public void set_MainSceneName(string) { return default; }
        // 0x04FF4630: SceneStatus get_CurrentSceneStatus()
        public SceneStatus get_CurrentSceneStatus() { return default; }
        // 0x04FF4638: Void set_CurrentSceneStatus(SceneStatus)
        public void set_CurrentSceneStatus(SceneStatus) { return default; }
        // 0x04FF4640: IReadOnlyDictionary`2[System.String,UnityEngine.GameObject] get_LoadedViewParentObjects()
        public IReadOnlyDictionary`2[System.String,UnityEngine.GameObject] get_LoadedViewParentObjects() { return default; }
        // 0x04FF4648: Void LoadMainScene(Action)
        public void LoadMainScene(Action) { return default; }
        // 0x04FF4780: IEnumerator LoadMainSceneCoroutine(Action)
        public IEnumerator LoadMainSceneCoroutine(Action) { return default; }
        // 0x04FF4808: Void LoadLoginScene()
        public void LoadLoginScene() { return default; }
        // 0x04FF4A4C: IEnumerator LoadLoginSceneCoroutine()
        public IEnumerator LoadLoginSceneCoroutine() { return default; }
        // 0x04FF4AB8: Boolean LoadOtherScene(String)
        public bool LoadOtherScene(string) { return default; }
        // 0x04FF4C20: Boolean IsOtherSceneToLoadValid(String)
        public bool IsOtherSceneToLoadValid(string) { return default; }
        // 0x04FF4D70: IEnumerator LoadOtherSceneFinalizationCoroutine(String)
        public IEnumerator LoadOtherSceneFinalizationCoroutine(string) { return default; }
        // 0x04FF4DF8: GameObject MoveGameObjectsToMainScene(GameObject[], String)
        public GameObject MoveGameObjectsToMainScene(GameObject[], String) { return default; }
        // 0x04FF4F60: Camera AddDefaultCameraSettingsForView(String)
        public Camera AddDefaultCameraSettingsForView(string) { return default; }
        // 0x04FF5154: GameObject AddDefaultParentSettingsForView(String)
        public GameObject AddDefaultParentSettingsForView(string) { return default; }
        // 0x04FF52B0: Void MoveObjectsToViewWithCorrectSetUp(GameObject[], String, Camera, GameObject)
        public void MoveObjectsToViewWithCorrectSetUp(GameObject[], String, Camera, GameObject) { return default; }
        // 0x04FF54DC: Void SwitchToSitter(Action)
        public void SwitchToSitter(Action) { return default; }
        // 0x04FF55B8: Boolean SwitchToVillageView()
        public bool SwitchToVillageView() { return default; }
        // 0x04FF57BC: Void SwitchToOtherView(String, ViewTransition, Boolean)
        public void SwitchToOtherView(String, ViewTransition, Boolean) { return default; }
        // 0x04FF5AA4: Boolean SwitchToOtherView(String, Boolean)
        public bool SwitchToOtherView(String, Boolean) { return default; }
        // 0x04FF5C0C: Boolean SwitchToResourcesView()
        public bool SwitchToResourcesView() { return default; }
        // 0x04FF5E1C: Boolean SwitchToMapView(Int32, Int32, Boolean)
        public bool SwitchToMapView(Int32, Int32, Boolean) { return default; }
        // 0x04FF6048: IEnumerator ApplyChangeViewWhenReady(String, Boolean)
        public IEnumerator ApplyChangeViewWhenReady(String, Boolean) { return default; }
        // 0x04FF60DC: Void ExitToLogin()
        public void ExitToLogin() { return default; }
        // 0x04FF6104: Void PrepareLoginScene()
        public void PrepareLoginScene() { return default; }
        // 0x04FF64CC: IScreenConfiguration GetCurrentScreenConfiguration()
        public IScreenConfiguration GetCurrentScreenConfiguration() { return default; }
        // 0x04FF653C: String ViewName(SceneStatus)
        public string ViewName(SceneStatus) { return default; }
        // 0x04FF65CC: Void SetCurrentScreenConfiguration(IScreenConfiguration)
        public void SetCurrentScreenConfiguration(IScreenConfiguration) { return default; }
        // 0x04FF6818: Void PreloadAdsForMainScene()
        public void PreloadAdsForMainScene() { return default; }
        // 0x04FF69D0: Void DestroyPermanentGameObjects()
        public void DestroyPermanentGameObjects() { return default; }
        // 0x04FF6B84: Void SetCurrentSceneStatus(String, Boolean)
        public void SetCurrentSceneStatus(String, Boolean) { return default; }
        // 0x04FF6C6C: Void ChangeViewsVisibilities(String)
        public void ChangeViewsVisibilities(string) { return default; }
        // 0x04FF6FE4: Void CopyCameraValues(String, Camera)
        public void CopyCameraValues(String, Camera) { return default; }
        // 0x04FF7460: Void <LoadMainSceneCoroutine>b__62_0()
        public void <LoadMainSceneCoroutine>b__62_0() { return default; }
        #endregion
    }
}
