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
    public partial class frm_cadastrar_emprestimo : Form
    {
        private NpgsqlConnection conn; //Estabelecer conexao
        private NpgsqlCommand command;
        private NpgsqlCommand command2; //Define comandos
        private NpgsqlDataReader result; //Guarda Consulta
        private NpgsqlDataReader result2;

        public frm_cadastrar_emprestimo()
        {
            InitializeComponent();
            listUsuarios();
            listLivros();
        }


        public void listUsuarios()
        {
            //Conectando ao banco
            connectionTest();

            try
            {
                //Definindo o comando para atualização
                command = new NpgsqlCommand("SELECT * FROM tb_usuarios;", conn);

                result = command.ExecuteReader();

                while (result.Read())
                {
                    string cpf = (string)result["cpf"].ToString();
                    cb_cpf.Items.Add(cpf);
                }

                //Fechando a conexao
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }
        }


        public void listLivros()
        {
            //Conectando ao banco
            connectionTest();

            try
            {

                //Definindo o comando para atualização
                command = new NpgsqlCommand("SELECT * FROM tb_livros;", conn);

                result = command.ExecuteReader();

                while (result.Read())
                {
                    string name = (string)result["isbn"].ToString();
                    cb_isbn.Items.Add(name);
                }


                //Fechando a conexao
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }

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

        private void cb_cpf_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Conectando ao banco
            connectionTest();

            try
            {
                //Definindo o comando para atualização
                command = new NpgsqlCommand("SELECT * FROM tb_usuarios where cpf = " + "'" + cb_cpf.Text + "';", conn);

                result = command.ExecuteReader();

                while (result.Read())
                {
                    string nome = (string)result["nome"].ToString();
                    string email = (string)result["email"].ToString();
                    txt_nome.Text = nome;
                    txt_email.Text = email;
                }

                //Fechando a conexao
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }

        }

        private void cb_isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Conectando ao banco
            connectionTest();

            try
            {
                //Definindo o comando para atualização
                command = new NpgsqlCommand("SELECT * FROM tb_livros where isbn = " + "'" + cb_isbn.Text + "';", conn);

                result = command.ExecuteReader();

                while (result.Read())
                {
                    string titulo = (string)result["titulo"].ToString();
                    string autor = (string)result["autor"].ToString();
                    txt_titulo.Text = titulo;
                    txt_autor.Text = autor;
                }

                //Fechando a conexao
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Conectando ao banco
            connectionTest();

            DateTime data_emprestimo = DateTime.Now;
            DateTime data_devolucao = DateTime.Now.AddDays(7);

            try
            {

                //Definindo o comando para atualização
                command = new NpgsqlCommand("INSERT INTO tb_emprestimos (" +
                    "cpf," +
                    "isbn," +
                    "data_emprestimo," +
                    "data_devolucao)" +
                    "VALUES ('"
                    + cb_cpf.Text + "','"
                    + cb_isbn.Text + "','"
                    + data_emprestimo + "','"
                    + data_devolucao + "');", conn);

                //Executando o comando
                command.ExecuteReader();
                MessageBox.Show("Empréstimo cadastrado com sucesso!");

                //Limpando os campos aposa inclusao
                cb_cpf.Text = "";
                txt_nome.Text = "";
                txt_email.Text = "";
                cb_isbn.Text = "";
                txt_titulo.Text = "";
                txt_autor.Text = "";

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
