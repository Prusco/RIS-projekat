using InformacioniSistemAvioKompanije.Conection;
using InformacioniSistemAvioKompanije.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace InformacioniSistemAvioKompanije.Service
{
    public class LetServise
    {
        private string connectionString = KonekcijaStringBaza.GetConnectionString();
        public void InsertLeta(int aerodorm1, int aerodrom2, DateTime date, int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    int maxId = GetMaxIdLetovi(connection);
                    int noviId = maxId + 1;

                    string query = "INSERT INTO letovi (idLetovi,AerodromIDPolaska,AerodromIDDolaska, Datum, idPilota) VALUES (@Id, @Ime, @Prezime, @Iskustvo, @id)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdLet", noviId);
                        cmd.Parameters.AddWithValue("@Ime", aerodorm1);
                        cmd.Parameters.AddWithValue("@Prezime", aerodrom2);
                        cmd.Parameters.AddWithValue("@Iskustvo",date);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error inserting Let into database: {ex.Message}");
            }

        }
        public List<(string ImeAerodromaPolaska, string ImeAerodromaDolaska)> GetAllLetovi()
        {
            List<(string ImeAerodromaPolaska, string ImeAerodromaDolaska)> imenaAerodroma = new List<(string, string)>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = @"
                SELECT
                    aerodromPolaska.Ime AS ImeAerodromaPolaska,
                    aerodromDolaska.Ime AS ImeAerodromaDolaska
                FROM
                    letovi
                JOIN aerodrom AS aerodromPolaska ON letovi.AerodromIDPolaska = aerodromPolaska.idAerodrom
                JOIN aerodrom AS aerodromDolaska ON letovi.AerodromIDDolaska = aerodromDolaska.idAerodrom;
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string imeAerodromaPolaska = reader["ImeAerodromaPolaska"].ToString();
                                string imeAerodromaDolaska = reader["ImeAerodromaDolaska"].ToString();
                                imenaAerodroma.Add((imeAerodromaPolaska, imeAerodromaDolaska));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting ImenaAerodroma from database: {ex.Message}");
            }

            return imenaAerodroma;
        }

        public List<Let> GetLetovi()
        {
            List<Let> letovi = new List<Let>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = @"
                    SELECT 
                        letovi.idLetovi,
                        pilot.idpilot,
                        pilot.Ime as imepilota,
                        pilot.Prezime as prezimepilota,
                        pilot.godineIskustva as godiskpilota,
                        (
                            SELECT aerodrom.Ime 
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDPolaska
                        ) as imeaerodromaPolaska,
                        (
                            SELECT aerodrom.Grad 
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDPolaska
                        ) as aerodromgradPolaska,
                        (
                            SELECT aerodrom.idDrzave 
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDPolaska
                        ) as idDrzavePolaska,
                        (
                            SELECT aerodrom.Ime 
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDDolaska
                        ) as imeaerodromaDolaska,
                        (
                            SELECT aerodrom.Grad 
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDDolaska
                        ) as aerodromgradDolaska,
                        (
                            SELECT aerodrom.idDrzave 
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDDolaska
                        ) as idDrzaveDolaska,
                        (
                            SELECT aerodrom.idAerodrom
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDPolaska
                        ) as idAerodromPolaska,
                        (
                            SELECT aerodrom.idAerodrom
                            FROM aerodrom 
                            WHERE aerodrom.idAerodrom = letovi.AerodromIDDolaska
                        ) as idAerodromDolaska
                    FROM letovi
                    JOIN pilot ON letovi.idPilota = pilot.idpilot
                    JOIN letovi_stjuardese_veza as lsv ON lsv.idLetovi = letovi.idLetovi
                    JOIN stjuardese ON lsv.idStjuardese = stjuardese.idstjuardese;
                    ";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Let let = new Let
                            {
                                IDLeta = Convert.ToInt32(reader["idLetovi"]),
                                PilotLeta = new Pilot
                                {
                                    ID = Convert.ToInt32(reader["idpilot"]),
                                    Ime = reader["imepilota"].ToString(),
                                    Prezime = reader["prezimepilota"].ToString(),
                                    godineIskustva = Convert.ToInt32(reader["godiskpilota"])
                                },
                                AerodromPolaska = new Aerodrom
                                {
                                    ID = Convert.ToInt32(reader["idAerodromPolaska"]),
                                    Ime = reader["imeaerodromaPolaska"].ToString(),
                                    Grad = reader["aerodromgradPolaska"].ToString(),
                                    idDrzave = Convert.ToInt32(reader["idDrzavePolaska"])
                                },
                                AerodromDolaska = new Aerodrom
                                {
                                    ID = Convert.ToInt32(reader["idAerodromDolaska"]),
                                    Ime = reader["imeaerodromaDolaska"].ToString(),
                                    Grad = reader["aerodromgradDolaska"].ToString(),
                                    idDrzave = Convert.ToInt32(reader["idDrzaveDolaska"])
                                }
                            };

                            letovi.Add(let);
                        }
                    }
                }
            }

            return letovi;
        }
        public void DeleteLet(int iD)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM letovi WHERE idLetovi = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", iD);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Letovi from database: {ex.Message}");
            }
        }
        private int GetMaxIdLetovi(MySqlConnection connection)
        {
            string maxIdQuery = "SELECT MAX(idLetovi) FROM letovi";

            using (MySqlCommand cmd = new MySqlCommand(maxIdQuery, connection))
            {
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return 0;
            }
        }
    }
}
