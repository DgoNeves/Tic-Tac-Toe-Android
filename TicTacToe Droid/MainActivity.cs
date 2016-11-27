using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TicTacToe_Droid.Helpers;

namespace TicTacToe_Droid
{
    [Activity(Label = "TicTacToe_Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        #region variables

        protected ImageButton b1;
        protected ImageButton b2;
        protected ImageButton b3;
        protected ImageButton b4;
        protected ImageButton b5;
        protected ImageButton b6;
        protected ImageButton b7;
        protected ImageButton b8;
        protected ImageButton b9;

        public PlayerAiExtreme computer = new PlayerAiExtreme();
        public bool?[] table = new bool?[9];

        #endregion variables

        protected List<ImageButton> allButtons = new List<ImageButton>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            InitButtons();

            /*allButtons[T].Click += Button_Clicked;*/
        }

        /*Maybe the more correct Way*/

        private async void BtnClicked(object sender, EventArgs e)
        {
            var objImageButton = sender as ImageButton;

            objImageButton.SetImageResource(Resource.Drawable.Cross);
            var btnID = objImageButton.Id;
            ParseIdToBoard(btnID);

            GameFlow.ArtPaint(table, allButtons);

            if (GameFlow.DoesPlayerWins(table, true) || GameFlow.IsGameFinished(table))
            {
                GameFlow.ResetGame(table, allButtons);
            }

            ComputersTurn();

            if (GameFlow.DoesPlayerWins(table, false) || GameFlow.IsGameFinished(table))
            {
                GameFlow.ResetGame(table, allButtons);
            }

            GameFlow.ArtPaint(table, allButtons);
        }

        private void ParseIdToBoard(int btnID)
        {
            switch (btnID)
            {
                case Resource.Id.box1:
                    table[0] = true;
                    break;

                case Resource.Id.box2:
                    table[1] = true;
                    break;

                case Resource.Id.box3:
                    table[2] = true;
                    break;

                case Resource.Id.box4:
                    table[3] = true;
                    break;

                case Resource.Id.box5:
                    table[4] = true;
                    break;

                case Resource.Id.box6:
                    table[5] = true;
                    break;

                case Resource.Id.box7:
                    table[6] = true;
                    break;

                case Resource.Id.box8:
                    table[7] = true;
                    break;

                case Resource.Id.box9:
                    table[8] = true;
                    break;

                default:
                    break;
            }
        }

        private void ComputersTurn()
        {
            computer.Play(table, false);
        }

        private void InitButtons()
        {
            var id = 1;
            allButtons.Add(b1 = FindViewById<ImageButton>(Resource.Id.box1));
            allButtons.Add(b2 = FindViewById<ImageButton>(Resource.Id.box2));
            allButtons.Add(b3 = FindViewById<ImageButton>(Resource.Id.box3));
            allButtons.Add(b4 = FindViewById<ImageButton>(Resource.Id.box4));
            allButtons.Add(b5 = FindViewById<ImageButton>(Resource.Id.box5));
            allButtons.Add(b6 = FindViewById<ImageButton>(Resource.Id.box6));
            allButtons.Add(b7 = FindViewById<ImageButton>(Resource.Id.box7));
            allButtons.Add(b8 = FindViewById<ImageButton>(Resource.Id.box8));
            allButtons.Add(b9 = FindViewById<ImageButton>(Resource.Id.box9));

            foreach (var button in allButtons)
            {
                button.SetImageResource(Resource.Drawable.BlackHole);
                button.Click += BtnClicked;
                id++;
            }
        }
    }
}