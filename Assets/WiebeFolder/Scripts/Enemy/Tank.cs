using UnityEngine;

public class Tank : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        
        _hp = 80;
        _speed = 3f;
        
        SetMaxHp(80);
    }
}
