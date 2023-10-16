using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    BackGround_Menu,
    BackGround_ChooseLevel,
    BackGround_GamePlaying,

    WinGame,
    LoseGame,

    Hit,
    Impac_Skill_Tower
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public float originalVolume; // L?u tr? gi  tr?  m l??ng ban ??u c?a  m thanh

    public void SetOriginalVolume(float value)
    {
        originalVolume = value;
    }
}





public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<Sound> sounds;

    private Dictionary<SoundType, AudioSource> audioSources;

    public bool activeSound = true;

    public int index_Sound_BR = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSources = new Dictionary<SoundType, AudioSource>();
        foreach (Sound sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            sound.SetOriginalVolume(sound.volume);
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;
            audioSources.Add((SoundType)System.Enum.Parse(typeof(SoundType), sound.name), source);
        }
        activeSound = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
        if (activeSound)
        {
            PlayBackGround(index_Sound_BR);
        }
    }

    public void PlayBackGround(int index)
    {
        if (index == 1)
        {
            StopAllMusicBackGround();

            SoundManager.instance.PlaySound(SoundType.BackGround_Menu);
        }
        else if (index == 2)
        {
            StopAllMusicBackGround();

            SoundManager.instance.PlaySound(SoundType.BackGround_ChooseLevel);
        }
        else if (index == 3)
        {
            StopAllMusicBackGround();

            SoundManager.instance.PlaySound(SoundType.BackGround_GamePlaying);
        }
       

    }

    public void PlaySound(SoundType soundType)
    {
        if (audioSources.ContainsKey(soundType))
        {
            audioSources[soundType].Play();
        }
    }

    public void StopSound(SoundType soundType)
    {
        if (audioSources.ContainsKey(soundType))
        {
            audioSources[soundType].Stop();
        }
    }


    public void PauseSound()
    {
        foreach (KeyValuePair<SoundType, AudioSource> entry in audioSources)
        {
            entry.Value.volume = 0f;
        }

    }
    public void SetAllVolumesToOriginal()
    {
        foreach (KeyValuePair<SoundType, AudioSource> entry in audioSources)
        {
            Sound sound = sounds.Find(s => s.name == entry.Key.ToString());
            entry.Value.volume = sound.originalVolume;
        }
        //PlayBackGround(index_Sound_BR);
    }

    public void StopAllMusicBackGround()
    {
        StopSound(SoundType.BackGround_Menu);
        StopSound(SoundType.BackGround_ChooseLevel);
        StopSound(SoundType.BackGround_GamePlaying);
    }


    public bool ToggleSound()
    {
        activeSound = !activeSound;

        if (activeSound)
        {
            //TURN ON ALL SOUND
            PlayerPrefs.SetInt("Sound", 1);
            SetAllVolumesToOriginal();  
        }
        else
        {
            //TURN OFF ALL SÔUND
            PlayerPrefs.SetInt("Sound", 0);
            PauseSound(); 
        }
        return activeSound;
    }
}

