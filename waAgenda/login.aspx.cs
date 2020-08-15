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
    public partial class Login : Page
    {
        #region Page Methods

        protected void Page_Load ( object sender, EventArgs e )
        {

        }

        #endregion

        #region Button Logar

        /// <summary>
        /// Função chamada ao clicar no botão logar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogar_Click ( object sender, EventArgs e )
        {
            // Pegar senha e e-mail dos TextBox.
            String _email = tbEmail.Text;
            String _senha = tbSenha.Text;

            // Checar se o campo E-mail não está vazio.
            if ( string.IsNullOrEmpty ( _email ) )
            {
                lbMessageError.Text = "Preencha o campo 'E-mail'.";
                return;
            }
            // Checar se o campo Senha não está vazio.
            else if ( string.IsNullOrEmpty ( _senha ) )
            {
                lbMessageError.Text = "Preencha o campo 'Senha'.";
                return;
            }

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
            _command.CommandText = "SELECT * FROM usuario WHERE email = @email AND senha = @senha";
            // Adicionar os parametros.
            _command.Parameters.AddWithValue ( "email", _email );
            _command.Parameters.AddWithValue ( "senha", _senha );
            // Abrir conexão com o bando.
            _conection.Open ( );
            // Executar o comando e salvar o(s) resultado(s) em uma variável. 
            SqlDataReader _register = _command.ExecuteReader ( );
            // Checar se a variável tem uma ou mais linhas.
            // Nesse caso, se a variável tiver pelo menos uma linha, quer dizer que o e-mail e senha estão
            // No banco de dados e o usuário pode realizar o login.
            if ( _register.HasRows )
            {
                // Criar Cookie e armazenar o e-mail do usuáiro.
                HttpCookie _login = new HttpCookie ( "login", tbEmail.Text );
                // Armazenar o cookie.
                Response.Cookies.Add ( _login );
                // Direcionar para a página principal.
                Response.Redirect ( "~/index.aspx" );
            }
            else
            {
                // E-mail ou senha estão errados.
                lbMessageError.Text = "E-mail ou senha incorretos.";
            }
            // Fechar a conexão.
            _conection.Close ( );
        }

        #endregion
    }
}