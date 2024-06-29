using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private HingeJoint _joint;

    private float _secondsDelay = 0.5f;
    private Coroutine _coroutine;
    private WaitForSeconds _delayTime;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_secondsDelay); 
    }

    public void Pump()
    {
        _joint.useMotor = true;

        Delay();
    }

    private void Delay()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(DelayPump());
    }

    private IEnumerator DelayPump()
    {
        yield return _delayTime;

        _joint.useMotor = false;
    }
}
