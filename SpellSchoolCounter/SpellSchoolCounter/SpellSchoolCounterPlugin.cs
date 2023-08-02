using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace SpellSchoolCounter
{
    public class SpellSchoolCounterPlugin : IPlugin
    {
        private SchoolCountWidget _widget;

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
            _widget = new SchoolCountWidget();
			
            Core.OverlayCanvas.Children.Add(_widget);

            SpellSchoolCounter counter = new SpellSchoolCounter(_widget);

            GameEvents.OnGameStart.Add(counter.GameStart);
            GameEvents.OnInMenu.Add(counter.InMenu);
            GameEvents.OnPlayerPlay.Add(counter.OnPlayerPlay);
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
            get { return new Version(1,0,1); }
        }
    }
}