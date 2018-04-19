using System;
using System.Drawing;
using System.Windows.Forms;

namespace CampoMinado
{
    public class Sqm
    {
        public event EventHandler Explode;

        private Button _button;
        private bool _desmontado = false;
        private Game _game;
        private bool _minado = false;
        private bool _aberto = false;
        private int _x;
        private int _y;
        private bool _gameOver = false;

        public Sqm(Game game, int x, int y)
        {
            _game = game;
            _x = x;
            _y = y;
            _button = new Button();
            Button.Text = "";

            int w = _game.Panel.Width / _game.largura;
            int h = _game.Panel.Height / _game.altura;

            _button.Width = w + 1;
            _button.Height = h + 1;
            _button.Left = w * X;
            _button.Top = h * Y;
            _button.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            _button.Click += new EventHandler(Click);

            _game.Panel.Controls.Add(Button);
        }

        private void Click(object sender, System.EventArgs e)
        {
            if (!Desmontado)
            {
                if (Minado)
                {
                    Button.BackColor = Color.Red;
                    _gameOver = false;

                }
            }
        }

        protected void OnExplode()
        {
            if (Explode != null)
            {
                Explode(this, new EventArgs());
            }
        }

        public void RemoveEvents()
        {
            _button.Click -= new EventHandler(Click);
        }

        public Button Button
        {
            get { return (this._button); }
        }

        public int X
        {
            get { return (this._x); }
        }

        public int Y
        {
            get { return (this._y); }
        }

        public bool Desmontado
        {
            get { return (this._desmontado); }
        }

        public bool Minado
        {
            get { return (this._minado); }
            set { this._minado = value; }
        }

        public bool GameOver
        {
            get { return (this._gameOver); }
            set { this._gameOver = value; }
        }
    }
}
