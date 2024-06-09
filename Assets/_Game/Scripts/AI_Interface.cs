using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AI_Interface : MonoBehaviour
{
    public IEnumerator SendRequest(string userInput)
    {
        string url = "http://your-api-url.com/api-endpoint?input=" + UnityWebRequest.EscapeURL(userInput);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Received: " + webRequest.downloadHandler.text);
            }
        }
    }
}