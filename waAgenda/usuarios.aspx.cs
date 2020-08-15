/// Arthur M. Thomé
/// 14 AUG 2020
/// Arthur Martins Thomé - Curso ASP .NET ( Udemy ).

#region Statements

using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

#endregion

namespace waAgenda
{
    public partial class usuarios : Page
    {
        #region Page Methods

        protected void Page_Load ( object sender, EventArgs e )
        {

        }

        #endregion

        #region Events Data Base.

        /// <summary>
        /// Evento chamado após a ação de inserir ser realizada.
        /// </summary>
        /// <param name="sender">Próprio obj, no caso o DataSource.</param>
        /// <param name="e">Events.</param>
        protected void SqlDataSourceUsuarios_Inserted ( object sender, SqlDataSourceStatusEventArgs e )
        {
            CheckException ( e );
        }

        /// <summary>
        /// Evento chamado após a ação de atualizar ser realizada.
        /// </summary>
        /// <param name="sender">Próprio obj, no caso o DataSource.</param>
        /// <param name="e">Events.</param>
        protected void SqlDataSourceUsuarios_Updated ( object sender, SqlDataSourceStatusEventArgs e )
        {
            CheckException ( e );
        }

        #endregion

        private void CheckException ( SqlDataSourceStatusEventArgs e )
        {
            if ( e.Exception != null )
            {
                //lbMessage.Text = e.Exception.Message;
                //lbMessage.Text = "Campo 'email' ja existe ou existe algum campo em branco.";
                Response.Write ( "<script> alert ( 'Campo 'email' ja existe ou existe algum campo em branco.' ); </script>" );
                e.ExceptionHandled = true;
            }
        }
    }
}