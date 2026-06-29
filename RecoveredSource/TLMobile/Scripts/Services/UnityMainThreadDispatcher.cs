// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Services/UnityMainThreadDispatcher.cs
// ============================================================================
//
// Reconstructed from: RuntimeInitializeOnLoads initialization chain
// Confidence: 87%
// Evidence:
//   - RuntimeInitializeOnLoads.json: assembly="TLMobile",
//     namespace="TLMobile.Scripts.Services", class="UnityMainThreadDispatcher",
//     method="Init", loadTypes=1 (AfterAssembliesLoaded)
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using System.Collections.Generic;
using UnityEngine;

namespace TLMobile.Scripts.Services
{
    /// <summary>
    /// Dispatches actions to the Unity main thread.
    /// Confidence: 87%
    /// Evidence: RuntimeInitializeOnLoads initialization, common Unity pattern
    /// </summary>
    public class UnityMainThreadDispatcher : MonoBehaviour
    {
        private static UnityMainThreadDispatcher _instance;
        private readonly Queue<Action> _actions = new Queue<Action>();

        /// <summary>
        /// Initialize the main thread dispatcher.
        /// Confidence: 87% - Evidence: RuntimeInitializeOnLoads entry
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Init()
        {
            if (_instance != null) return;

            var go = new GameObject("[UnityMainThreadDispatcher]");
            DontDestroyOnLoad(go);
            _instance = go.AddComponent<UnityMainThreadDispatcher>();
        }

        /// <summary>
        /// Enqueue an action to run on the main thread.
        /// Confidence: 85% - Inferred from dispatcher pattern
        /// </summary>
        public static void Enqueue(Action action)
        {
            if (_instance == null) Init();
            lock (_instance._actions)
            {
                _instance._actions.Enqueue(action);
            }
        }

        private void Update()
        {
            lock (_actions)
            {
                while (_actions.Count > 0)
                {
                    var action = _actions.Dequeue();
                    try
                    {
                        action?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"[MainThreadDispatcher] Error executing action: {ex}");
                    }
                }
            }
        }
    }
}
