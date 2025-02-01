using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

namespace QuasoStudio.Services
{
    public class SoundService
    {
        private Dictionary<string, EventReference> _allSound;
        private bool _ambiencePlaying = false;
        private EventInstance _ambienceEventInstance;

        public SoundService(List<FmodSoundDataScriptableObject> AllSound)
        {
            InitializeAllSound(AllSound);
        }

        private void InitializeAllSound(List<FmodSoundDataScriptableObject> AllSound)
        {
            _allSound = new Dictionary<string, EventReference>();

            foreach (FmodSoundDataScriptableObject DATA in AllSound)
            {
                _allSound.Add(DATA._soundName, DATA._eventReference);
            }
        }

        public EventInstance CreateEventInstance(string SoundName)
        {
            // pas de garde fou ici hihi
            EventInstance eventInstance = RuntimeManager.CreateInstance(_allSound[SoundName]);
            return eventInstance;
        }

        #region Play Sound
        public bool PlaySound(string SoundName)
        {
            if (!_allSound.ContainsKey(SoundName))
                return false;
            RuntimeManager.PlayOneShot(_allSound[SoundName]);
            return true;
        }

        public bool PlaySound(string SoundName, UnityEngine.Vector3 WorldPos)
        {
            if (!_allSound.ContainsKey(SoundName))
                return false;
            RuntimeManager.PlayOneShot(_allSound[SoundName], WorldPos);
            return true;
        }

        public bool PlayAmbiance(string SoundName)
        {
            if (!_allSound.ContainsKey(SoundName))
                return false;
            if (_ambiencePlaying)
                StopAmbiance();
            _ambiencePlaying = true;
            _ambienceEventInstance = RuntimeManager.CreateInstance(_allSound[SoundName]);
            _ambienceEventInstance.start();
            return true;
        }

        public void StopAmbiance()
        {
            _ambienceEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _ambienceEventInstance.release();
            _ambiencePlaying = false;
        }
        #endregion
    }
}
