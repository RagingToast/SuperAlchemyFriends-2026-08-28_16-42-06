using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    
    private Transform _target;
    private Rigidbody _rigidbody;
    private float _speed = 3f;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        CheckForTarget();
    }
    
    void FixedUpdate()
    {
        Vector3 direction = _target.position - transform.position;
        
        _rigidbody.linearVelocity = direction.normalized * _speed;
    }

    void CheckForTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 2f, playerLayer);
        
        foreach (Collider target in targets)
        {
            Debug.Log("FOUNDDDDDDD");
        }
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
