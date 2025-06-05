using UnityEngine;

public class MJ_GroundPool : MJ_ObjectPool
{
    public static MJ_GroundPool _groundPool;

    public override void Awake()
    {

        base.Awake();
        base.amountToPool = _gameControl._groundNumber;
        _groundPool = this;

    }
}
