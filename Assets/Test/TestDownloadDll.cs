using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dotnow;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using dotnow.Reflection;
using UnityEngine.UI;

public class TestDownloadDll : MonoBehaviour
{
    public string httpURL = @"http://10.7.71.135:8080/testHttp//Test.dll";

    AppDomain app = new AppDomain();
    CLRModule mod;

    public InputField urlInput;
    public InputField methodInput;
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string Speak()
    {
        Debug.Log("speak ok");
        return "Test Ok";
    }

    public void SwitchObject(string goTag)
    {
        var go = GameObject.FindGameObjectWithTag(goTag);
        if (go != null)
        {
            var mr = go.GetComponent<MeshRenderer>();
            mr.enabled = !mr.enabled;
        }
    }

    public void OnClickDowanload()
    {
        StartCoroutine(DotNowTools.DownloadLoadDll(urlInput.text, (byte[] dllBytes) =>
        {
            mod = app.LoadModuleData(dllBytes, false);
            resultText.text = $"download : {urlInput.text} :{app}";
        }));
    }

    public void OnClickCall()
    {
        var r = DotNowTools.CallMethodExpression(mod, methodInput.text, this, "TestGo");
    }

    public void TestCallNoArgs(string express= "TestDownloadDll.Speak")
    {
        var r = DotNowTools.CallMethodExpression(mod, express, null, null);

        if (resultText)
            resultText.text = r.ToString();
    }
}
