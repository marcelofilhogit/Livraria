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
    public partial class frm_cadastrar_usuario : Form
    {
        private NpgsqlConnection conn; //Estabelecer conexao
        private NpgsqlCommand command; //Define comandos
        private NpgsqlDataReader result; //Guarda Consulta

        public frm_cadastrar_usuario()
        {
            InitializeComponent();

            //Conectando ao banco
            connectionTest();

            try
            {

                //Definindo o comando para atualização
                command = new NpgsqlCommand("SELECT * FROM tb_estados;", conn);

                result = command.ExecuteReader();

                while (result.Read())
                {
                    string name = (string) result["sigla"].ToString();
                    cb_estado.Items.Add(name);
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

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Conectando ao banco
            connectionTest();

            try
            {

                string sexo = "";

                if (rb_feminino.Checked)
                {
                    sexo = "F";
                }

                if (rb_masculino.Checked)
                {
                    sexo = "M";
                }

                //Definindo o comando para atualização
                command = new NpgsqlCommand("INSERT INTO tb_usuarios (" +
                    "cpf," +
                    "nome," +
                    "sexo," +
                    "data_nascimento," +
                    "email," +
                    "rua," +
                    "bairro," +
                    "numero," +
                    "cidade," +
                    "estado) " +
                    "VALUES ('"
                    + txt_cpf.Text + "','" 
                    + txt_nome.Text + "','"
                    + sexo + "','"
                    + txt_data_nascimento.Text + "','"
                    + txt_email.Text + "','"
                    + txt_rua.Text + "','"
                    + txt_bairro.Text + "','"
                    + Convert.ToInt32(txt_numero.Text) + "','"
                    + txt_cidade.Text + "','"
                    + cb_estado.Text
                    + "');", conn);

                //Executando o comando
                command.ExecuteReader();
                MessageBox.Show("Usuário cadastrado com sucesso!");

                //Limpando os campos aposa inclusao
                txt_cpf.Text = "";
                txt_nome.Text = "";
                txt_data_nascimento.Text = "";
                txt_email.Text = "";
                txt_rua.Text = "";
                txt_bairro.Text = "";
                txt_numero.Text = "";
                txt_cidade.Text = "";
                cb_estado.Text = "";

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
