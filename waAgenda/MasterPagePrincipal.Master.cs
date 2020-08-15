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
    public partial class MasterPagePrincipal : MasterPage
    {
        #region Page Methods

        protected void Page_Load ( object sender, EventArgs e )
        {
            // Checar se tem o cookie de login do usuário.
            if ( Request.Cookies [ "login" ] == null )
                // Se o cookie nao existir, mandar o usuário para página de login.
                Response.Redirect ( "~/login.aspx" );
        }

        #endregion
    }
}