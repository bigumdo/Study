using System.Collections.Generic;
using UnityEngine;

namespace Gondr
{
    public class HorizontalCardHolder : MonoBehaviour
    {
        [SerializeField] private Card _selectedCard;
        [SerializeReference] private Card _hoveredCard;

        [SerializeField] private GameObject _slotPrefab;
        private RectTransform _rectTrm;

        [Header("Spawn Settings")]
        [SerializeField] private int _cardToSpawn = 7;
        public List<Card> cards;


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

