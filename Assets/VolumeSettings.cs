using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlide;

    private void Start()
    {
        SetMusicVolume();
    }
public void SetMusicVolume()
{
    float volume = musicSlide.value;
    float volumeInDecibels = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20; // Menghindari nilai negatif atau nol
    myMixer.SetFloat("music", volumeInDecibels);
}

}
