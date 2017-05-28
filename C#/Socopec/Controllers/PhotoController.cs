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
    public class PhotoController : ApiController
    {
        // GET: api/Photo
        public ArrayList Get()
        {
            PhotoPersistance pp = new PhotoPersistance();
            return pp.getPhotos();
        }

        // GET: api/Photo/C3.png
        public Photo Get(string url)
        {
            PhotoPersistance pp = new PhotoPersistance();
            Photo p = pp.getPhoto(url);
            return p;
        }

        // POST: api/Photo
        public HttpResponseMessage Post([FromBody]Photo value)
        {
            PhotoPersistance pp = new PhotoPersistance();
            long id;
            id = pp.savePhoto(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Etat/{0}", id));
            return response;
        }

        // PUT: api/Photo/C3.png
        public HttpResponseMessage Put(string url, [FromBody]Photo value)
        {
            PhotoPersistance pp = new PhotoPersistance();
            bool recordExist = false;
            recordExist = pp.updatePhoto(url, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Photo/C3.png
        public HttpResponseMessage Delete(string url)
        {
            PhotoPersistance pp = new PhotoPersistance();
            bool recordExist = false;
            recordExist = pp.deletePhoto(url);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class PhotoPersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public PhotoPersistance()
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

            public ArrayList getPhotos()
            {
                ArrayList EtatArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Photo";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Photo p = new Photo();
                    p.idVehicule = mySQLReader.GetString(0);
                    p.url = mySQLReader.GetString(1);
                    EtatArray.Add(p);
                }
                return EtatArray;
            }

            public Photo getPhoto(string url)
            {
                Photo p = new Photo();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Photo WHERE Url = " + url;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    p.idVehicule = mySQLReader.GetString(0);
                    p.url = mySQLReader.GetString(1);
                    return p;
                }
                else
                    return null;
            }

            public long savePhoto(Photo photoToSave)
            {
                String sqlString = "INSERT INTO Photo (IdVehicule, Url) VALUES ('" + photoToSave.idVehicule + "','" + photoToSave.url + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deletePhoto(string url)
            {
                Photo p = new Photo();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Photo WHERE Url = " + url;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Photo WHERE Url = " + url;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updatePhoto(string url, Photo p)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Photo WHERE Url = " + url;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Photo SET IdVehicule ='" + p.idVehicule + "', Url ='" + p.url + "' WHERE Url = '" + url;
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
