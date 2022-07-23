using System.Collections.Generic;
using System.Diagnostics;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace SpellSchoolCounter
{
    public class SpellSchoolCounter
    {
        private SchoolCountWidget _cardListWidget = null;
        
        private List<SpellSchool> _schoolsPlayed = new List<SpellSchool>();
        private List<Card> _playedList = new List<Card>();

        public SpellSchoolCounter(SchoolCountWidget playerList)
        {

            _cardListWidget = playerList;

            // Hide in menu, if necessary
            if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
            {
                _cardListWidget.Hide();
            }
				
        }

        // Reset on when a new game starts
        internal void GameStart()
        {
            _schoolsPlayed = new List<SpellSchool>();
            _playedList = new List<Card>();
            _cardListWidget.Update(_playedList);
        }

        internal void OnPlayerPlay(Card card)
        {
            Debug.WriteLine("______________________________________________________________________________________________");
            Debug.WriteLine(card.LocalizedName);
            Debug.WriteLine(card.SpellSchool);
            Debug.WriteLine("______________________________________________________________________________________________");


            if (card.SpellSchool != SpellSchool.NONE && !_schoolsPlayed.Contains(card.SpellSchool))
            {
                _schoolsPlayed.Add(card.SpellSchool);
                _playedList.Add(card);
                _cardListWidget.Update(_playedList);
            }
            
            Debug.WriteLine("______________________________________________________________________________________________");
            Debug.WriteLine("List lengths");
            Debug.WriteLine(_schoolsPlayed.Count);
            Debug.WriteLine(_playedList.Count);
            Debug.WriteLine("______________________________________________________________________________________________");
        }

        // Need to handle hiding the element when in the game menu
        internal void InMenu()
        {
            if (Config.Instance.HideInMenu)
            {
                _cardListWidget.Hide();
            }
        }

        // Update the card list on player's turn
        internal void TurnStart(ActivePlayer player)
        {

            _cardListWidget.Show();
        }
		
    }
}