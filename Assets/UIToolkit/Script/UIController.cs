using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public string girlText;

    private VisualElement _bottomContainer;
    private Button _openButton;
    private Button _closeButton;
    private VisualElement _scrim;
    private VisualElement _bottomSheet;
    private VisualElement _boy;
    private VisualElement _girl;
    private Label _girlText;

    private void Awake()
    {
        // UIdocument에 있는 제일 위에 visualElement를 가져온다.
        var root = GetComponent<UIDocument>().rootVisualElement;
        // root에서 Container_Bottom이라는 이름의 visual Element를 가져온다.
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");
        //Boy
        _boy = root.Q<VisualElement>("Image_Boy");
        //Girl
        _girl = root.Q<VisualElement>("Image_Girl");
        //girlText
        _girlText = root.Q<Label>("Girl_Text");
        // Button_Open라 되어 있는 button을 가져옴
        _openButton = root.Q<Button>("Button_Open");
        // Button_Close라고 되어 있는 button을 가져옴
        _closeButton = root.Q<Button>("Button_Close");
        // Scrim라고 되어 있는 VisualElement을 가져옴
        _scrim = root.Q<VisualElement>("Scrim");
        // BottomSheet라고 되어 있는 VisualElement을 가져옴
        _bottomSheet = root.Q<VisualElement>("BottomSheet"); 
    }

    private void OnEnable()
    {
        //clickEvnet가 실행되면 OnOpenButtonClicked를 실행시킨다.
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        //clickEvnet가 실행되면 OnCloseButtonClicked를 실행시킨다.
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);
        //애니메이션 바로 시작하고 한 프레임이 지난 후에 실행해야하기 때문에
        AnimationBoy();
        Invoke("AnimationBoy", 1f);
        //바텀시트가 내려온 다음 그룹은 끈다.
        _bottomSheet.RegisterCallback<TransitionEndEvent>(OnButtonSheetDown);
    }

    private void OnDisable()
    {
        _openButton.UnregisterCallback<ClickEvent>(OnOpenButtonClicked);
        _closeButton.UnregisterCallback<ClickEvent>(OnCloseButtonClicked);
        _bottomSheet.UnregisterCallback<TransitionEndEvent>(OnButtonSheetDown);
    }

    private void OnButtonSheetDown(TransitionEndEvent evt)
    {
        if(!_bottomSheet.ClassListContains("bottomsheet--up"))
        {
            // visualElement에 displayer를 None으로 만들어줌
            _bottomContainer.style.display = DisplayStyle.None;
        }
    }

    private void AnimationBoy()
    {
        _boy.RemoveFromClassList("image--boy--inair");  
    }

    private void OnCloseButtonClicked(ClickEvent evt)
    {

        // _bottomContainer, _scrim에 styleclass를 추가한다.

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
        GirlAnimation();
    }

    private void GirlAnimation()
    {
        _girl.ToggleInClassList("image--girl--down");
        _girl.RegisterCallback<TransitionEndEvent>
            (
                evt => _girl.ToggleInClassList("image--girl--down")
            );
        _girlText.text = string.Empty;
        string m = girlText;
        //_girlText.text에 x가 m으로 3초안에 만든다.
        DOTween.To(() => _girlText.text, x => _girlText.text = x, m, 3f).SetEase(Ease.Linear);
    }
}
