using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DoorDoTween : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetLocation = Vector3.zero;

    [SerializeField]
    private GameObject _gameObjectToAnimate;
    private Vector3 _initialPosition;

    [Range(0.5f, 10.0f), SerializeField]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEase = Ease.Linear;


    [SerializeField]
    private DoTweenType _doTweenType = DoTweenType.TriggerDoTween;

    private enum DoTweenType
    {
        TriggerDoTween,
        InterractableDoTween
    }

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = _gameObjectToAnimate.transform.position;

        // if (_doTweenType == DoTweenType.MovementOneWay)
        // {
        //     if (_targetLocation == Vector3.zero)
        //         _targetLocation = transform.position;
        //     Debug.Log(_targetLocation);
        //     transform.DOMove(_targetLocation, _moveDuration);
        // }
    }

    private void Update()
    {
        if(_doTweenType == DoTweenType.InterractableDoTween && Input.GetKeyDown("f"))
        {
            if (_targetLocation == Vector3.zero)
                _targetLocation = transform.position;
            _gameObjectToAnimate.transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_doTweenType == DoTweenType.TriggerDoTween)
        {
            if (other.tag == "Player")
            {
                if (_targetLocation == Vector3.zero)
                    _targetLocation = transform.position;
                _gameObjectToAnimate.transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (_doTweenType == DoTweenType.TriggerDoTween)
        {
            if (other.tag == "Player")
            {
                _gameObjectToAnimate.transform.DOMove(_initialPosition, _moveDuration).SetEase(_moveEase);
            }
        }
    }

    private IEnumerator MoveWithBothWays()
    {
        Vector3 originalLocation = transform.position;
        _gameObjectToAnimate.transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        yield return new WaitForSeconds(_moveDuration);
        _gameObjectToAnimate.transform.DOMove(_initialPosition, _moveDuration).SetEase(_moveEase);
    }

}