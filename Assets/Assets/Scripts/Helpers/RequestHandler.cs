using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestHandler : MonoBehaviour
{
    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri);
        yield return unityWebRequest.SendWebRequest();

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
