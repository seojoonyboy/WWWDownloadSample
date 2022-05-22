using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public static class AssetControl
{
    static List<WWWFile.DownloadPath> DownloadPathList = null;

    public static IEnumerator OnDownloadFiles(CancellableSignal signal, List<WWWFile.DownloadPath> downloadList, GaugeBar gaugeBar)
    {
        foreach (WWWFile.DownloadPath downloadPath in downloadList)
        {
            yield return OnDownloadFile(signal, downloadPath, gaugeBar);
        }
    }

    private static IEnumerator OnDownloadFile(CancellableSignal signal, WWWFile.DownloadPath downloadPath, GaugeBar gaugeBar)
    {
        using (var request = UnityWebRequest.Get(downloadPath.GetUrl()))
        {
            gaugeBar.StartLoadingGauge(downloadPath.GetFileName());
            
            string path = Path.Combine(Application.persistentDataPath, downloadPath.GetFileName());
            request.downloadHandler = new DownloadHandlerFile(path);
            var async = request.SendWebRequest();

            while (true)
            {
                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.LogError(request.error);
                    yield break;
                }

                if (async.isDone)
                {
                    Debug.Log("DONE!");
                    yield break;
                }

                yield return null;
                
                gaugeBar.UpdateLoadingGauge(async.progress);
                Debug.Log(async.progress);
            }
        }
    }
}
