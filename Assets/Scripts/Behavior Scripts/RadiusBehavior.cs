using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Radius")]
public class RadiusBehavior : BoidBehavior
{
    public Vector3 center;
    public float radius = 15f;

    public override Vector3 CalculateMove(Boid boid, List<Transform> context, BoidFlock boids)
    {
        Vector3 centerOffset = center - boid.transform.position;
        float t = centerOffset.magnitude / radius;
        // if within 90% of the radius, continue on
        if (t < 0.9f)
        {
            return Vector3.zero;
        }

        return centerOffset * t * t;
    }
}
