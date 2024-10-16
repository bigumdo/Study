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
        // UIdocument에 있는 제일 위에 visualElement를 가져온다.
        var root = GetComponent<UIDocument>().rootVisualElement;
        // root에서 Container_Bottom이라는 이름의 visual Element를 가져온다.
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");

        // Button_Open라 되어 있는 button을 가져옴
        _openButton = root.Q<Button>("Button_Open");
        // Button_Close라고 되어 있는 button을 가져옴
        _closeButton = root.Q<Button>("Button_Close");
        // Scrim라고 되어 있는 VisualElement을 가져옴
        _scrim = root.Q<VisualElement>("Scrim");
        // BottomSheet라고 되어 있는 VisualElement을 가져옴
        _bottomSheet = root.Q<VisualElement>("BottomSheet");

        // visualElement에 displayer를 None으로 만들어줌
        _bottomContainer.style.display = DisplayStyle.None;

        //clickEvnet가 실행되면 OnOpenButtonClicked를 실행시킨다.
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        //clickEvnet가 실행되면 OnCloseButtonClicked를 실행시킨다.
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked(ClickEvent evt)
    {
        // visualElement에 displayer를 None으로 만들어줌
        _bottomContainer.style.display = DisplayStyle.None;
        // _bottomContainer, _scrim에 styleclass를 차가한다.

        //넣었을 때 애니메이션이 되기 위해 추가 했던 클래스를 제거하여 다시 
        _bottomSheet.RemoveFromClassList("bottomsheet--up");
        _bottomSheet.RemoveFromClassList("scrim--fadein");
    }

    private void OnOpenButtonClicked(ClickEvent evt)
    {
        // visualElement에 displayer를 Flex로 만들어줌
        _bottomContainer.style.display = DisplayStyle.Flex;
        _bottomSheet.AddToClassList("bottomsheet--up");
        _scrim.AddToClassList("scrim--fadein");
    }
}
