using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;

using Socopec.Models;
using Socopec;

namespace Socopec.Controllers
{
    public class UtilisateurController : ApiController
    {
        // GET: api/Utilisateur
        public ArrayList Get()
        {
            UtilisateurPersistance up = new UtilisateurPersistance();
            return up.getUtilisateurs();
        }

        // GET: api/Utilisateur/toto
        public Utilisateur Get(string login)
        {
            UtilisateurPersistance up = new UtilisateurPersistance();
            Utilisateur u = up.getUtilisateur(login);
            return u;
        }

        // POST: api/Utilisateur
        public HttpResponseMessage Post([FromBody]Utilisateur value)
        {
            UtilisateurPersistance up = new UtilisateurPersistance();
            long id;
            id = up.saveUtilisateur(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Utilisateur/{0}", id));
            return response;
        }

        // PUT: api/Utilisateur/toto
        public HttpResponseMessage Put(string login, [FromBody]Utilisateur value)
        {
            UtilisateurPersistance up = new UtilisateurPersistance();
            bool recordExist = false;
            recordExist = up.updateUtilisateur(login, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Utilisateur/toto
        public HttpResponseMessage Delete(string login)
        {
            UtilisateurPersistance up = new UtilisateurPersistance();
            bool recordExist = false;
            recordExist = up.deleteUtilisateur(login);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class UtilisateurPersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public UtilisateurPersistance()
            {
                string myConnectionString;
                myConnectionString = "SERVER=127.0.0.1; DATABASE=socopec; UID=root; PASSWORD=rootroot";
                try
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                { }
            }

            public ArrayList getUtilisateurs()
            {
                ArrayList UtilisateurArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Utilisateur";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Utilisateur u = new Utilisateur();
                    u.login = mySQLReader.GetString(0);
                    u.password = mySQLReader.GetString(1);
                    u.role = mySQLReader.GetString(2);
                    u.archive = mySQLReader.GetInt32(3);
                    u.lieu = mySQLReader.GetString(4);
                    UtilisateurArray.Add(u);
                }
                return UtilisateurArray;
            }

            public Utilisateur getUtilisateur(string login)
            {
                Utilisateur u = new Utilisateur();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Utilisateur WHERE Login = " + login;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    u.login = mySQLReader.GetString(0);
                    u.password = mySQLReader.GetString(1);
                    u.role = mySQLReader.GetString(2);
                    u.archive = mySQLReader.GetInt32(3);
                    u.lieu = mySQLReader.GetString(4);
                    return u;
                }
                else
                    return null;
            }

            public long saveUtilisateur(Utilisateur utilisateurToSave)
            {
                String sqlString = "INSERT INTO Utilisateur (Login, Password, Role, Agence_Lieu, UtilisateurArchive) VALUES ('" + utilisateurToSave.login + "','" + utilisateurToSave.password + "','" + utilisateurToSave.role + "','" + utilisateurToSave.lieu + "','" + utilisateurToSave.archive + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deleteUtilisateur(string login)
            {
                Utilisateur u = new Utilisateur();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Utilisateur WHERE Login = " + login;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Utilisateur WHERE Login = " + login;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updateUtilisateur(string login, Utilisateur u)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Utilisateur WHERE Login = " + login;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Utilisateur SET Login ='" + u.login + "', Password ='" + u.password + "', Role = '" + u.role + "', Agence_Lieu = '" + u.lieu + "', UtilisateurArchive ='" + u.archive + "'WHERE Login ='" + login;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }


        }
    }
}
