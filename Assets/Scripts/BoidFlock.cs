using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// flock
// populates and executes behavior

public class BoidFlock : MonoBehaviour
{

    public Boid boidPrefab;
    List<Boid> boids = new List<Boid>();
    public BoidBehavior behavior;

    [Range(8, 1024)]
    public int startingCount = 64;
    const float boidDensity = 0.08f;

    // 100f = 100x faster
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        // instantiate flock
        for (int i = 0; i < startingCount; i++)
        {
            Boid newBoid = Instantiate(
                boidPrefab,
                Random.insideUnitSphere * startingCount * boidDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newBoid.name = "Boid " + i;
            newBoid.Initialize(this);
            boids.Add(newBoid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Boid boid in boids)
        {
            List<Transform> context = GetNearByObjects(boid);
            Vector3 move = behavior.CalculateMove(boid, context, this);
            move *= driveFactor;

            // cap at max speed
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            boid.Move(move);
        }
    }

    List<Transform> GetNearByObjects(Boid boid)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(boid.transform.position, neighborRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != boid.BoidCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
