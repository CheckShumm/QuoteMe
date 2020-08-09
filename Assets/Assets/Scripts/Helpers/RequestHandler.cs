using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestHandler
{
    public delegate void QuoteResponse(string response);

    public static IEnumerator GetRequest(string uri,QuoteResponse callBack)    
    {
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
