using UnityEngine;

public class Speed : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        
        _hp = 30;
        _speed = 7f;
    }
}
