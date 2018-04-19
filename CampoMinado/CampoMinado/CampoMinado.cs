using System;
using System.Windows.Forms;

namespace CampoMinado
{
    public partial class telaInicial : Form
    {
        public event EventHandler Tick;
        private Game game;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new telaInicial());
        }

        public telaInicial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            game = new Game(this.panel1,10,10,10);
            game.Tick += new EventHandler(GameTick);
            game.start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            lblTempo.Text = game.Time.ToString();
        }
    }
}
