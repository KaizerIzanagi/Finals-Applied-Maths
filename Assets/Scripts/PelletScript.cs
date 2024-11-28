using UnityEngine;

public class PelletScript : MonoBehaviour
{
    [SerializeField]
    [Header("Points")]
    public PointScript points;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public float speed = 60f;

    void Start()
    {
        points = GetComponent<PointScript>();
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        MoveBullet();
    }

    private void OnDestroy()
    {

    }

    public void Attack(Transform _target)
    {
        target = _target;
    }

    void MoveBullet()
    {
        Vector3 direction = target.position - transform.position;
        float constSpeed = speed * Time.deltaTime;

        if (direction.magnitude <= constSpeed)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * constSpeed, Space.World);
    }

    public void HitTarget()
    {
        Destroy(target.gameObject);
        points.Cash += 100;
        Destroy(gameObject);
    }
}
