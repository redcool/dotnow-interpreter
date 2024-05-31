using dotnow;
using dotnow.Reflection;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine.Networking;
using AppDomain = dotnow.AppDomain;

internal static class DotNowTools
{

    const BindingFlags methodFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Default;
    public static object CallMethod(CLRModule mod, string typeName, string methodName, object caller, params object[] args)
    {
        var t = mod.GetType(typeName);
        var m = t.GetMethod(methodName, methodFlags);
        return m.Invoke(caller, args);
    }

    public static object CallMethodExpression(CLRModule mod, string expression, object caller, params object[] args)
    {
        var typeStrs = expression.Split(".");
        var typeName = typeStrs[0];
        var methodName = typeStrs[1];

        return CallMethod(mod, typeName, methodName, caller, args);
    }

    public static IEnumerator DownloadLoadDll(string url, Action<byte[]> onDone = null)
    {
        var req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();

        var dllBytes = req.downloadHandler.data;
        onDone?.Invoke(dllBytes);

        req.Dispose();
    }
}