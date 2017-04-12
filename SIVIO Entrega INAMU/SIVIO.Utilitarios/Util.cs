using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIVIO.Utilitarios
{
    public class Util
    {

        /// <summary>
        /// Envia un correo usando el servidor Exchange del INAMU
        /// </summary>
        /// <param name="texto">Contenido del mensaje (puede incluir html)</param>
        /// <param name="destinatarios">destinatarios</param>
        /// <param name="titulo">titulos</param>
        /// <param name="adjuntos">Lista de objetos de tipo mail Attachment que contienen los archivos a adjuntar</param>
        public void sendemail(string texto, List<string> destinatarios, string titulo, List<Attachment> adjuntos = null)
        {

            bool resultado = true;
            String userName = ConfigurationManager.AppSettings["usuarioCorreo"].ToString();
            String password = ConfigurationManager.AppSettings["passwordCorreo"].ToString();
            MailMessage msg = new MailMessage();
            if (destinatarios != null)
            {
                foreach (var destinatario in destinatarios)
                { msg.To.Add(new MailAddress(destinatario)); }

                //añadir esta linea para pruebas
                //msg.To.Add(new MailAddress("pruebacorreojon@inamu.go.cr"));
            }

            if (adjuntos != null)
            {
                for (int i = 0; i < adjuntos.Count; i++)
                {
                    msg.Attachments.Add(adjuntos[i]);
                }
            }

            msg.From = new MailAddress(userName);
            msg.Subject = titulo;
            msg.Body = texto;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = ConfigurationManager.AppSettings["HostSMTP"].ToString();
            client.Credentials = new System.Net.NetworkCredential(userName, password);
            client.Port = int.Parse(ConfigurationManager.AppSettings["PuertoSMTP"].ToString());
            client.EnableSsl = true;


            try
            {
                client.Send(msg);
                client.Dispose();
            }

            catch (Exception ex)
            {
                try
                {
                    client.EnableSsl = false;
                    client.Send(msg);

                }
                catch
                {
                    client.Dispose();
                    resultado = false;
                }

            }
            finally
            {
                msg.Attachments.Dispose();
            };
        }

        /// <summary>
        /// Toma un objeto de tipo DataTable y la convierte automaticamente en un arreglo JSON
        /// </summary>
        /// <param name="table">tabla</param>
        /// <returns>Lista de objetos JSON</returns>
        public string ConvertirDataTableJSON(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        /// <summary>
        /// Consulta en el AD del Inamu si una persona existe y retorna toda su información en formato JSON
        /// </summary>
        /// <param name="usuarioRed">Usuario de Red</param>
        /// <returns>Tabla con los resultados que coincidan con la búsqueda</returns>
        public string ExportarAdsjon(string usuarioRed)
        {
            DataTable resultsTable = new DataTable();
            resultsTable.Columns.Add("UserID");
            resultsTable.Columns.Add("EmailID");
            resultsTable.Columns.Add("department");
            resultsTable.Columns.Add("displayName");
            resultsTable.Columns.Add("givenName");
            resultsTable.Columns.Add("sn");
            resultsTable.Columns.Add("physicalDeliveryOfficeName");
            resultsTable.Columns.Add("company");
            try
            {

                DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://srv-dc02/DC=inamu,DC=local");
                DirectorySearcher search = new DirectorySearcher(myLdapConnection) { Filter = (string.Format("(&(objectcategory=user)({0}={1}))", "cn", usuarioRed)) };
                search.CacheResults = true;
                SearchResultCollection allResults = search.FindAll();

                foreach (SearchResult searchResult in allResults)
                {

                    DataRow dr = resultsTable.NewRow();
                    dr["UserID"] = searchResult.Properties["sAMAccountName"][0].ToString();
                    if (searchResult.Properties["mail"].Count > 0)
                    {
                        dr["EmailID"] = searchResult.Properties["mail"][0].ToString();
                    }
                    else
                    {
                        dr["EmailID"] = "";
                    }
                    if (searchResult.Properties["department"].Count > 0)
                    {
                        dr["department"] = searchResult.Properties["department"][0].ToString();
                    }
                    else
                    {
                        dr["department"] = "";
                    }
                    if (searchResult.Properties["displayName"].Count > 0)
                    {
                        dr["displayName"] = searchResult.Properties["displayName"][0].ToString();
                    }
                    else
                    {
                        dr["displayName"] = "";
                    }
                    if (searchResult.Properties["givenName"].Count > 0)
                    {
                        dr["givenName"] = searchResult.Properties["givenName"][0].ToString();
                    }
                    else
                    {
                        dr["givenName"] = "";
                    }
                    if (searchResult.Properties["sn"].Count > 0)
                    {
                        dr["sn"] = searchResult.Properties["sn"][0].ToString();
                    }
                    else
                    {
                        dr["sn"] = "";
                    }
                    if (searchResult.Properties["physicalDeliveryOfficeName"].Count > 0)
                    {
                        dr["physicalDeliveryOfficeName"] = searchResult.Properties["physicalDeliveryOfficeName"][0].ToString();
                    }
                    else
                    {
                        dr["physicalDeliveryOfficeName"] = "";
                    }
                    if (searchResult.Properties["company"].Count > 0)
                    {
                        dr["company"] = searchResult.Properties["company"][0].ToString();
                    }
                    else
                    {
                        dr["company"] = "";
                    }
                    resultsTable.Rows.Add(dr);


                }
                return ConvertirDataTableJSON(resultsTable);


            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Comprueba en el AD del Inamu si el usuario y la contraseña son correctos
        /// </summary>
        /// <param name="srvr">(Del archivo de configuracion) Servidor LDAP</param>
        /// <param name="usr">usuario de red</param>
        /// <param name="pwd">clave</param>
        /// <returns>Resultado booleano</returns>
        public static bool AutenticadoAd(string srvr, string usr, string pwd)
        {

            try
            {

                DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd, AuthenticationTypes.Secure);
                object nativeObject = entry.NativeObject;

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Genera a partir del algoritmo SHA321 una contraseña segura con base en la información solicitada
        /// Nótese que solamente almacenamos un hash por lo que el resultado es un Array de bytes
        /// </summary>
        /// <param name="usuario">Correo electrónico de la persona que será su ID de usuario</param>
        /// <param name="clave">Contraseña en texto plano</param>
        /// <param name="tipoConversion">
        /// Tipo 2 = contraseña + fragmentos aleatorios + usuario
        /// Tipo 1 = contraseña + usuario
        /// Tipo 0 = contraseña solamente
        /// NOTA: Por defecto usamos tipo 2 para todas las contraseñas
        /// </param>
        /// <param name="salt1">Uid aleatorio convertido en Byte Array</param>
        /// <param name="salt2">Uid aleatorio convertido en Byte Array</param>
        /// <returns>Array de bytes conteniendo el hash</returns>
        public static byte[] GenerarClave(string usuario, string clave,
        int tipoConversion, byte[] salt1, byte[] salt2)
        {
            string tmpPassword = null;

            switch (tipoConversion)
            {
                case 2: // password + lots of salt
                    tmpPassword = Convert.ToBase64String(salt1)
                     + Convert.ToBase64String(salt2)
                     + usuario.ToLower() + clave;
                    break;
                case 1: // user name as salt
                    tmpPassword = usuario.ToLower() + clave;
                    break;
                case 0: // no salt
                default:
                    tmpPassword = clave;
                    break;
            }

            //Convert the password string into an Array of bytes.
            UTF8Encoding textConverter = new UTF8Encoding();
            byte[] passBytes = textConverter.GetBytes(tmpPassword);

            //Return the encrypted bytes
            if (tipoConversion == 2)
                return new SHA384Managed().ComputeHash(passBytes);
            else
                return new MD5CryptoServiceProvider().ComputeHash(passBytes);
        }



    }
}
