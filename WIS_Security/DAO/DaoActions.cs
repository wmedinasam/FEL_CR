using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WIS_Security.DAO
{
    public static class DaoActions
    {
        public static DataSet GetMSSqlDataFromQuery(string query)
        {
            DataSet ds = new DataSet("datos");
            HandleCfg config = new HandleCfg();
            var cn = DaoConnection.SqConnection();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cn.Close();
            }
            catch (Exception ex)
            {
                config.SaveLog("Base de datos", "[Codigo 002] " + "[Error en la consulta a base de datos] " + "[" + ex.Message + "]", query);
                throw new Exception("Codigo 002 " + "Error en la consulta a base de datos: " + ex.Message);
            }
            return ds;
        }

        public static DataSet ExecuteMSSqlQuery(string query)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            HandleCfg config = new HandleCfg();
            dt.Columns.Add("Success");
            dt.Columns.Add("Message");
            dt.Columns.Add("Afected");
            var cn = DaoConnection.SqConnection();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                var afected = cmd.ExecuteNonQuery();
                if (afected > 0)
                {
                    dt.Rows.Add(true, "", afected.ToString());
                }
                else
                {
                    config.SaveLog("", "[Codigo 002] " + "[Error al ejecutar consulta en base de datos] [No identificado] ", query);
                    dt.Rows.Add(false, "Error no identificado", afected.ToString());
                }
                ds.Tables.Add(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                dt.Rows.Add(false, ex.Message, "0");
                ds.Tables.Add(dt);
                config.SaveLog("Base de datos", "[Codigo 002] " + "[Error al ejecutar consulta en base de datos] " + "[" + ex.Message + "]", query);
                throw ex;
            }
            return ds;
        }

        public static DataSet GetMSSqlDataFromSp(DaoProcedure procedure)
        {
            DataSet ds = new DataSet("datos");
            HandleCfg config = new HandleCfg();
            var cn = DaoConnection.SqConnection();
            SqlCommand cmd = cn.CreateCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure.ProcedureName;
                if (procedure.Parameter != null)
                {
                    foreach (var item in procedure.Parameter)
                    {
                        cmd.Parameters.AddWithValue(item.Name, item.Value).DbType = item.Type;
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                string procedureQuery = "EXEC " + procedure.ProcedureName + " ";
                for (int i = 0; i < procedure.Parameter.Count; i++)
                {
                    if ((procedure.Parameter.Count - 1) > i)
                    {
                        procedureQuery = procedureQuery + procedure.Parameter[i].Name + " = '" + procedure.Parameter[i].Value + "',";
                    }
                    else if ((procedure.Parameter.Count - 1) == i)
                    {
                        procedureQuery = procedureQuery + procedure.Parameter[i].Name + " = '" + procedure.Parameter[i].Value + "';";
                    }
                }
                config.SaveLog("Base de datos", "[Codigo 002] " + "[Error en la consulta a base de datos] " + "[" + ex.Message + "]", procedureQuery);
                throw new Exception("Codigo 002 " + "Error en la consulta");
            }
            return ds;
        }
    }
}
