using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DATA
{
	public class DbContext
	{
		public string ConnStr { get; set; }
		public SqlConnection Conn { get; set; }

		public DbContext()
		{
			ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
			SqlConnection Conn = new SqlConnection(ConnStr);
			Conn.Open();
		}
		public void Close()
		{
			Conn.Close();
		}
		public int ExecuteNonQuery(string Sql)
		{
			SqlCommand cmd = new SqlCommand(Sql, Conn);
			return cmd.ExecuteNonQuery();
		}
		public DataTable Execute(string Sql)
		{
			SqlCommand cmd = new SqlCommand(Sql, Conn);
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			da.SelectCommand = cmd;
			da.Fill(dt);
			return dt;
		}
		public object ExecuteScalar(string Sql)
		{
			SqlCommand cmd = new SqlCommand(Sql, Conn);
			return cmd.ExecuteScalar();
		}

	}
}