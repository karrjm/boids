using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boid boid, List<Transform> context, BoidFlock boids)
    {
        // if no context neighbors, maintain current alignment
        if (context.Count == 0)
        {
            return boid.transform.forward;
        }

        // add all points together and avg
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform item in filteredContext)
        {
            // add facing of object
            alignmentMove += item.forward;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
