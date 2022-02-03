using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;

public class sound : MonoBehaviour
{
    public string url;
    AudioSource aud;
    public AudioClip clip;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        StartCoroutine(ZZ());
    }
    IEnumerator ZZ()
    {
        //WWW www = new WWW(url);
        //yield return www;
        //clip = www.GetAudioClip();
        UnityWebRequest webRequest;
        webRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
        yield return webRequest.SendWebRequest();
        clip = DownloadHandlerAudioClip.GetContent(webRequest);
        aud.clip = clip;
        aud.Play();
    }
}
