using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _springPower = 100;

    private Vector3 _buletStartPosition;
    private Transform _bulletTransform;

    private float _secondsDelay = 3;
    private Coroutine _coroutine;
    private WaitForSeconds _delayTime;


    private void Awake()
    {
        _bulletTransform = _bullet.transform;
        _buletStartPosition = _bulletTransform.position;   
        _delayTime = new WaitForSeconds(_secondsDelay);
    }

    public void Launch()
    {
        _springJoint.spring = _springPower;

        Delay();
    }

    private void Delay()
    { 
        if (_coroutine != null) 
        { 
           StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(DelayCharging());
    }

    private IEnumerator DelayCharging()
    { 
        yield return _delayTime;
        
        _springJoint.spring = 0;
        _bulletTransform.position = _buletStartPosition;    
    }
}
