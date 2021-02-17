using System;
using System.Collections.Generic;
using System.Text;
using ColorDataAccess.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace ColorDataAccess.DataAccess
{
    /// <summary>
    /// MSSQL DATA ACCESS CLASS 
    /// </summary>
    class InventoryDAO : IInventoryDAO
    {
        private string connectionString = Utils.Utils.ConnectionString;

        public IColor GetColor(int id)
        {
            Color color = new Color();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProceduresConsts.GET_COLOR, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read())
                    {
                        color = new Color
                        {
                            Id = id,
                            Name = (string)reader["COLOR_NAME"],
                            HexCode = (string)reader["HEXCODE"],
                            IsAvailable = (bool)reader["AVAILABLE"]
                        };
                    }
                    connection.Close();
                }
            }

            return color;
        }


        public IList<IColor> GetColors()
        {
            List<IColor> colors = new List<IColor>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProceduresConsts.GET_INVENTORY, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read())
                    {
                        Color color = new Color
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["COLOR_NAME"],
                            HexCode = (string)reader["HEXCODE"],
                            IsAvailable = (bool)reader["AVAILABLE"]
                        };
                        colors.Add(color);
                    }
                    connection.Close();
                }
            }

            return colors;
        }

        public void UpdateColor(IColor color)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProceduresConsts.UPDATE_COLOR, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", color.Id);
                    cmd.Parameters.AddWithValue("@name", color.Name);
                    cmd.Parameters.AddWithValue("@hexcode", color.HexCode);
                    cmd.Parameters.AddWithValue("@available", color.IsAvailable);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void InsertColor(IColor color)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                using(SqlCommand cmd=new SqlCommand(StoredProceduresConsts.INSERT_COLOR, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name",color.Name);
                    cmd.Parameters.AddWithValue("@hexcode",color.HexCode);
                    cmd.Parameters.AddWithValue("@available", color.IsAvailable);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteColor(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProceduresConsts.DELETE_COLOR, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
