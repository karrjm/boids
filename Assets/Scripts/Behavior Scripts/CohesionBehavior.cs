using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boid boid, List<Transform> context, BoidFlock boids)
    {
        // if no context neighbors, no adjustment needed
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // add all points together and avg
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += item.position;
            }
        cohesionMove /= context.Count;

        // create offset from boid position
        cohesionMove -= boid.transform.position;
        return cohesionMove;
    }
}
