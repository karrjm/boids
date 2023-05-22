using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boid boid, List<Transform> context, BoidFlock boids)
    {
        // if no context neighbors, no adjustment needed
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // add all points together and avg
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform item in filteredContext)
        {
            Vector3 closestPoint = item.gameObject.GetComponent<Collider>().ClosestPoint(boid.transform.position);
            if (Vector3.SqrMagnitude(closestPoint - boid.transform.position) < boids.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += boid.transform.position - item.position; 
            }
        }
        if (nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }
        return avoidanceMove;
    }
}
