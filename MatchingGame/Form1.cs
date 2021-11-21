using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        private Label _first = null;
        private Label _second = null;

        private Random _random = new Random();

        private List<string> _icons = new List<string>()
        {
            "🚶‍♀️" , "🚶‍♀️" , "😍" , "😍" , "🍳" , "🍳" , "😀" ,"😀",
            "🤯" , "🤯" , "🍽" , "🍽" , "🏆","🏆" , "🍔" , "🍔"

        };

        public Form1()
        {
            InitializeComponent();
            AssignIcons();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            _first.ForeColor = _first.BackColor;
            _second.ForeColor = _second.BackColor;
            _first = null;
            _second = null;
        }
        private void label_Click(object sender, EventArgs e)
        {

            var clickedLabel = sender as Label;
            if (clickedLabel != null) 
            {
                if(clickedLabel.ForeColor == Color.Black)
                    return;
                if (_first == null)
                {
                    _first = clickedLabel;
                    _first.ForeColor = Color.Black;

                    return;
                }

                _second = clickedLabel;
                _second.ForeColor = Color.Black;

                CheckWin();

                if (_first.Text == _second.Text)
                {
                    _first = null;
                    _second = null;
                    return;
                }
                timer1.Start();
            }

        }
        public void AssignIcons()
        {
            foreach (Control control in Controls)
            {
                var iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNum = _random.Next(_icons.Count);
                    iconLabel.Text = _icons[randomNum];

                    iconLabel.ForeColor = iconLabel.BackColor;
                    _icons.RemoveAt(randomNum);
                }
            }
        }

        public void CheckWin()
        {
            foreach (Control control in Controls)
            {
                var iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("You Win🏆🏆🏆🏆");
            Close();
        }

    }
}
