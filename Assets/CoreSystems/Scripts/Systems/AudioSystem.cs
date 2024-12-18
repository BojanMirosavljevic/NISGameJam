using System.Collections;
using UnityEngine;

public class AudioSystem : PersistentSingleton<AudioSystem>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    private AudioClip previouslyPlayedClip;

    [SerializeField] private AudioClip MusicLoading;
    [SerializeField] private AudioClip MusicDialog;
    [SerializeField] private AudioClip MusicSelecting;

    [SerializeField] private AudioClip SoundChangeScene;
    [SerializeField] private AudioClip SoundButton;
    [SerializeField] private AudioClip SoundSelect;
    [SerializeField] private AudioClip SoundWrong;
    [SerializeField] private AudioClip SoundSuccess;
    [SerializeField] private AudioClip SoundZnakovi;
    [SerializeField] private AudioClip SoundOdaberiteRadnike;
    [SerializeField] private AudioClip SoundJaoNoga;

    public void PlayMusic(AudioClip clip, float volume = 0.3f, bool shouldLoop = true)
    {
        if (previouslyPlayedClip == clip)
        {
            return;
        }
        musicSource.clip = clip;
        previouslyPlayedClip = clip;
        musicSource.loop = shouldLoop;
        musicSource.volume = 0f;
        musicSource.Stop();
        musicSource.Play();

        StartCoroutine(StartFade(musicSource, 0.5f, volume));
    }
    
    public void PlayMusicLoading()
    {
        PlayMusic(MusicLoading, 0.06f, true);
    }
    
    public void PlayMusicDialog()
    {
        PlayMusic(MusicDialog, 0.15f, true);
    }
    
    public void PlayMusicSelecting()
    {
        PlayMusic(MusicSelecting, 0.25f, true);
    }

    public void PlaySound(AudioClip clip, float vol = 0.7f)
    {
        soundsSource.PlayOneShot(clip, vol);
    }

    public void PlayButtonSound()
    {
        soundsSource.PlayOneShot(SoundButton, 0.6f);
    }
    public void PlaySoundSelect()
    {
        soundsSource.PlayOneShot(SoundSelect, 0.7f);
    }
    public void PlaySoundWrong()
    {
        soundsSource.PlayOneShot(SoundWrong, 1f);
    }
    public void PlaySoundSuccess()
    {
        soundsSource.PlayOneShot(SoundSuccess, 0.8f);
    }
    public void PlaySceneChangeSound()
    {
        soundsSource.PlayOneShot(SoundChangeScene, 1f);
    }
    public void PlaySoundZnakovi()
    {
        soundsSource.PlayOneShot(SoundZnakovi, 0.9f);
    }
    public void PlaySoundOdaberiteRadnike()
    {
        soundsSource.PlayOneShot(SoundOdaberiteRadnike, 0.9f);
    }
    public void PlaySoundJaoNoga()
    {
        soundsSource.PlayOneShot(SoundJaoNoga, 1f);
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}