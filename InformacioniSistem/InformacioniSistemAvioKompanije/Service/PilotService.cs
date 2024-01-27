using InformacioniSistemAvioKompanije.Conection;
using InformacioniSistemAvioKompanije.Model;
using MySql.Data.MySqlClient;

public class PilotService
{
    private string connectionString = KonekcijaStringBaza.GetConnectionString();

    public List<Pilot> GetPilots()
    {
        List<Pilot> piloti = new List<Pilot>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM pilot", connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pilot pilot = new Pilot
                        {
                            ID = Convert.ToInt32(reader["idpilot"]),
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
    public void InsertPilot(string ime, string prezime, int iskustvo)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Pilot (Ime, Prezime, godineIskustva) VALUES (@Ime, @Prezime, @Iskustvo)";

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

    public void DeletePilot(int iD)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM pilot WHERE idpilot = @ID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", iD);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Piloti from database: {ex.Message}");
        }
    }
}

