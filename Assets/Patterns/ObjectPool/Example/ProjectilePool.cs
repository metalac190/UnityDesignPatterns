using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an example of an implementation of our generic ObjectPool. By inheriting from
/// ObjectPoolMB we get the majority of the functionality. We don't really need to add much in the class,
/// but we always have the option to expand on it if needed.
/// </summary>
namespace Examples.ObjectPool
{
    public class ProjectilePool : ObjectPoolMB<Projectile>
    {

    }
}

