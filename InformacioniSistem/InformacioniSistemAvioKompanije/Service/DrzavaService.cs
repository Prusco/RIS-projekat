using InformacioniSistemAvioKompanije.Conection;
using InformacioniSistemAvioKompanije.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows;
public class DrzavaService
{
    private string connectionString = KonekcijaStringBaza.GetConnectionString();

    public List<Drzave> DohvatiSveDrzave()
    {
        List<Drzave> drzave = new List<Drzave>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM drzave", connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Drzave drzava = new Drzave
                        {
                            ID = Convert.ToInt32(reader["idDrzave"]),
                            ImeDrzave = reader["NazivDrzave"].ToString(),
                            Skracenica = reader["Skracenice"].ToString()
                        };

                        drzave.Add(drzava);
                    }
                }
            }
        }

        return drzave;
    }

}
