using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContextFilter
{
    public override List<Transform> Filter(Boid agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            Boid itemAgent = item.GetComponent<Boid>();
            if (itemAgent != null && itemAgent.BoidFlock  == agent.BoidFlock)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
