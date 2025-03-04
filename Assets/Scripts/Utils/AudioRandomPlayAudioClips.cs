using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioClipList;

    public List<AudioSource> audioSourceList;

    private int _index = 0;

    public void PlayRandom()
    {
        if(_index >= audioSourceList.Count)
        {
            _index = 0; // Se tiver 3 itens, quando chamar a quarta vez ele volta pra zero
        }

        var audioSource = audioSourceList[_index];

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)]; //Pegar um audio randomico dentro da lista
        audioSource.Play();

        _index ++; //Adiciona 1 ao _index
    }
  
}
