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
        private RectTransform _rectTrm;

        [SerializeField] private Canvas _cardCanvas;

        [Header("Spawn Settings")]
        [SerializeField] private int _cardToSpawn = 7;
        public List<Card> cards;



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



        private void CardPointerEnter(Card card)
        {

        }

        private void CardPointerExit(Card card)
        {

        }

        private void BeginDrag(Card card)
        {

        }

        private void EndDrag(Card card)
        {

        }

    }
}

