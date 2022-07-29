using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace SpellSchoolCounter
{
    public class SpellSchoolCounterPlugin : IPlugin
    {
        private SchoolCountWidget2 _widget;

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
            _widget = new SchoolCountWidget2();
			
            Core.OverlayCanvas.Children.Add(_widget);

            SpellSchoolCounter curvy = new SpellSchoolCounter(_widget);

            GameEvents.OnGameStart.Add(curvy.GameStart);
            GameEvents.OnInMenu.Add(curvy.InMenu);
            GameEvents.OnTurnStart.Add(curvy.TurnStart);
            GameEvents.OnPlayerPlay.Add(curvy.OnPlayerPlay);
        }

        public void OnUnload()
        {
            Core.OverlayCanvas.Children.Remove(_widget);
        }

        public void OnUpdate()
        {
        }

        public Version Version
        {
            get { return new Version(0,4,3); }
        }
    }
}