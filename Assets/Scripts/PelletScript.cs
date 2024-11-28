using UnityEngine;

public class PelletScript : MonoBehaviour
{
    [SerializeField]
    [Header("Points")]
    public PointScript points;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public float speed = 2f;
    public float timer;

    void Start()
    {
        points = FindObjectOfType<PointScript>();
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

        timer += Time.deltaTime;
        float divider = timer * speed / speed;
        var move = Vector3.Lerp(transform.position, target.position, divider);
        transform.position = move;
    }

    public void HitTarget()
    {
        Destroy(target.gameObject);
        points.Cash += 100;
        Destroy(gameObject);
    }
}
