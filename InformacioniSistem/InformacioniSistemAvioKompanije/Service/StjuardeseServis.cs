using InformacioniSistemAvioKompanije.Conection;
using InformacioniSistemAvioKompanije.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacioniSistemAvioKompanije.Service
{
    public class StjuardeseServis
    {
        private string connectionString = KonekcijaStringBaza.GetConnectionString();

        public void InsertStjuardese(string ime, string prezime, int iskustvo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Stjuardese (Ime, Prezime, godineIskustva) VALUES (@Ime, @Prezime, @Iskustvo)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Ime", ime);
                        cmd.Parameters.AddWithValue("@Prezime", prezime);
                        cmd.Parameters.AddWithValue("@Iskustvo", iskustvo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error inserting Pilot into database: {ex.Message}");
            }
        }

        public List<Stjuardese> GetStjuardese()
        {
            List<Stjuardese> piloti = new List<Stjuardese>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM stjuardese", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stjuardese pilot = new Stjuardese
                            {
                                IDStjuardese = Convert.ToInt32(reader["idstjuardese"]),
                                Ime = reader["Ime"].ToString(),
                                Prezime = reader["Prezime"].ToString(),
                                godineIskustva = Convert.ToInt32(reader["godineIskustva"])
                            };

                            piloti.Add(pilot);
                        }
                    }
                }
            }

            return piloti;
        }

        public void DeleteStjuardesa(int iD)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM stjuardese WHERE idstjuardese = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", iD);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Aerodrom from database: {ex.Message}");
            }
        }
    }
}

