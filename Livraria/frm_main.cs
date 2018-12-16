using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_cadastrar_usuario frm = new frm_cadastrar_usuario();
            frm.Show();
        }

        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_cadastrar_livro frm = new frm_cadastrar_livro();
            frm.Show();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_listar_livros frm = new frm_listar_livros();
            frm.Show();
        }

        private void emprestimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_cadastrar_emprestimo frm = new frm_cadastrar_emprestimo();
            frm.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_listar_usuarios frm = new frm_listar_usuarios();
            frm.Show();
        }

        private void emprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_listar_emprestimos frm = new frm_listar_emprestimos();
            frm.Show();
        }
    }
}
