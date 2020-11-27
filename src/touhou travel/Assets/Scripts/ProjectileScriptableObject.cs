using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileScriptableObject")]
public class ProjectileScriptableObject : ScriptableObject
{

    public Projectile.ProjectileType projectileType;
    public Sprite sprite;
   
}
