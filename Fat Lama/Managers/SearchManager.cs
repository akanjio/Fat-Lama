using Fat_Lama.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Fat_Lama.Managers
{
    public class SearchManager
    {
        public IEnumerable<SearchResult> DoSearch(string itemName, double lat, double lng)
        {
            //build wild card string to query db
            itemName = '%' + itemName.Replace(" ", "%") + '%';
             
            List<SearchResult> theResult = new List<SearchResult>();

            //Directory path to DB. It is bad practice to hardcode dir path, it should be in a config file
            string DBPath = "C:\\Code\\Fat Lama\\fatlama.sqlite3";

            //connect to database
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=" + DBPath + ";Version=3;New=False;Compress=True;");
            sql_con.Open();
            using (sql_con)
            {

                SQLiteCommand sql_cmd = sql_con.CreateCommand();

                //sqlite query
                sql_cmd.CommandText = "SELECT [item_name],[lat],[lng],[item_url],[img_urls] FROM[items] WHERE item_name LIKE '" + itemName + "'LIMIT 20;";

                try
                {
                    //read relevant rows on the db
                    SQLiteDataReader sql_dr = sql_cmd.ExecuteReader();
                    sql_dr.Read();
                    while (sql_dr.HasRows)
                    {
                        //populate search result
                        theResult.Add(new SearchResult
                        {
                            ItemName = sql_dr[0].ToString(),
                            Lat = Convert.ToDouble(sql_dr[1].ToString()),
                            Lng = Convert.ToDouble(sql_dr[2].ToString()),
                            ItemUrl = sql_dr[3].ToString(),
                            ImageUrl = sql_dr[4].ToString()
                        });
                        sql_dr.Read();
                    }
                    sql_dr.Close();
                    return theResult;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sql_con.Close();
                }
            }
        }
    }
}