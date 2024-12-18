using System.Collections;
using UnityEngine;

/// <summary>
/// Insanely basic audio system which supports 3D sound.
/// Ensure you change the 'Sounds' audio source to use 3D spatial blend if you intend to use 3D sounds.
/// </summary>
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
    [SerializeField] private AudioClip SoundZnakovi;
    [SerializeField] private AudioClip SoundOdaberiteRadnike;

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
        PlayMusic(MusicSelecting, 0.3f, true);
    }

    public void PlaySound(AudioClip clip, float vol = 0.7f)
    {
        soundsSource.PlayOneShot(clip, vol);
    }

    public void PlayButtonSound()
    {
        soundsSource.PlayOneShot(SoundButton, 0.8f);
    }
    public void PlaySoundSelect()
    {
        soundsSource.PlayOneShot(SoundSelect, 0.8f);
    }
    public void PlaySoundWrong()
    {
        soundsSource.PlayOneShot(SoundWrong, 1f);
    }
    public void PlaySceneChangeSound()
    {
        soundsSource.PlayOneShot(SoundChangeScene, 0.8f);
    }
    public void PlayButtonZnakovi()
    {
        soundsSource.PlayOneShot(SoundZnakovi, 0.8f);
    }
    public void PlayButtonOdaberiteRadnike()
    {
        soundsSource.PlayOneShot(SoundOdaberiteRadnike, 0.8f);
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