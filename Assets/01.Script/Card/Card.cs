using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler

{

    [Header("Movement")]
    [SerializeField] private float _moveSpeedLimit = 50f;

    [Header("States")]
    public bool isHovering;
    public bool isDragging;
    [HideInInspector] public bool wasDragged;

    [Header("Events")]  
    [HideInInspector] public UnityEvent<Card> PointerEnterEvent;
    [HideInInspector] public UnityEvent<Card> PointerExitEvent;
    [HideInInspector] public UnityEvent<Card, bool> PointerUpEvent;
    [HideInInspector] public UnityEvent<Card> PointerDownEvent;
    [HideInInspector] public UnityEvent<Card> BeginDragEvent;
    [HideInInspector] public UnityEvent<Card> EndDragEvent;
    [HideInInspector] public UnityEvent<Card, bool> SelectEvent;

    private Canvas _cardCanvas;
    private Image _imageCompo;
    private Vector3 _offset;
    private GraphicRaycaster _canvasGraphicRayCaster;
    private Rect _screenRect;
    private Camera _mainCam;

    private void Start()
    {
        //For debugging purpose, will be delete meanwhile...
        Canvas canvas = GetComponentInParent<Canvas>();
        Initialize(canvas);
    }

    private void Update()
    {
        ClampPosition();
        DragFollow();
    }

    public void Initialize(Canvas canvas)
    {
        _mainCam = Camera.main;
        _cardCanvas = canvas;
        _imageCompo = GetComponent<Image>();
        _canvasGraphicRayCaster = canvas.GetComponent<GraphicRaycaster>();
        CalculateScreenRect();
    }

    private void CalculateScreenRect()
    {
        Vector2 topLeft = _mainCam.ScreenToWorldPoint(new Vector3(0, Screen.height, _mainCam.transform.position.z));
        Vector2 bottomRight = _mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, _mainCam.transform.position.z));
        Vector2 size = bottomRight - topLeft;
        _screenRect = new Rect(topLeft, size);
    }

    private void ClampPosition()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, _screenRect.xMin, _screenRect.xMax);
        position.y = Mathf.Clamp(position.y, _screenRect.yMax, _screenRect.yMin);  //반전 주의!

        //position.x = Mathf.Clamp(position.x, _screenRect.xMax, _screenRect.xMin);
        //position.y = Mathf.Clamp(position.y,  _screenRect.yMin, _screenRect.yMax);  //반전 주의!
        transform.position = position;
    }

    private void DragFollow()
    {
        if (!isDragging) return;
        Vector2 targetPos = _mainCam.ScreenToWorldPoint(Input.mousePosition) - _offset;
        Vector2 delta = (targetPos - (Vector2)transform.position);
        //Debug.Log(delta);
        //이동 델타를 이동시간으로 나눈 속도와 속도제한중 작은 값을 선택하여 이동
        Vector2 velocity = delta.normalized * Mathf.Min(_moveSpeedLimit, delta.magnitude / Time.deltaTime);
        transform.Translate(velocity * Time.deltaTime);
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent?.Invoke(this);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Calc relative position of mouse with transform center;
        _offset = mousePosition - (Vector2)transform.position;
        isDragging = true;
        //stop raycast to ui
        _canvasGraphicRayCaster.enabled = false;
        _imageCompo.raycastTarget = false;

        wasDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent?.Invoke(this);
        isDragging = false;
        _canvasGraphicRayCaster.enabled = true;
        _imageCompo.raycastTarget = true;

        StartCoroutine(FrameWait());

        IEnumerator FrameWait()
        {
            yield return new WaitForEndOfFrame();
            wasDragged = false;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterEvent?.Invoke(this);
        isHovering = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExitEvent?.Invoke(this);
        isHovering = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
