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
        // UIdocument�� �ִ� ���� ���� visualElement�� �����´�.
        var root = GetComponent<UIDocument>().rootVisualElement;
        // root���� Container_Bottom�̶�� �̸��� visual Element�� �����´�.
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");
        //Boy
        _boy = root.Q<VisualElement>("Image_Boy");
        //Girl
        _girl = root.Q<VisualElement>("Image_Girl");
        //girlText
        _girlText = root.Q<Label>("Girl_Text");
        // Button_Open�� �Ǿ� �ִ� button�� ������
        _openButton = root.Q<Button>("Button_Open");
        // Button_Close��� �Ǿ� �ִ� button�� ������
        _closeButton = root.Q<Button>("Button_Close");
        // Scrim��� �Ǿ� �ִ� VisualElement�� ������
        _scrim = root.Q<VisualElement>("Scrim");
        // BottomSheet��� �Ǿ� �ִ� VisualElement�� ������
        _bottomSheet = root.Q<VisualElement>("BottomSheet"); 
    }

    private void OnEnable()
    {
        //clickEvnet�� ����Ǹ� OnOpenButtonClicked�� �����Ų��.
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        //clickEvnet�� ����Ǹ� OnCloseButtonClicked�� �����Ų��.
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);
        //�ִϸ��̼� �ٷ� �����ϰ� �� �������� ���� �Ŀ� �����ؾ��ϱ� ������
        AnimationBoy();
        Invoke("AnimationBoy", 1f);
        //���ҽ�Ʈ�� ������ ���� �׷��� ����.
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
            // visualElement�� displayer�� None���� �������
            _bottomContainer.style.display = DisplayStyle.None;
        }
    }

    private void AnimationBoy()
    {
        _boy.RemoveFromClassList("image--boy--inair");  
    }

    private void OnCloseButtonClicked(ClickEvent evt)
    {

        // _bottomContainer, _scrim�� styleclass�� �߰��Ѵ�.

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
        //_girlText.text�� x�� m���� 3�ʾȿ� �����.
        DOTween.To(() => _girlText.text, x => _girlText.text = x, m, 3f).SetEase(Ease.Linear);
    }
}
