using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "FmodSoundDataScriptableObject", menuName = "Scriptable Objects/FmodSoundDataScriptableObject")]
public class FmodSoundDataScriptableObject : ScriptableObject
{
    [SerializeField] public string _soundName;
    [SerializeField] public EventReference _eventReference;
}