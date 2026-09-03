using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        // Move towards the current target waypoint.
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);

        // Give the enemy a dead zone to avoid jitter.
        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.points.Length - 1)
        {
            Debug.Log($"{name} reached the end...");
            Destroy(gameObject);
            return;
        }
        
        _wavePointIndex++;
        _target = Waypoints.points[_wavePointIndex];
    }
}
