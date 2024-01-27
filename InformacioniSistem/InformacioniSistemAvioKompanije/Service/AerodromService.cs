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
    public class AerodromService
    {
        private string connectionString = KonekcijaStringBaza.GetConnectionString();

        public void InsertAerodrom(string ime, string grad, int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Aerodrom (Ime, Grad, idDrzave) VALUES (@Ime, @Grad, @IdDrzava)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Ime", ime);
                        cmd.Parameters.AddWithValue("@Grad", grad);  // Ispravljeno ime parametra
                        cmd.Parameters.AddWithValue("@IdDrzava", id); // Ispravljeno ime parametra

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting Aerodrom into database: {ex.Message}");
            }
        }

        public List<Aerodrom> DohvatiSveAerodrome()
        {
            List<Aerodrom> drzave = new List<Aerodrom>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Aerodrom", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aerodrom drzava = new Aerodrom
                            {
                                ID = Convert.ToInt32(reader["idAerodrom"]),
                                Ime = reader["Ime"].ToString(),
                                Grad = reader["Grad"].ToString(),
                                idDrzave = Convert.ToInt32(reader["idDrzave"])                                
                            };

                            drzave.Add(drzava);
                        }
                    }
                }
            }

            return drzave;
        }

        public List<Aerodrom> GetAerodrome()
        {
            List<Aerodrom> aeorodormo = new List<Aerodrom>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM aerodrom", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aerodrom aerodo = new Aerodrom
                            {
                                ID = Convert.ToInt32(reader["idAerodrom"]),
                                Ime = reader["Ime"].ToString(),
                                Grad = reader["Grad"].ToString(),
                                idDrzave = Convert.ToInt32(reader["idDrzave"])
                            };

                            aeorodormo.Add(aerodo);
                        }
                    }
                }
            }

            return aeorodormo;
        }

        public void DeleteAerodrom(int iD)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM aerodrom WHERE idAerodrom = @ID";

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
