﻿#if !UNITY_DISABLE
#if (UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID || UNITY_WSA || UNITY_WEBGL)
using dotnow;
using dotnow.Runtime;

namespace UnityEngine
{
    internal static partial class DirectCallBindings
    {
        [Preserve]
        [CLRMethodDirectCallBinding(typeof(RenderSettings), "get_fogColor")]
        public static void unityEngine_RenderSettings_GetFogColor(StackData[] stack, int offset)
        {
            stack[offset].refValue = RenderSettings.fogColor;
        }

        [Preserve]
        [CLRMethodDirectCallBinding(typeof(RenderSettings), "get_fogDensity")]
        public static void unityEngine_RenderSettings_GetFogDensity(StackData[] stack, int offset)
        {
            stack[offset].refValue = RenderSettings.fogDensity;
        }
    }
}
#endif
#endif