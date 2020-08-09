using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class RequestHandler
{
    public delegate void ResponseCallback(string response);

    public static IEnumerator GetRequest(string uri, ResponseCallback callBack)    
    {
        Debug.Log("creating request");

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri);
        yield return unityWebRequest.SendWebRequest();
        callBack(unityWebRequest.downloadHandler.text);

        if (unityWebRequest.isNetworkError)
        {
            Debug.Log("Error While Sending: " + unityWebRequest.error);
        }
        else
        {
            Debug.Log("Received: " + unityWebRequest.downloadHandler.text);
        }
    }
}
