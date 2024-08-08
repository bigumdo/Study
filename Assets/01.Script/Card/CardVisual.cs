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


    private void Start()
    {
        _shadowDistance = visualShadowTrm.localPosition;
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


