using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class SoundSystem : MonoBehaviour
    {
        public List<GameObject> MusicManagers = new List<GameObject>();
        public List<GameObject> EffectManagers = new List<GameObject>();


        AudioSource[] musics;
        AudioSource[] effects;

        int[] curr_music_ids;
        int[] curr_effect_ids;

        float MainVolume;
        float MusicVolume;
        float EffectVolume;


        private static SoundSystem instance;
        public static SoundSystem Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            instance = this;
            musics = new AudioSource[MusicManagers.Count];
            curr_music_ids = new int[MusicManagers.Count];
            for (int i = 0; i < MusicManagers.Count; i++)
            {
                musics[i] = MusicManagers[i].GetComponent<AudioSource>();
                curr_music_ids[i] = 0;
            }


            effects = new AudioSource[EffectManagers.Count];
            curr_effect_ids = new int[EffectManagers.Count];
            for (int i = 0; i < EffectManagers.Count; i++)
            {
                effects[i] = EffectManagers[i].GetComponent<AudioSource>();
                curr_effect_ids[i] = 0;
            }


            MainVolume = 1f;
            MusicVolume = 1f;
            EffectVolume = 1f;

        }

        public void PlayMusic(string name)
        {
            int id = Data_AudioID.Dic[name].ID;
            string path = Data_AudioID.Dic[name].path;

            for (int i = 0; i < MusicManagers.Count; i++)
            {
                if (!musics[i].isPlaying && curr_music_ids[i] == id)
                {
                    musics[i].Play();
                    return;
                }
            }

            for (int i = 0; i < MusicManagers.Count; i++)
            {
                if (!musics[i].isPlaying)
                {
                    if (ObjectPoolSystem.Instance.TestAudioClipPool(id))
                    {
                        AudioClip temp = ObjectPoolSystem.Instance.GetAudioClipFormPool(id);
                        if (temp != null)
                        {
                            musics[i].clip = temp;
                            musics[i].Play();
                            curr_music_ids[i] = id;
                        }
                    }
                    else
                    {
                        AudioClip temp = Resources.Load<AudioClip>(path);
                        musics[i].clip = temp;
                        musics[i].Play();
                        curr_music_ids[i] = id;
                    }
                    return;
                }
            }

            Debug.LogError("MusicManager Num is bad");
            return;
        }

        public void StopMusic(string name)
        {
            int id = Data_AudioID.Dic[name].ID;
            string path = Data_AudioID.Dic[name].path;

            for (int i = 0; i < MusicManagers.Count; i++)
            {
                if (curr_music_ids[i] == id)
                {
                    musics[i].Stop();
                }
            }
        }

        public void StopAllMusic()
        {
            for (int i = 0; i < MusicManagers.Count; i++)
            {
                musics[i].Stop();
            }
        }

        public void PlayEffect(string name)
        {
            int id = Data_AudioID.Dic[name].ID;
            string path = Data_AudioID.Dic[name].path;

            for (int i = 0; i < EffectManagers.Count; i++)
            {
                if (!effects[i].isPlaying && curr_effect_ids[i] == id)
                {
                    effects[i].Play();
                    return;
                }
            }

            for (int i = 0; i < EffectManagers.Count; i++)
            {
                if (!effects[i].isPlaying)
                {
                    if (ObjectPoolSystem.Instance.TestUIFormPool(id))
                    {
                        AudioClip temp = ObjectPoolSystem.Instance.GetAudioClipFormPool(id);
                        if (temp != null)
                        {
                            effects[i].clip = temp;
                            effects[i].Play();
                            curr_effect_ids[i] = id;
                        }
                    }
                    else
                    {

                        AudioClip temp = Resources.Load<AudioClip>(path);
                        effects[i].clip = temp;
                        effects[i].Play();
                        curr_effect_ids[i] = id;
                    }
                    return;
                }
            }

            Debug.LogError("EffectManage Num is bad");
            return;
        }

        public void StopAllEffect()
        {
            for (int i = 0; i < MusicManagers.Count; i++)
            {
                effects[i].Stop();
            }
        }

        /// <summary>
        /// 设置背景音乐音量
        /// </summary>
        /// <param name="value">0-1的小数</param>
        public void SetMusicVolume(float value)
        {
            MusicVolume = value;
            for (int i = 0; i < EffectManagers.Count; i++)
            {
                musics[i].volume = EffectVolume * MainVolume;
            }
        }

        /// <summary>
        /// 设置音效音量
        /// </summary>
        /// <param name="value">0-1的小数</param>
        public void SetEffectVolume(float value)
        {
            EffectVolume = value;
            for (int i = 0; i < EffectManagers.Count; i++)
            {
                effects[i].volume = EffectVolume * MainVolume;
            }
        }

        /// <summary>
        /// 设置所有音乐音量
        /// </summary>
        /// <param name="value">0-1的小数</param>
        public void SetMainVolume(float value)
        {
            MainVolume = value;

            for (int i = 0; i < MusicManagers.Count; i++)
            {
                musics[i].volume = MusicVolume * MainVolume;
            }

            for (int i = 0; i < EffectManagers.Count; i++)
            {
                effects[i].volume = EffectVolume * MainVolume;
            }
        }
    }
}

