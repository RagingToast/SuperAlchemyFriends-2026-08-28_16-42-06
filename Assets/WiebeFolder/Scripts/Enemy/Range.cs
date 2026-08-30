using UnityEngine;

public class Range : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        
        _hp = 50;
        _speed = 5f;
    }
}
