using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowHUD : MonoBehaviour
{
    [SerializeField] private Transform _followTrm;

    private VisualElement _dialogBox;
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _dialogBox = _uiDocument.rootVisualElement.Q("DialogBox");
    }

    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(_followTrm.position);
        _dialogBox.style.top = Screen.height - screenPos.y - (_dialogBox.layout.height * 0.5f);
        _dialogBox.style.left = screenPos.x - (_dialogBox.layout.width * 0.5f); //Áß¾Ó À§Ä¡
    }

}
