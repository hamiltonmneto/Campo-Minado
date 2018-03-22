using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CampoMinado
{
    class Game
    {
        private int _largura;
        private int _altura;
        private int _minas;
        private Panel _panel;

        public Game(Panel panel, int largura, int altura, int minas)
        {
            _panel = panel;
            _largura = largura;
            _altura = altura;
            _minas = minas;
        }

        public void start()
        {
            
        }

        public EventHandler Tick { get; internal set; }
        public object Time { get; internal set; }
    }
}
