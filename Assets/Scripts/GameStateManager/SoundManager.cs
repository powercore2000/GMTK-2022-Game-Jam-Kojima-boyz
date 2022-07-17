using System.Collections;
using UnityEngine;

namespace GameStateManager
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Tweaks for random FX Sound")]
        public float lowPitch = 0.95f;
        public float highPitch = 1.05f;
        [Range(0, 1)] public float musicVolume;
        [Range(0, 1)] public float fxVolume;
            
        [Header("Main Menu Music")]
        [SerializeField] private AudioClip mainMenuIntro;
        [SerializeField] private AudioClip mainMenuLoop;
        
        [Header("General Music")]
       
        [SerializeField] private AudioClip[] musicClips;
        [SerializeField] private AudioClip[] winClips;
        [SerializeField] private AudioClip[] loseClips;
        [Header("Dice ")]
        [SerializeField] private AudioClip[] DiceRolls;

        [SerializeField] private AudioClip luckRoll;
        [SerializeField] private AudioClip UnluckRoll;
        [Header("UI")]
        [SerializeField] private AudioClip[] UISounds;


        public void PlayMenuMusic()
        {
            StartCoroutine(PlayMusicRoutine());
         
        }

        public IEnumerator PlayMusicRoutine()
        {
           var source =  PlayClipAtPoint(mainMenuIntro,Vector3.zero,1f,true,true);
           while (source.isPlaying)
           {
               yield return null;
           }
           PlayClipAtPoint(mainMenuLoop,Vector3.zero,1f,false,false,true);
           
        }
        public void PlayGoodDiceResult()
        {
            PlayClipAtPoint(luckRoll, Vector3.zero);
        }
        
        public void PlayBadDiceResult()
        {
            PlayClipAtPoint(UnluckRoll, Vector3.zero);
        }

        public void PlayRandomUISound()
        {
            PlayRandomClipAtPoint(UISounds, Vector3.zero);
        }
        public AudioSource PlayRandomClipAtPoint(AudioClip[] clip, Vector3 pos, float volume = 1f,
            bool isPitchRandomized = true, bool selfDestruct = true)
        {
            if (clip != null)
            {
                if (clip.Length != 0)
                {
                    int index = Random.Range(0, clip.Length);
                    if (clip[index] != null)
                    {
                        AudioSource source = PlayClipAtPoint(clip[index], pos, volume, isPitchRandomized, selfDestruct);
                        return source;
                    }
                }
            }

            return null;
        }
        public AudioSource PlayClipAtPoint(AudioClip clip, Vector3 position, float volume = 1f, 
            bool IsPitchRandomized = true, bool selfDestruct = true,bool loop = false)
        {
            if (clip != null)
            {
                GameObject go = new GameObject("SoundFX" + clip.name);
                go.transform.position = position;
                AudioSource source = go.AddComponent<AudioSource>();
                source.loop = loop;
                source.clip = clip;
                source.volume = volume;
                source.Play();
                if (selfDestruct)
                {
                    Destroy(go, clip.length);
                }

                return source;

            }

            return null;
        }
        

        public void PlayRandomMusic(bool dontDestroyOnLoad)
        {
            AudioSource source = PlayRandomClipAtPoint(musicClips, Vector3.zero, musicVolume, false, false);
            source.loop = true;
            if (dontDestroyOnLoad && source != null)
            {
                DontDestroyOnLoad(source.gameObject);
            }
        }
        

        public void PlayWinSound()
        {
            PlayRandomClipAtPoint(winClips, Vector3.zero, fxVolume);
        }

        public void PlayLoseSound()
        {
            PlayRandomClipAtPoint(loseClips, Vector3.zero, fxVolume);
        }

        public void PlayBonusSound()
        {
            PlayRandomClipAtPoint(DiceRolls, Vector3.zero, fxVolume);
        }
    }
}


   

    
  
    

