using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Scriptables/WeaponScriptableObject", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{
    public int totalAmmo;
    public float timeToReload;
}
