using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour {
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    float[] _freqBand = new float[8];
    float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

	// Use this for initialization
	void Start () {
        _audioSource = this.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands ();
        BandBuffer();
        CreateAudioBands();

	}

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if(_freqBand [i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];

            }

            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);

        }

    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {   for (int g = 0; g < 8; ++g)
        {
            if (_freqBand [g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }


            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }

    }

    void MakeFrequencyBands()
    {
        /* LAYOUT OF FREQ PER CHANNEL   
         * ---------------------------------------
         * 22050 / 512 = 43hertz per sample
         * 20 - 60 hz
         * 60 - 250 hz
         * 250 - 500 hz
         * 500 - 2000 hz
         * 2000 - 4000 hz
         * 4000 - 6000 hz
         * 6000 - 20000 hz
         * 
         * 0 - 2 = 86hz
         * 1 - 4 = 172hz : 87-258 hz
         * 2 - 8 = 344hz : 259-602 hz
         * 3 - 16 = 688hz : 603-1290 hz
         * 4 - 32 = 1376hz : 1291-2666 hz
         * 5 - 64 = 2752hz : 2667-5418 hz
         * 6 - 128 = 5504hz : 5419-10922 hz
         * 7 - 265 = 11008hz : 10923-21930 hz
         * 
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                    count++;
            }

            average /= count;

            _freqBand[i] = average * 10;
        }

    }
}
