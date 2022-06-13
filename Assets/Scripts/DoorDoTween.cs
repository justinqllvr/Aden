using DG.Tweening;
using System.Collections;
using UnityEngine;
using TMPro;
public class DoorDoTween : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetLocation = Vector3.zero;

    [SerializeField]
    private Vector3 _initialTargetRotation = Vector3.zero;

    [SerializeField]
    private GameObject _gameObjectToAnimate;

    [SerializeField]
    private GameObject _gameObjectToInterract;


    [Range(0.5f, 10.0f), SerializeField]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEase = Ease.Linear;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private TextMeshProUGUI _interractionText;

    [SerializeField] [TextArea]
    private string _interractionTextText;


    [SerializeField]
    private DoTweenType _doTweenType = DoTweenType.TriggerDoTween;

    private bool isAnimated = false;
    private Vector3 _initialPosition;
    private Vector3 _initialRotation;
    private Vector3 _targetRotation;
    private RaycastHit _hit;

    public static bool canOpenDoor = false;

    private enum DoTweenType
    {
        TriggerDoTween,
        InterractableDoTween,
        InterractableHistoryDoTween
    }

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = _gameObjectToAnimate.transform.position;
        _initialRotation = _gameObjectToAnimate.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        //OBJECT INTERRACTABLE HISTOIRE
        if (_camera != null && _doTweenType == DoTweenType.InterractableHistoryDoTween && Input.GetKeyDown("f") && isAnimated == false && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out _hit, Mathf.Infinity))
        {
            if(_hit.transform.gameObject.tag == "interractableHistory" && _hit.transform.gameObject == _gameObjectToInterract)
            {
                isAnimated = true;
                _targetLocation = Vector3.Scale(Camera.main.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)) + Camera.main.transform.position;
                GameState.setIsPlaying(false);
                transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
                transform.DOLookAt(new Vector3(1 - Camera.main.transform.forward.x * 180, 1 - Camera.main.transform.forward.y * 180, 1 - Camera.main.transform.forward.z * 180), _moveDuration).OnStart(() => { _interractionText.gameObject.SetActive(true); });
                if(_initialTargetRotation != Vector3.zero)
                {
                    transform.DORotate(_initialTargetRotation, _moveDuration).SetEase(_moveEase);
                }
                if(_hit.collider.gameObject.name == "doc_appart_2")
                {
                    canOpenDoor = true;
                    GameObject.Find("bouton_porte").GetComponent<Outline>().OutlineColor = new Color(0, 1f, 0,1); ;
                }
                
            }
        } else if (_camera != null && _doTweenType == DoTweenType.InterractableHistoryDoTween && Input.GetKeyDown("f") && isAnimated == true)
        {
            transform.DOMove(_initialPosition, _moveDuration).SetEase(_moveEase);
            _interractionText.gameObject.SetActive(false);
            transform.DOLookAt(new Vector3( _initialRotation.x, _initialRotation.y, _initialRotation.z), _moveDuration);
            transform.DORotate(_initialRotation, _moveDuration);
            GameState.setIsPlaying(true);
            isAnimated = false;
        }

        //DOOROBJECTS
        if (_doTweenType == DoTweenType.InterractableDoTween && Input.GetKeyDown("f") && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out _hit, Mathf.Infinity))
        {
            if (_hit.transform.gameObject.tag == "interractable")
            {
                if (_targetLocation == Vector3.zero)
                    _targetLocation = transform.position;
                if(getCanOpenDoor())
                {
                    StartCoroutine(MoveWithBothWays());
                } else
                {
                    Debug.Log("PEUX PAS OUVRIR LA PORTE PRENDS LE DOC");
                }
            }
                
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

        //if (_doTweenType == DoTweenType.TriggerDoTween)
        //{
        //    if (other.tag == "Player")
        //    {
        //        _gameObjectToAnimate.transform.DOMove(_initialPosition, _moveDuration).SetEase(_moveEase);
        //    }
        //}
    }

    private IEnumerator MoveWithBothWays()
    {
        _gameObjectToAnimate.transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        yield return new WaitForSeconds(_moveDuration + 1);
        _gameObjectToAnimate.transform.DOMove(_initialPosition, _moveDuration).SetEase(_moveEase);
    }

    public static bool getCanOpenDoor()
    {
        return canOpenDoor;
    }
}