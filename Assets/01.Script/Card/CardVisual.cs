using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{
    private bool _initialize = false;

    [Header("Card")]
    public Card parentCard;
    private Transform _cardTrm;
    private Vector3 _rotationDelta;
    private int _savedIndex;
    private Vector3 _movementDelta;
    private Canvas _visualCanvas;

    [Header("References")]
    public Transform visualShadowTrm;
    private float _shadowOffset;
    private Vector2 _shadowDistance;
    private Canvas _shadowCanvas;
    [SerializeField] private Transform _shakeParentTrm, _tiltParentTrm;
    [SerializeField] private Image _cardImage;

    [Header("Curve")]
    [SerializeField] private CurveParamSO _curve;
    private float _curveYOffset;
    private float _curveRotationOffset;


    [Header("Follow parameter")]
    [SerializeField] private float _followSpeed = 30f;

    [Header("Rotation parameter")]
    [SerializeField] private float _rotationAmount = 20, _rotationSpeed = 20;
    [SerializeField] private float _autoTiltAmount = 30, _manualTiltAmount = 20, _tiltSpeed = 20;

    [Header("Swap parameter")]
    [SerializeField] private bool _swapAnimation = true;
    [SerializeField] private float _swapRotationAngle = 30f, _swapTransition = 0.15f;
    [SerializeField] private int _swapVibrato = 5;

    private void Start()
    {
        _shadowDistance = visualShadowTrm.localPosition;
    }

    private void Update()
    {
        if (!_initialize || parentCard == null) return;

        HandPositioning();
        SmoothFollow();
        FollowRotation();
    }

    public void UpdateIndex()
    {
        transform.SetSiblingIndex(parentCard.SlotIndex);
    }


    private void FollowRotation()
    {
        Vector3 movement = (transform.position - _cardTrm.position); //Calculate parent movement;
        _movementDelta = Vector3.Lerp(_movementDelta, movement, 25 * Time.deltaTime);
        //smooth rotate which dragging item, hard rotating which sorting item

        Vector3 movementRot = (parentCard.isDragging ? _movementDelta : movement) * _rotationAmount;
        _rotationDelta = Vector3.Lerp(_rotationDelta, movementRot, _rotationSpeed * Time.deltaTime);
        Vector3 angles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(angles.x, angles.y, Mathf.Clamp(_rotationDelta.x, -60f, 60f));
    }


    private void HandPositioning()
    {
        float cardIndexNormal = parentCard.NormalizedPosition;
        int cardSiblingCnt = parentCard.SiblingAmount;
        _curveYOffset = _curve.positioning.Evaluate(cardIndexNormal)
                        * _curve.positioningInfluence
                        * cardSiblingCnt;
        _curveYOffset = cardSiblingCnt < 5 ? 0 : _curveYOffset; //자식의 갯수가 5보다 작으면 0으로
        _curveRotationOffset = _curve.rotation.Evaluate(cardIndexNormal);
    }

    private void SmoothFollow()
    {
        Vector3 verticalOffset = Vector3.up * (parentCard.isDragging ? 0 : _curveYOffset);
        transform.position = Vector3.Lerp(transform.position, _cardTrm.position + verticalOffset, _followSpeed * Time.deltaTime);
    }


    public void Initialize(Card target)
    {
        parentCard = target;
        _cardTrm = target.transform;
        _visualCanvas = GetComponent<Canvas>();
        _shadowCanvas = visualShadowTrm.GetComponent<Canvas>();

        parentCard.PointerEnterEvent.AddListener(PointerEnter);
        parentCard.PointerExitEvent.AddListener(PointerExit);
        parentCard.BeginDragEvent.AddListener(BeginDrag);
        parentCard.EndDragEvent.AddListener(EndDrag);
        parentCard.PointerDownEvent.AddListener(PointerDown);
        parentCard.PointerUpEvent.AddListener(PointerUp);
        parentCard.SelectEvent.AddListener(Select);

        _initialize = true;
    }

    private void PointerEnter(Card card)
    {

    }

    private void PointerExit(Card card)
    {

    }

    private void BeginDrag(Card card)
    {

    }

    private void EndDrag(Card card)
    {

    }

    private void PointerDown(Card card)
    {

    }

    private void PointerUp(Card card, bool longPress)
    {

    }

    private void Select(Card card, bool state)
    {

    }

}


