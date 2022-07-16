using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace SpellSchoolCounter
{
    public class SpellSchoolCounterPlugin : IPlugin
    {
        private SchoolCountWidget _playerList;
        private SchoolCountWidget _opponentList;

        public string Author
        {
            get { return "Slicedbread"; }
        }

        public string ButtonText
        {
            get { return "Settings"; }
        }

        public string Description
        {
            get { return "Counts number of different spell schools you've played for cards like multicaster"; }
        }

        public MenuItem MenuItem
        {
            get { return null; }
        }

        public string Name
        {
            get { return "Spell School Counter"; }
        }

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _playerList = new SchoolCountWidget(Location.Player);
            _opponentList = new SchoolCountWidget(Location.Opponent);
			
            Core.OverlayCanvas.Children.Add(_playerList);
            Core.OverlayCanvas.Children.Add(_opponentList);

            SpellSchoolCounter curvy = new SpellSchoolCounter(_playerList, _opponentList);


            GameEvents.OnGameStart.Add(curvy.GameStart);
            GameEvents.OnInMenu.Add(curvy.InMenu);
            GameEvents.OnTurnStart.Add(curvy.TurnStart);
            GameEvents.OnPlayerPlay.Add(curvy.OnPlayerPlay);
            GameEvents.OnOpponentPlay.Add(curvy.OnOpponentPlay);


        }

        public void OnUnload()
        {
            Core.OverlayCanvas.Children.Remove(_playerList);
            Core.OverlayCanvas.Children.Remove(_opponentList);
        }

        public void OnUpdate()
        {
        }

        public Version Version
        {
            get { return new Version(1,0,0); }
        }
    }
}