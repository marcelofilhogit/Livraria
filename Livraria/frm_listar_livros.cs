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
    public partial class frm_listar_livros : Form
    {
        private NpgsqlConnection conn; //Estabelecer conexao
        private NpgsqlCommand command; //Define comandos
        private NpgsqlDataReader result; //Guarda Consulta

        public frm_listar_livros()
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

        private void btn_listar_Click(object sender, EventArgs e)
        {
            try
            {
                //Conectando ao banco
                connectionTest();

                //Chama o select
                SelectRecords();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Informação de Erro: " + ex);
            }
        }

        private void SelectRecords()
        {
            //Conectando ao banco
            connectionTest();

            //Limpandos todas as linhas do dataGrid
            dataGridView1.Rows.Clear();

            try
            {
                //Definindo o comando a ser executado
                command = new NpgsqlCommand("SELECT * FROM tb_livros order by id", conn);

                //Executando o comando e guardando o retorno em result 
                result = command.ExecuteReader();

                //Atualizar os dados encontrados no dataGrid
                while (result.Read()) //Estrutura de repetição para percorer todos os registros
                {               
                    Console.WriteLine(result.GetValue(0));

                    //Adicionar os registross no dataGrid
                    dataGridView1.Rows.Add(new object[] {
                        result.GetValue(0),
                        result.GetValue(1),
                        result.GetValue(2),
                        result.GetValue(3),
                        result.GetValue(4),
                        result.GetValue(5),
                        result.GetValue(6),
                        result.GetValue(7),
                        result.GetValue(8)
                    });
                }

                //Fechando a conexao
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            //Conectando ao banco
            connectionTest();

            try
            {
                //Definindo o comando para atualização
                command = new NpgsqlCommand("UPDATE tb_livros SET " +
                    "isbn = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "', " +
                    "titulo = '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "', " +
                    "autor = '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "', " +
                    "lingua = '" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "', " +
                    "edicao = '" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "', " +
                    "cobertura = '" + dataGridView1.CurrentRow.Cells[6].Value.ToString() + "', " +
                    "paginas = '" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "', " +
                    "marca = '" + dataGridView1.CurrentRow.Cells[8].Value.ToString() +
                    "' WHERE id = " + dataGridView1.CurrentRow.Cells[0].Value.ToString(), conn);

                //Executando o comando
                command.ExecuteReader();
                MessageBox.Show("Livro atualizado com sucesso!");

                //Chama o select
                SelectRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            //Conectar ao banco
            connectionTest();

            try
            {
                //Definindo o comando para exclusão do registro
                command = new NpgsqlCommand("DELETE FROM tb_livros WHERE id = "
                    + dataGridView1.CurrentRow.Cells[0].Value.ToString(), conn);

                //Executando o comando
                command.ExecuteReader();
                MessageBox.Show("Livro excluido com sucesso!");

                //Chama o select
                SelectRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado: " + ex);
            }

        }
    }
}
