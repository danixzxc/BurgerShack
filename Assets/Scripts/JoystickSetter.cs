using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickSetter : MonoBehaviour
{

    [SerializeField]
    private FloatingJoystick _floatingJoystick;
    [SerializeField]
    private float _deadzoneValue;
    void Start()
    {
        _floatingJoystick.DeadZone = _deadzoneValue;
    }

}
