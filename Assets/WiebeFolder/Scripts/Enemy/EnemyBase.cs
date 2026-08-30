using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    
    private Transform _target;
    private Rigidbody _rigidbody;
    
    public virtual float _speed { get; protected set; } = 0f;
    public virtual int _hp { get; protected set; } = 0;

    protected virtual void Awake()
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
    
    void  FixedUpdate()
    {
        Vector3 direction = _target.position - transform.position;
        
        _rigidbody.linearVelocity = direction.normalized * _speed;
        
        _rigidbody.rotation = Quaternion.LookRotation(direction);
    }

    void CheckForTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 2f, playerLayer);
        
        foreach (Collider target in targets)
        {
            Debug.Log("FOUNDDDDDDD");
        }
    }
    
    public void TakeDamage()
    {
        _hp -= 10;
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
