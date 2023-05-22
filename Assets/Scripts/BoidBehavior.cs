using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// flock behavior

public abstract class BoidBehavior : ScriptableObject
{
    public abstract Vector3 CalculateMove(Boid boid, List<Transform> context, BoidFlock boids);
}
