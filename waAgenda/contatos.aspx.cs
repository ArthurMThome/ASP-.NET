/// Arthur M. Thomé
/// 15 AUG 2020
/// Arthur Martins Thomé - Curso ASP .NET ( Udemy ).

#region Statements

using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;

#endregion

namespace waAgenda
{
    public partial class contatos : Page
    {
        #region Page Methods

        protected void Page_Load ( object sender, EventArgs e )
        {

        }

        #endregion

        #region Button Inserir

        /// <summary>
        /// Função chamada ao clicar no botão Inserir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInserir_Click ( object sender, EventArgs e )
        {
            try
            {
                if ( !string.IsNullOrEmpty ( tbNome.Text ) && !string.IsNullOrEmpty ( tbEmail.Text ) && !string.IsNullOrEmpty ( tbTelefone.Text ) )
                {
                    // Capturar string de conexão.
                    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration ( "/MyWebSiteRoot" );
                    System.Configuration.ConnectionStringSettings connString;
                    connString = rootWebConfig.ConnectionStrings.ConnectionStrings [ "ConnectionString" ];

                    // Cria um objeto de conexão.
                    SqlConnection _conection = new SqlConnection ( );
                    // Definir qual string de conexão ele vai utilizar.
                    _conection.ConnectionString = connString.ToString ( );
                    // Cria um objeto Command.
                    SqlCommand _command = new SqlCommand ( );
                    // Com qual conexão o Command vai executar os comando no banco.
                    _command.Connection = _conection;
                    // Definir o comando.
                    _command.CommandText = "INSERT INTO contato ( nome, email, telefone ) VALUES ( @nome, @email, @telefone )";
                    // Adicionar os parametros.
                    _command.Parameters.AddWithValue ( "nome", tbNome.Text );
                    _command.Parameters.AddWithValue ( "email", tbEmail.Text );
                    _command.Parameters.AddWithValue ( "telefone", tbTelefone.Text );
                    // Abrir conexão com o bando.
                    _conection.Open ( );
                    // Executar o CommandText.
                    _command.ExecuteNonQuery ( );
                    // Fechar a conexão.
                    _conection.Close ( );

                    gvListContatos.DataBind ( );

                    tbNome.Text = "";
                    tbEmail.Text = "";
                    tbTelefone.Text = "";
                }
                else
                {
                    throw new Exception ( "Campo(s) em branco" );
                }
            }
            catch ( Exception ex )
            {
                Response.Write ( "<script> alert ( '" + ex.Message + "' ); </script>" );
            }
        }

        #endregion
    }
}