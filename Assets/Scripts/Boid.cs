using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// flock agent

[RequireComponent(typeof(Collider))]
public class Boid : MonoBehaviour
{
    BoidFlock boidFlock;
    public BoidFlock BoidFlock { get { return boidFlock; } }
    Collider boidCollider;
    public Collider BoidCollider { get { return boidCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        boidCollider = GetComponent<Collider>();
    }

    public void Initialize(BoidFlock flock)
    {
        boidFlock = flock;
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
