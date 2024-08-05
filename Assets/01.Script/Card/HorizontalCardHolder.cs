using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gondr
{
    public class HorizontalCardHolder : MonoBehaviour
    {
        [SerializeField] private Card _selectedCard;
        [SerializeReference] private Card _hoveredCard;

        [SerializeField] private GameObject _slotPrefab;

        [SerializeField] private Canvas _cardCanvas;

        [Header("Spawn Settings")]
        [SerializeField] private int _cardToSpawn = 7;
        public List<Card> cards;

        private bool _isCrossing = false;
        private RectTransform _rectTrm;

        private void Start()
        {
            for (int i = 0; i < _cardToSpawn; i++)
            {
                Instantiate(_slotPrefab, transform); //instantiate cards to child
            }

            _rectTrm = transform as RectTransform;
            cards = GetComponentsInChildren<Card>().ToList(); //get card from child
            int cardIndex = 0;
            cards.ForEach(card =>
            {
                card.PointerEnterEvent.AddListener(CardPointerEnter);
                card.PointerExitEvent.AddListener(CardPointerExit);
                card.BeginDragEvent.AddListener(BeginDrag);
                card.EndDragEvent.AddListener(EndDrag);
                card.name = $"Card_{cardIndex.ToString()}";
                card.Initialize(_cardCanvas);
                cardIndex++;
            });
        }

        private void Update()
        {
            HandlePlayerInput();
            MoveCardIfSelected();
        }

        private void MoveCardIfSelected()
        {
            if (_selectedCard == null) return;
            if (_isCrossing) return;

            float selectX = _selectedCard.transform.position.x;
            for (int i = 0; i < cards.Count; i++)
            {
                //위치가 더 오른쪽인데 슬롯은 더 작거나, 왼쪽인데 슬롯이 더 크다면 교체
                if (selectX > cards[i].transform.position.x)
                {
                    if (_selectedCard.SlotIndex < cards[i].SlotIndex)
                    {
                        Swap(i);
                        break;
                    }
                }
                else if (selectX < cards[i].transform.position.x)
                {
                    if (_selectedCard.SlotIndex > cards[i].SlotIndex)
                    {
                        Swap(i);
                        break;
                    }
                }
            }
        }

        private void Swap(int index)
        {
            _isCrossing = true;
            Transform focusedParent = _selectedCard.transform.parent;
            Transform crossedParent = cards[index].transform.parent;

            //exchange slot!
            cards[index].transform.SetParent(focusedParent);
            cards[index].transform.localPosition = cards[index].selected ? new Vector3(0, cards[index].selectionOffset) : Vector3.zero;
            _selectedCard.transform.SetParent(crossedParent);

            _isCrossing = false;

        }

        private void HandlePlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                if (_hoveredCard != null)
                {
                    cards.Remove(_hoveredCard);
                    Destroy(_hoveredCard.transform.parent.gameObject); //슬롯 파괴
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                foreach (Card card in cards)
                {
                    card.DeSelect();
                }
            }
        }

        private void CardPointerEnter(Card card)
        {
            _hoveredCard = card;
        }

        private void CardPointerExit(Card card)
        {
            _hoveredCard = null;
        }

        private void BeginDrag(Card card)
        {
            _selectedCard = card;
        }

        private void EndDrag(Card card)
        {
            if (_selectedCard == null) return;

            Vector3 destination =
                _selectedCard.selected ? new Vector3(0, _selectedCard.selectionOffset) : Vector3.zero;
            _selectedCard.transform.DOLocalMove(destination, 0); //나중에 트윈을 위해 만들어둔다.
            _selectedCard = null;

        }

    }
}

