using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Singleton
    public static CameraController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    [SerializeField] private Transform target;
    [SerializeField] private float xOffSet;
    [SerializeField] private float yOffSet;
    [SerializeField] private float zOffSet;
    private Vector3 _targetPos;
    private Vector3 _refVec;

    private enum State
    {
        Game,
        GameEnd
    }
    private State _currentState;

    private void LateUpdate()
    {
        _targetPos = target.position;
        if (_currentState == State.Game)
        {
            transform.position = new Vector3(_targetPos.x / 2f + xOffSet, _targetPos.y + yOffSet, _targetPos.z + zOffSet);
        }
        else
        {
            var targetPos = new Vector3(-0.22f, 1.6f, _targetPos.z + -0.48f);
            var targetRot = new Quaternion(11f, 13.5f, 0, 180);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _refVec, 1.5f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 1.5f);
            gameObject.GetComponent<Camera>().fieldOfView = 100;
        }
    }
    public void GameEnd()
    {
        _currentState = State.GameEnd;
    }
}
