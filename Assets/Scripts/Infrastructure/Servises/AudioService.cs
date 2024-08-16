using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Test_Pendulum
{
    public class AudioService
    {
        private AudioMixerGroup sfxAudioGroup;

        public AudioService(AudioMixerGroup sfxAudioGroup)
        {
            this.sfxAudioGroup = sfxAudioGroup;
        }

        public void PlaySFX(AudioClip clip, Vector3 position)
        {
            PlayOneShot(clip, position, group: sfxAudioGroup);
        }

        public void PlayOneShot(AudioClip clip, Vector3 position, float volume = 1.0f, AudioMixerGroup group = null)
        {
            //AudioSource.PlayClipAtPoint(clip, position);
            if (clip == null) return;
            GameObject gameObject = new GameObject("One shot audio");
            gameObject.transform.position = position;
            AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            if (group != null)
                audioSource.outputAudioMixerGroup = group;
            audioSource.clip = clip;
            audioSource.spatialBlend = 1f;
            audioSource.volume = volume;
            audioSource.Play();
            Object.Destroy(gameObject, clip.length * (Time.timeScale < 0.009999999776482582 ? 0.01f : Time.timeScale));
        }
    }
}