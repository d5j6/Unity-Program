using KWS;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class TestScript : MonoBehaviour
{

    // Use this for initialization
    //IEnumerator Start()
    //{



    //    //yield return Upload();
    //    //var tes = KWSClient.Test("dfasdfa", 23);
    //    var tes = KWSClient.Test_Test2(0.1f, 2);
    //    yield return tes.WaitForCompleted();
    //    print(tes.Result);
    //}

    private void Start()
    {
        //var sd = new SceneData();
         
    }


    IEnumerator Count()
    {
        yield return new WaitForSeconds(1.0f);
        print("count1 finished");
    }


    IEnumerator Count2()
    {
        yield return new WaitForSeconds(1.0f);
        print("count2 finished");
    }
    IEnumerator Upload()
    {
        //var www = UnityWebRequest.Post(@"http://localhost:37032/api/Test/Test", "[\"dfasdfa\",23]");
        //www.SetRequestHeader("content-type", "application/json");
        //yield return www.Send();

        //if (www.isError)
        //{
        //    Debug.Log(www.error);
        //}
        //else
        //{
        //    Debug.Log("Form upload complete");
        //}

        var rawData = Encoding.UTF8.GetBytes("[\"dfasdfa\",23]");

        var request = new UnityWebRequest()
        {
            url = @"http://localhost:37032/api/Test/Test",
            uploadHandler = new UploadHandlerRaw(rawData) { contentType = "application/json" },
            downloadHandler = new DownloadHandlerBuffer(),
            method = "POST"
        };
        yield return request.Send();
        print(request.downloadHandler.text);
    }

}
