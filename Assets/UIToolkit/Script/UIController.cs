using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private VisualElement _bottomContainer;

    private Button _openButton;
    private Button _closeButton;
    private VisualElement _scrim;
    private VisualElement _bottomSheet;

    private void Start()
    {
        // UIdocument�� �ִ� ���� ���� visualElement�� �����´�.
        var root = GetComponent<UIDocument>().rootVisualElement;
        // root���� Container_Bottom�̶�� �̸��� visual Element�� �����´�.
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");

        // Button_Open�� �Ǿ� �ִ� button�� ������
        _openButton = root.Q<Button>("Button_Open");
        // Button_Close��� �Ǿ� �ִ� button�� ������
        _closeButton = root.Q<Button>("Button_Close");
        // Scrim��� �Ǿ� �ִ� VisualElement�� ������
        _scrim = root.Q<VisualElement>("Scrim");
        // BottomSheet��� �Ǿ� �ִ� VisualElement�� ������
        _bottomSheet = root.Q<VisualElement>("BottomSheet");

        // visualElement�� displayer�� None���� �������
        _bottomContainer.style.display = DisplayStyle.None;

        //clickEvnet�� ����Ǹ� OnOpenButtonClicked�� �����Ų��.
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        //clickEvnet�� ����Ǹ� OnCloseButtonClicked�� �����Ų��.
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked(ClickEvent evt)
    {
        // visualElement�� displayer�� None���� �������
        _bottomContainer.style.display = DisplayStyle.None;
        // _bottomContainer, _scrim�� styleclass�� �����Ѵ�.

        //�־��� �� �ִϸ��̼��� �Ǳ� ���� �߰� �ߴ� Ŭ������ �����Ͽ� �ٽ� 
        _bottomSheet.RemoveFromClassList("bottomsheet--up");
        _bottomSheet.RemoveFromClassList("scrim--fadein");
    }

    private void OnOpenButtonClicked(ClickEvent evt)
    {
        // visualElement�� displayer�� Flex�� �������
        _bottomContainer.style.display = DisplayStyle.Flex;
        _bottomSheet.AddToClassList("bottomsheet--up");
        _scrim.AddToClassList("scrim--fadein");
    }
}
