using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace SpellSchoolCounter
{

    public partial class SchoolCountWidget2
    {

        public SchoolCountWidget2()
        {
            InitializeComponent();
            Debug.WriteLine("________________________________________ini component____________________________________________________");
        }

        public void Update(ObservableCollection<Card> cards)
        {
            // hide if card list is empty
            this.Visibility = cards.Count <= 0 ? Visibility.Hidden : Visibility.Visible;
            this.ItemsSource = cards;
            Debug.WriteLine("______________________________________________________________________________________________");
            Debug.WriteLine("_________________________________________Update_____________________________________________________");
            Debug.WriteLine(cards.Count);
            Debug.WriteLine("______________________________________________________________________________________________");
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            Canvas.SetTop(this, Core.OverlayWindow.Height * 5 / 100);
            Canvas.SetRight(this, Core.OverlayWindow.Width * 20 / 100);
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}