using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioMixer audioMixerSfx;

    public TMP_Dropdown  resolutionDropDown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        int currentResInd = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResInd = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResInd;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetMusic (float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSfx(float volume)
    {
        audioMixerSfx.SetFloat("SfxVolume", volume);
    }

    public void SetResolution (int resolutiýnIndex)
    {
        Resolution resolution = resolutions[resolutiýnIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetSens(float Sensi)
    {
        Sensivition.Sens = Sensi;
    }


}
