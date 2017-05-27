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
    public class VehiculeController : ApiController
    {
        // GET: api/Vehicule
        public ArrayList Get()
        {
            VehiculePersistance vp = new VehiculePersistance();
            return vp.getVehicules();
        }

        // GET: api/Vehicule/5
        public Vehicule Get(string id)
        {
            VehiculePersistance vp = new VehiculePersistance();
            Vehicule v = vp.getVehicule(id);
            return v;
        }

        // POST: api/Vehicule
        public HttpResponseMessage Post([FromBody]Vehicule value)
        {
            VehiculePersistance vp = new VehiculePersistance();
            long id;
            id = vp.saveVehicule(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Vehicule/{0}", id));
            return response;
        }

        // PUT: api/Vehicule/5
        public HttpResponseMessage Put(string id, [FromBody]Vehicule value)
        {
            VehiculePersistance vp = new VehiculePersistance();
            bool recordExist = false;
            recordExist = vp.updateVehicule(id, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Vehicule/5
        public HttpResponseMessage Delete(string id)
        {
            VehiculePersistance vp = new VehiculePersistance();
            bool recordExist = false;
            recordExist = vp.deleteVehicule(id);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class VehiculePersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public VehiculePersistance()
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

            public ArrayList getVehicules()
            {
                ArrayList VehiculeArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Vehicule";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Vehicule v = new Vehicule();
                    v.id = mySQLReader.GetString(0);
                    v.modele = mySQLReader.GetString(1);
                    v.dateFabrication = mySQLReader.GetDateTime(2);
                    v.statut = mySQLReader.GetString(3);
                    v.lieu = mySQLReader.GetString(4);
                    v.archive = mySQLReader.GetInt32(5);
                    VehiculeArray.Add(v);
                }
                return VehiculeArray;
            }

            public Vehicule getVehicule(string id)
            {
                Vehicule v = new Vehicule();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Vehicule WHERE ID = " + id;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    v.id = mySQLReader.GetString(0);
                    v.modele = mySQLReader.GetString(1);
                    v.dateFabrication = mySQLReader.GetDateTime(2);
                    v.statut = mySQLReader.GetString(3);
                    v.lieu = mySQLReader.GetString(4);
                    v.archive = mySQLReader.GetInt32(5);
                    return v;
                }
                else
                    return null;
            }

            public long saveVehicule(Vehicule vehiculeToSave)
            {
                String sqlString = "INSERT INTO Vehicule (IdVehicule, Modele_Modele, DateFabrication, Etat_Statut, Agence_Lieu, Archive) VALUES ('" + vehiculeToSave.id + "','" + vehiculeToSave.modele + "','" + vehiculeToSave.dateFabrication.ToString("YYYY-MM-dd") + "','" + vehiculeToSave.statut + "','" + vehiculeToSave.lieu + "','" + vehiculeToSave.archive + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deleteVehicule(string id)
            {
                Vehicule v = new Vehicule();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Vehicule WHERE ID = " + id;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Vehicule WHERE ID = " + id;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn); 
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updateVehicule(string id, Vehicule v)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Vehicule WHERE ID = " + id;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Vehicule SET IdVehicule ='" + v.id + "', Modele_Modele ='" + v.modele + "', DateFabrication ='" + v.dateFabrication.ToString("YYYY-MM-dd") + "', Etat_Statut = '" + v.statut + "', Agence_Lieu = '" + v.lieu + "', Archive ='" + v.archive + "'WHERE id ='" + id;
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
