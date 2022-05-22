using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WWWFile
{
    public class DownloadPath
    {
        string _url;
        string _fileName;
        string _filePath;
        string _version;
        bool _isBuiltIn;
        bool _shared;
        bool _isLinked;
        TYPE _type;
        
        public DownloadPath(TYPE type, string url, string fileName)
        {
            this._url = url;
            this._type = type;
            this._fileName = fileName;
        }

        public string GetUrl()
        {
            return _url;
        }

        public string GetFileName()
        {
            return _fileName;
        }
    }
    
    public enum TYPE
    {
        Ignore = -1,

        Bytes = 0,
        Texture,
        Video,
        ReverseVideo,
        ReverseTexture,
    }
}
