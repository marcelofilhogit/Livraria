using Npgsql;
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
    public partial class frm_cadastrar_livro : Form
    {
        private NpgsqlConnection conn; //Estabelecer conexao
        private NpgsqlCommand command; //Define comandos
        private NpgsqlDataReader result; //Guarda Consulta

        public frm_cadastrar_livro()
        {
            InitializeComponent();
        }

        private void connectionTest()
        {
            //Criar e definir os parametros de conexao
            try
            {
                //33Mm2907
                conn = new NpgsqlConnection("Server=127.0.0.1; User Id=postgres; Password=Marcel0F1lh0; Database=db_livraria");

                //Abrindo conexao
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Informação de Erro: " + ex);
            }
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Conectando ao banco
            connectionTest();

            try
            {
                //Definindo o comando para atualização
                command = new NpgsqlCommand("INSERT INTO tb_livros (" +
                    "isbn," +
                    "titulo," +
                    "autor," +
                    "lingua," +
                    "edicao," +
                    "cobertura," +
                    "paginas," +
                    "marca) " +
                    "VALUES ('"
                    + txt_isbn.Text + "','"
                    + txt_titulo.Text + "','"
                    + txt_autor.Text + "','"
                    + txt_lingua.Text + "','"
                    + txt_edicao.Text + "','"
                    + txt_cobertura.Text + "','"
                    + txt_paginas.Text + "','"
                    + txt_marca.Text 
                    + "');", conn);

                //Executando o comando
                command.ExecuteReader();
                MessageBox.Show("Livro cadastrado com sucesso!");

                //Limpando os campos aposa inclusao
                txt_isbn.Text = "";
                txt_titulo.Text = "";
                txt_autor.Text = "";
                txt_lingua.Text = "";
                txt_edicao.Text = "";
                txt_cobertura.Text = "";
                txt_paginas.Text = "";
                txt_marca.Text = "";

                //Fechando a conexao
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }

        }
    }
}
