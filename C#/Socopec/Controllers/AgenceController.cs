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
    public class AgenceController : ApiController
    {
        // GET: api/Agence
        public ArrayList Get()
        {
            AgencePersistance ap = new AgencePersistance();
            return ap.getAgences();
        }

        // GET: api/Agence/Tokyo
        public Agence Get(string lieu)
        {
            AgencePersistance ap = new AgencePersistance();
            Agence a = ap.getAgence(lieu);
            return a;
        }

        // POST: api/Agence
        public HttpResponseMessage Post([FromBody]Agence value)
        {
            AgencePersistance ap = new AgencePersistance();
            long id;
            id = ap.saveAgence(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Agence/{0}", id));
            return response;
        }

        // PUT: api/Agence/Tokyo
        public HttpResponseMessage Put(string lieu, [FromBody]Agence value)
        {
            AgencePersistance ap = new AgencePersistance();
            bool recordExist = false;
            recordExist = ap.updateAgence(lieu, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Agence/Tokyo
        public HttpResponseMessage Delete(string lieu)
        {
            AgencePersistance ap = new AgencePersistance();
            bool recordExist = false;
            recordExist = ap.deleteAgence(lieu);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class AgencePersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public AgencePersistance()
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

            public ArrayList getAgences()
            {
                ArrayList AgenceArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Agence";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Agence a = new Agence();
                    a.lieu = mySQLReader.GetString(0);
                    a.archive = mySQLReader.GetString(1);
                    AgenceArray.Add(a);
                }
                return AgenceArray;
            }

            public Agence getAgence(string lieu)
            {
                Agence a = new Agence();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Agence WHERE Lieu = " + lieu;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    a.lieu = mySQLReader.GetString(0);
                    a.archive = mySQLReader.GetString(1);
                    return a;
                }
                else
                    return null;
            }

            public long saveAgence(Agence agenceToSave)
            {
                String sqlString = "INSERT INTO Agence (Lieu, LieuArchive) VALUES ('" + agenceToSave.lieu + "','" + agenceToSave.archive + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deleteAgence(string lieu)
            {
                Agence a = new Agence();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Agence WHERE Lieu = " + lieu;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Agence WHERE Lieu = " + lieu;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updateAgence(string lieu, Agence a)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Agence WHERE Lieu = " + lieu;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Agence SET Lieu ='" + a.lieu + "', LieuArchive ='" + a.archive;
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
