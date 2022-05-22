using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadController : MonoBehaviour
{
    [SerializeField] private GaugeBar gaugeBar;
    
    private List<WWWFile.DownloadPath> downloadPathList;

    private void Awake()
    {
        this.downloadPathList = new List<WWWFile.DownloadPath>();
    }

    private void Start()
    {
        string downloadUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Unity_Technologies_logo.svg/2560px-Unity_Technologies_logo.svg.png";
        WWWFile.TYPE type = WWWFile.TYPE.Bytes;
        this.AddDownloadPath(type, downloadUrl, "unityLogo.png");

        downloadUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Google_2015_logo.svg/368px-Google_2015_logo.svg.png";
        this.AddDownloadPath(type, downloadUrl, "Google.png");

        CancellableSignal signal = new CancellableSignal();
        IEnumerator downloadCoroutine = AssetControl.OnDownloadFiles(signal, this.downloadPathList, gaugeBar);
        StartCoroutine(downloadCoroutine);
    }

    public void AddDownloadPath(WWWFile.TYPE type, string downloadUrl, string fileName)
    {
        WWWFile.DownloadPath downloadPath = new WWWFile.DownloadPath(type, downloadUrl, fileName);
        this.downloadPathList.Add(downloadPath);
    } 
}
