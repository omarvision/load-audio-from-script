using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomAudioLoader : MonoBehaviour
{
    private AudioSource music = null;
    private FileInfo[] files = null;

    private void Start()
    {
        files = GetResourceFiles("*.mp3");

        int R = Random.Range(0, files.Length);
        music = CreateaAudioSource(files[R].Name);

        music.Play();
    }
    private FileInfo[] GetResourceFiles(string searchPattern)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(Application.dataPath + "\\Resources");
        FileInfo[] files = dirInfo.GetFiles(searchPattern);
        return files;
    }
    private AudioSource CreateAudioSource(string filename)
    {
        AudioSource audio = this.gameObject.AddComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>(filename);
        return audio;
    }
}