using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLoudnesDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    private string microphoneName;
    // Start is called before the first frame update
    void Start()
    {
        microphoneName = Microphone.devices.Length > 0 ? Microphone.devices[0] : null;

        if (microphoneName == null)
        {
            Debug.LogError("No microphone devices found.");
            return;
        }

        MicrophoneToAudioClip();
    }

    

    public void MicrophoneToAudioClip() 
    {
        
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);

    }

    public float GetLoudnessFromMicrophone() 
    {
        if (microphoneClip == null)
        {
            Debug.LogError("Microphone clip is null.");
            return 0f;
        }

        return GetLoudnesFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnesFromAudioClip(int clipPosition,AudioClip clip) 
    {
        
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveDate = new float[sampleWindow];
        clip.GetData(waveDate, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveDate[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
