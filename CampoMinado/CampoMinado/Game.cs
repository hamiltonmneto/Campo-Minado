using System;
using System.Windows.Forms;
using System.Drawing;

namespace CampoMinado
{
    public class Game
    {
        private int _largura;
        private int _altura;
        private int _minas;
        private Panel _panel;
        private Sqm[,] _Sqms;

        public Game(Panel panel, int largura, int altura, int minas)
        {
            _panel = panel;
            _largura = largura;
            _altura = altura;
            _minas = minas;
        }

        public void start()
        {
            Panel.Controls.Clear();
            _Sqms = new Sqm[largura, altura];
            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < largura; y++)
                {
                    Sqm s = new Sqm(this, x, y);
                    s.Explode += new EventHandler(Explode);
                    _Sqms[x, y] = s;
                }
            }

            int b = 0;
            Random r = new Random();
            while (b < Minas)
            {
                int x = r.Next(altura);
                int y = r.Next(largura);

                Sqm s = _Sqms[x, y];
                if (!s.Minado)
                {
                    s.Minado = true;
                    b++;
                }
            }
        }

        private void Explode(object sender, EventArgs e)
        {

            foreach (Sqm s in _Sqms)
            {
                s.RemoveEvents();
                if (s.Minado)
                {
                    s.Button.Text = "*";
                    s.Button.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    s.Button.ForeColor = Color.Black;
                }

            }
        }

        public EventHandler Tick { get; internal set; }
        public object Time { get; internal set; }

        public Panel Panel
        {
            get { return (this._panel); }
        }

        public int largura
        {
            get { return (this._largura); }
        }

        public int altura
        {
            get { return (this._altura); }
        }

        public int Minas
        {
            get { return (this._minas); }
        }
    }
}
