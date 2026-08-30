using System;
using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private Animator animator;

    private Transform _target;
    private Rigidbody _rigidbody;
    private bool _canAttack;

    //new variable
    private int _maxHp;

    public virtual float _speed { get; protected set; } = 0f;
    public virtual int _hp { get; protected set; } = 0;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        //modified line of code
        animator = GetComponent<Animator>();
    }

    //new function
    void OnEnable()
    {
        _hp = _maxHp;
        _canAttack = true;
    }

    void Update()
    {
        CheckForTarget();
    }

    void FixedUpdate()
    {
        Vector3 direction = _target.position - transform.position;

        _rigidbody.linearVelocity = direction.normalized * _speed;

        _rigidbody.rotation = Quaternion.LookRotation(direction);

        animator.SetTrigger("Run");
    }

    void CheckForTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 2f, playerLayer);

        foreach (Collider target in targets)
        {
            Debug.Log("FOUNDDDDDDD");
            if (_canAttack)
            {
                Attack();
            }
        }
    }

    public void TakeDamage()
    {
        _hp -= 10;

        //new lines of code
        if (_hp <= 0)
        {
            Die();
        }
    }

    //new function
    private void Die()
    {
        _rigidbody.linearVelocity = Vector3.zero;

        EnemySpawner.instance.EnemyDied(gameObject);
    }

    void Attack()
    {
        Debug.Log("Hit");

        StartCoroutine(AtkCooldown());
    }

    IEnumerator AtkCooldown()
    {
        _canAttack = false;

        yield return new WaitForSeconds(2f);

        _canAttack = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }

    //new function
    protected void SetMaxHP(int hp)
    {
        _maxHp = hp;
    }
}