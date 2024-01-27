using InformacioniSistemAvioKompanije.Model;
using InformacioniSistemAvioKompanije.Service;
using Org.BouncyCastle.Utilities;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Label = System.Windows.Controls.Label;


namespace InformacioniSistemAvioKompanije
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Label dodavanjeLabel;
        private ComboBox comboBoxDrzave = null;  // Dodajte polje kao član klase
        private ComboBox comboBoxAerodrom = new ComboBox();
        private ComboBox comboBoxAerodrom2 = new ComboBox();
        private DatePicker datumLeta = new DatePicker();
        private ComboBox comboBoxPilot = new ComboBox();
        public MainWindow()
        {
            InitializeComponent();
            dodavanjeLabel = new Label();

            // Inicijalizirajte ComboBox
            comboBoxDrzave = new ComboBox();
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            unutrasnjiGrid.Children.Clear();
            

        }

        private void Dodavanje_Click(object sender, RoutedEventArgs e) 
        {
            unutrasnjiGrid.Children.Clear();

         
            UniformGrid uniformGrid = new UniformGrid();
            uniformGrid.Rows = 1; 
            unutrasnjiGrid.Children.Add(uniformGrid);

            string[] buttonLabels = { "Pilot", "Aerodrom", "Stjuardesa", "Letovi" };

            for (int i = 0; i < 4; i++)
            {
                Button button = new Button();
                button.Content = buttonLabels[i];
                button.Width = 60;
                button.Height = 40;
                button.Click += Dugme_Clicked; 
                uniformGrid.Children.Add(button);
            }


            
            dodavanjeLabel = new Label();
            dodavanjeLabel.Content = "Meni za Dodavanje";
            dodavanjeLabel.HorizontalAlignment = HorizontalAlignment.Center;
            dodavanjeLabel.VerticalAlignment = VerticalAlignment.Top;
            dodavanjeLabel.Width = 120;
            dodavanjeLabel.Height = 30;
            unutrasnjiGrid.Children.Add(dodavanjeLabel);

        }

        private void AddComboBoxDrzava(StackPanel stackPanel)
        {
            
            DrzavaService drzavaService = new DrzavaService();
            List<Drzave> drzave = drzavaService.DohvatiSveDrzave();

            comboBoxDrzave = new ComboBox();
            comboBoxDrzave.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBoxDrzave.VerticalAlignment = VerticalAlignment.Center;
            comboBoxDrzave.ItemsSource = drzave;
            comboBoxDrzave.DisplayMemberPath = "ImeDrzave";
            comboBoxDrzave.SelectedValuePath = "ID";

            stackPanel.Children.Add(new Label { Content = "Odaberi Državu" });
            stackPanel.Children.Add(comboBoxDrzave);
        }
        private void Dugme_Clicked(object sender, RoutedEventArgs e)
        {
            unutrasnjiGrid.Children.Clear();

            StackPanel stackPanel = new StackPanel();
            unutrasnjiGrid.Children.Add(stackPanel);

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Label labelUnutarDugmeta = new Label();
                labelUnutarDugmeta.Content = $"Dodajem za {clickedButton.Content}";
                stackPanel.Children.Add(labelUnutarDugmeta);

                for (int i = 0; i < 3; i++)
                {
                    if (clickedButton.Content.ToString() == "Pilot")
                    {
                        switch (i)
                        {
                            case 0:
                                stackPanel.Children.Clear();
                                AddTextBox(stackPanel, "Unesite Ime Pilota");
                                break;
                            case 1:
                                AddTextBox(stackPanel, "Unesite Prezime Pilota");
                                break;
                            case 2:
                                AddTextBox(stackPanel, "Unesite Godine iskustva");
                                break;
                        }
                    }
                    else if (clickedButton.Content.ToString() == "Aerodrom")
                    {
                        switch (i)
                        {
                            case 0:
                                stackPanel.Children.Clear();
                                AddTextBox(stackPanel, "Unesite Ime Aerodroma");
                                break;
                            case 1:
                                AddTextBox(stackPanel, "Unesite Grad Aerodroma");
                                break;
                            case 2:
                                AddComboBoxDrzava(stackPanel);
                                break;
                        }
                    }
                    else if (clickedButton.Content.ToString() == "Stjuardesa")
                    {
                        switch (i)
                        {
                            case 0:
                                stackPanel.Children.Clear();
                                AddTextBox(stackPanel, "Unesite Ime Stjuardese/a");
                                break;
                            case 1:
                                AddTextBox(stackPanel, "Unesite Prezime");
                                break;
                            case 2:
                                AddTextBox(stackPanel, "Unesite Godine Iskustva");
                                break;
                        }
                    }
                    else if (clickedButton.Content.ToString() == "Letovi")
                    {
                        switch (i)
                        {
                            case 0:
                                stackPanel.Children.Clear();
                                AddComboBoxAerodroma(stackPanel);
                                AddComboBoxAerodroma2(stackPanel);
                                break;
                            case 1:
                                AddComboBoxPilota(stackPanel);
                                break;
                            case 2:
                                AddDateBox(stackPanel);
                                break;
                        }
                    }
                   
                }
                Button buttona = new Button();
                buttona.HorizontalAlignment = HorizontalAlignment.Center;
                buttona.VerticalAlignment = VerticalAlignment.Bottom;
                buttona.Width = 100;
                buttona.Height = 50;
                buttona.Content = $"Postavi za {clickedButton.Content}";
                buttona.Click += Postavi_Clicked;
                stackPanel.Children.Add(buttona);
            }
        }

        private void AddComboBoxPilota(StackPanel stackPanel)
        {
            PilotService drzavaService = new PilotService();
            List<Pilot> drzave = drzavaService.GetPilots();
            comboBoxPilot = new ComboBox();
            comboBoxPilot.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBoxPilot.VerticalAlignment = VerticalAlignment.Center;
            comboBoxPilot.ItemsSource = drzave;
            comboBoxPilot.DisplayMemberPath = "Ime";
            comboBoxPilot.SelectedValuePath = "ID";

            stackPanel.Children.Add(new Label { Content = "Odaberi Pilota" });
            stackPanel.Children.Add(comboBoxPilot);
        }

        private void AddDateBox(StackPanel stackPanel)
        {
            datumLeta.HorizontalAlignment= HorizontalAlignment.Stretch;
            datumLeta.VerticalAlignment= VerticalAlignment.Center;
            datumLeta.Width = 100;
            datumLeta.Height = 50;
            stackPanel.Children.Add(new Label { Content = "Odaberite datum za let" });
            stackPanel.Children.Add(datumLeta);
        }

        private void AddComboBoxAerodroma(StackPanel stackPanel)
        {
            AerodromService drzavaService = new AerodromService();
            List<Aerodrom> drzave = drzavaService.DohvatiSveAerodrome();
            comboBoxAerodrom = new ComboBox(); 
            comboBoxAerodrom.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBoxAerodrom.VerticalAlignment = VerticalAlignment.Center;
            comboBoxAerodrom.ItemsSource = drzave;
            comboBoxAerodrom.DisplayMemberPath = "Ime";
            comboBoxAerodrom.SelectedValuePath = "ID";

            stackPanel.Children.Add(new Label { Content = "Odaberi Aerodrom" });
            stackPanel.Children.Add(comboBoxAerodrom);

        }
        private void AddComboBoxAerodroma2(StackPanel stackPanel)
        {
            AerodromService drzavaService = new AerodromService();
            List<Aerodrom> drzave = drzavaService.DohvatiSveAerodrome();
            comboBoxAerodrom2 = new ComboBox();
            comboBoxAerodrom2.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBoxAerodrom2.VerticalAlignment = VerticalAlignment.Center;
            comboBoxAerodrom2.ItemsSource = drzave;
            comboBoxAerodrom2.DisplayMemberPath = "Ime";
            comboBoxAerodrom2.SelectedValuePath = "ID";

            stackPanel.Children.Add(new Label { Content = "Odaberi Aerodrom" });
            stackPanel.Children.Add(comboBoxAerodrom2);

        }


        private void Postavi_Clicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                try
                {
                    string dioTeksta = clickedButton.Content.ToString().Substring(11);
                    StackPanel stackPanel = unutrasnjiGrid.Children.OfType<StackPanel>().FirstOrDefault();

                    switch (dioTeksta)
                    {
                        case "Pilot":
                            InsertPilotIntoDatabase(stackPanel);
                            break;
                        case "Aerodrom":
                            InsertAerodromIntoDatabase(stackPanel);
                            break;
                        case "Stjuardesa":
                            InsertStjuardesaIntoDatabase(stackPanel);
                            break;
                        case "Letovi":
                            InsertLetoviIntoDatabase(stackPanel);
                            break;
                        default:
                            MessageBox.Show("nepostoji ovo.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private object GetComboBoxValue(StackPanel stackPanel, string labelContent)
        {
            ComboBox comboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault(cb => (cb.Parent as Label)?.Content?.ToString() == labelContent);
            return comboBox?.SelectedValue;  
        }
        private void InsertLetoviIntoDatabase(StackPanel stackPanel)
        {
            int aerodrom1 = (int)comboBoxAerodrom.SelectedValue;
            int aerodrom2 = (int)comboBoxAerodrom2.SelectedValue;
            int id = (int)comboBoxPilot.SelectedValue;
            DateTime date = datumLeta.DisplayDate;
            if(aerodrom1 != 0)
            {
                if(aerodrom2 != 0)
                {
                    LetServise servis = new LetServise();
                    servis.InsertLeta(aerodrom1, aerodrom2, date,id);
                    MessageBox.Show("Let uspjesno dodan u bazu");
                }
            }
           
        }

        private void InsertStjuardesaIntoDatabase(StackPanel stackPanel)
        {
            string ime = GetTextBoxValue(stackPanel, "Unesite Ime Stjuardese/a");

            string prezime = GetTextBoxValue(stackPanel, "Unesite Prezime");
            int iskustvo;

            if (int.TryParse(GetTextBoxValue(stackPanel, "Unesite Godine Iskustva"), out iskustvo))
            {
                StjuardeseServis dbHelper = new StjuardeseServis();
                dbHelper.InsertStjuardese(ime, prezime, iskustvo);

                MessageBox.Show("Stjuardesa uspjesno dodan u bazu ");
            }
            else
            {
                MessageBox.Show("error Stjuardesa nije unesen u bazu");
            }
        }

        private void InsertAerodromIntoDatabase(StackPanel stackPanel)
        {
            string ime = GetTextBoxValue(stackPanel, "Unesite Ime Aerodroma");
            string grad = GetTextBoxValue(stackPanel, "Unesite Grad Aerodroma");

            int drzavaId = (int)comboBoxDrzave.SelectedValue;
            

            if (drzavaId != 0)
            {
                Console.WriteLine($"Ime: {ime}, Grad: {grad}, DrzavaID: {drzavaId}");
                AerodromService aerodromService = new AerodromService();
                aerodromService.InsertAerodrom(ime, grad, drzavaId);

                MessageBox.Show("Uspješno dodan aerodrom");
            }
            else
            {
                MessageBox.Show("Odaberite državu");
            }
        }



        private void InsertPilotIntoDatabase(StackPanel stackPanel)
        {
            string ime = GetTextBoxValue(stackPanel, "Unesite Ime Pilota");
            
            string prezime = GetTextBoxValue(stackPanel, "Unesite Prezime Pilota");
            int iskustvo;

            if (int.TryParse(GetTextBoxValue(stackPanel, "Unesite Godine iskustva"), out iskustvo))
            {
                PilotService dbHelper = new PilotService();
                dbHelper.InsertPilot(ime, prezime, iskustvo);

                MessageBox.Show("Pilot uspjesno dodan u bazu ");
            }
            else
            {
                MessageBox.Show("error pilot nije unesen u bazu");
            }
        }
        private string GetTextBoxValue(StackPanel stackPanel, string placeholder)
        {
            TextBox textBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Tag?.ToString() == placeholder);
            return textBox?.Text ?? string.Empty;
        }


        private void AddTextBox(StackPanel stackPanel, string placeholder)
        {
            TextBox textBox = new TextBox();
            textBox.Tag = placeholder;  // Dodajte Tag kako biste označili TextBox
            textBox.Text = placeholder;
            stackPanel.Children.Add(textBox);
        }


        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {

            unutrasnjiGrid.Children.Clear();


            UniformGrid uniformGrid = new UniformGrid();
            uniformGrid.Rows = 1;
            unutrasnjiGrid.Children.Add(uniformGrid);

            string[] buttonLabels = { "Pilota", "Aerodroma", "Stjuardesa", "Letova" };

            for (int i = 0; i < 4; i++)
            {
                Button button = new Button();
                button.Content = buttonLabels[i];
                button.Width = 60;
                button.Height = 40;
                button.Click += Dugme_Clicked_Brisanje;
                uniformGrid.Children.Add(button);
            }



            dodavanjeLabel = new Label();
            dodavanjeLabel.Content = "Meni za Brisanje";
            dodavanjeLabel.HorizontalAlignment = HorizontalAlignment.Center;
            dodavanjeLabel.VerticalAlignment = VerticalAlignment.Top;
            dodavanjeLabel.Width = 120;
            dodavanjeLabel.Height = 30;
            unutrasnjiGrid.Children.Add(dodavanjeLabel);
        }
        private void Dugme_Clicked_Brisanje (object sender, EventArgs e)
        {
            unutrasnjiGrid.Children.Clear();
            StackPanel stackPanel = new StackPanel();
            unutrasnjiGrid.Children.Add(stackPanel);
            Button clickedButton = sender as Button;
            Button brisanje = new Button { Content = $"Obrisi {clickedButton.Content}" };

            if (clickedButton != null)
            {
                ListBox listBoxToDeleteFrom = null;
                Label labelUnutarDugmeta = new Label();
                labelUnutarDugmeta.Content = $"Brisanje za {clickedButton.Content}";
                stackPanel.Children.Add(labelUnutarDugmeta);
                if (clickedButton.Content.ToString() == "Pilota")
                {
                    PilotService dbHelper = new PilotService();

                    List<Pilot> pilots = dbHelper.GetPilots();


                    ListBox pilotListBox = new ListBox();
                    pilotListBox.DisplayMemberPath = "Ime";

                    foreach (var pilot in pilots)
                    {
                        pilotListBox.Items.Add(pilot);
                    }

                    stackPanel.Children.Add(pilotListBox);
                    stackPanel.Children.Add(brisanje);
                    listBoxToDeleteFrom = pilotListBox;
                }
                else if (clickedButton.Content.ToString() == "Aerodroma")
                {
                    AerodromService service = new AerodromService();
                    List<Aerodrom> aerodroms = service.GetAerodrome();

                    ListBox listaaerodroma = new ListBox();
                    listaaerodroma.DisplayMemberPath = "Ime";
                    foreach (var aerodrom in aerodroms)
                    {
                        listaaerodroma.Items.Add(aerodrom);
                    }
                    stackPanel.Children.Add(listaaerodroma);
                    stackPanel.Children.Add(brisanje);
                    listBoxToDeleteFrom = listaaerodroma;
                }
                else if (clickedButton.Content.ToString() == "Stjuardesa")
                {
                    StjuardeseServis service = new StjuardeseServis();
                    List<Stjuardese> aerodroms = service.GetStjuardese();

                    ListBox listastjuardesa = new ListBox();
                    listastjuardesa.DisplayMemberPath = "Ime";
                    foreach (var aerodrom in aerodroms)
                    {
                        listastjuardesa.Items.Add(aerodrom);
                    }
                    stackPanel.Children.Add(listastjuardesa);
                    stackPanel.Children.Add(brisanje);
                    listBoxToDeleteFrom = listastjuardesa;
                }
                else if (clickedButton.Content.ToString() == "Letova")
                {
                    LetServise service = new LetServise();
                    List<Let> lets = service.GetLetovi();

                    ListBox listaletova = new ListBox();
                    listaletova.DisplayMemberPath = "ImeLeta";
                    foreach (var let in lets)
                    {
                        listaletova.Items.Add(let);
                    }
                    stackPanel.Children.Add(listaletova);
                    stackPanel.Children.Add(brisanje);
                    listBoxToDeleteFrom = listaletova;
                   
                }
                brisanje.Click += (s, args) =>
                {
                    // Perform deletion based on the selected item in the ListBox
                    if (listBoxToDeleteFrom.SelectedItem != null)
                    {
                        // Assuming you have a method in your service classes to delete items
                        if (listBoxToDeleteFrom.SelectedItem is Pilot pilot)
                        {
                            PilotService dbHelper = new PilotService();
                            dbHelper.DeletePilot(pilot.ID); // Replace with your actual deletion logic
                        }
                        else if (listBoxToDeleteFrom.SelectedItem is Aerodrom aerodrom)
                        {
                            AerodromService service = new AerodromService();
                            service.DeleteAerodrom(aerodrom.ID); // Replace with your actual deletion logic
                        }
                        else if (listBoxToDeleteFrom.SelectedItem is Stjuardese stjuardesa)
                        {
                            StjuardeseServis service = new StjuardeseServis();
                            service.DeleteStjuardesa(stjuardesa.IDStjuardese); // Replace with your actual deletion logic
                        }
                        else if (listBoxToDeleteFrom.SelectedItem is Let let)
                        {
                            LetServise service = new LetServise();
                            service.DeleteLet(let.IDLeta); // Replace with your actual deletion logic
                        }

                    }

                };
            }
        }

        private void Pretraga_Click(object sender, RoutedEventArgs e)
        {
            unutrasnjiGrid.Children.Clear();
            UniformGrid uniformGrid = new UniformGrid();
            uniformGrid.Rows = 1;
            unutrasnjiGrid.Children.Add(uniformGrid);

            string[] buttonLabels = { "Pilot", "Aerodrom", "Stjuardesa", "Letovi" };

            for (int i = 0; i < 4; i++)
            {
                Button button = new Button();
                button.Content = buttonLabels[i];
                button.Width = 60;
                button.Height = 40;
                button.Click += Dugme_Pretraga;
                uniformGrid.Children.Add(button);
            }



            dodavanjeLabel = new Label();
            dodavanjeLabel.Content = "Meni Pretragu";
            dodavanjeLabel.HorizontalAlignment = HorizontalAlignment.Center;
            dodavanjeLabel.VerticalAlignment = VerticalAlignment.Top;
            dodavanjeLabel.Width = 120;
            dodavanjeLabel.Height = 30;
            unutrasnjiGrid.Children.Add(dodavanjeLabel);

        }

        private void Dugme_Pretraga(object sender, RoutedEventArgs e)
        {
            unutrasnjiGrid.Children.Clear();
            StackPanel stackPanel = new StackPanel();
            unutrasnjiGrid.Children.Add(stackPanel);
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Label labelUnutarDugmeta = new Label();
                labelUnutarDugmeta.Content = $"Pretraga za {clickedButton.Content}";
                stackPanel.Children.Add(labelUnutarDugmeta);
                if (clickedButton.Content.ToString() == "Pilot")
                {
                    PilotService dbHelper = new PilotService();

                    List<Pilot> pilots = dbHelper.GetPilots();


                    ListBox pilotListBox = new ListBox();
                    pilotListBox.DisplayMemberPath = "Ime";

                    foreach (var pilot in pilots)
                    {
                        pilotListBox.Items.Add(pilot);
                    }

                    stackPanel.Children.Add(pilotListBox);
                }
                else if (clickedButton.Content.ToString() == "Aerodrom")
                {
                    AerodromService service = new AerodromService();
                    List<Aerodrom> aerodroms = service.GetAerodrome();

                    ListBox listaaerodroma = new ListBox();
                    listaaerodroma.DisplayMemberPath = "Ime";
                    foreach (var aerodrom in aerodroms)
                    {
                        listaaerodroma.Items.Add(aerodrom);
                    }
                    stackPanel.Children.Add(listaaerodroma);
                }
                else if (clickedButton.Content.ToString() == "Stjuardesa")
                {
                    StjuardeseServis service = new StjuardeseServis();
                    List<Stjuardese> aerodroms = service.GetStjuardese();

                    ListBox listastjuardesa = new ListBox();
                    listastjuardesa.DisplayMemberPath = "Ime";
                    foreach (var aerodrom in aerodroms)
                    {
                        listastjuardesa.Items.Add(aerodrom);
                    }
                    stackPanel.Children.Add(listastjuardesa);
                }
                else if (clickedButton.Content.ToString() == "Letovi")
                {
                    LetServise service = new LetServise();
                    List<(string ImeAerodromaPolaska, string ImeAerodromaDolaska)> imenaAerodroma = service.GetAllLetovi();

                    ListBox listaletova = new ListBox();

                    foreach (var imeAerodroma in imenaAerodroma)
                    {
                        string imeLeta = $"{imeAerodroma.ImeAerodromaPolaska} - {imeAerodroma.ImeAerodromaDolaska}";
                        listaletova.Items.Add(imeLeta);
                    }

                    stackPanel.Children.Add(listaletova);
                }
            }


        }
        private void Postavke_Click(object sender, RoutedEventArgs e)
        {
            unutrasnjiGrid.Children.Clear();
            StackPanel stackPanel = new StackPanel();
            unutrasnjiGrid.Children.Add(stackPanel);

            Button tamniNacinButton = new Button
            {
                Content = "Tamni način",
                FontSize = 18,
                Margin = new Thickness(0, 0, 0, 10) 
            };
            tamniNacinButton.Click += TamniNacin_Click;
            stackPanel.Children.Add(tamniNacinButton);


            Button svijetliNacinButton = new Button
            {
                Content = "Svijetli način",
                FontSize = 18
            };
            svijetliNacinButton.Click += SvijetliNacin_Click; 
            stackPanel.Children.Add(svijetliNacinButton);
        }

        private void TamniNacin_Click(object sender, RoutedEventArgs e)
        {
            vanjskiGrid.Background = new SolidColorBrush(Colors.DarkGray);
            stackmeni.Background = new SolidColorBrush(Colors.DarkBlue);
        }

        private void SvijetliNacin_Click(object sender, RoutedEventArgs e)
        {
            vanjskiGrid.Background = new SolidColorBrush(Colors.LightGray);
            stackmeni.Background = new SolidColorBrush(Colors.LightCoral);
        }


        private void Oaplikaciji_Click(object sender, RoutedEventArgs e)
        {
            unutrasnjiGrid.Children.Clear();
            StackPanel stackPanel = new StackPanel();
            unutrasnjiGrid.Children.Add(stackPanel);

            TextBlock textBlock = new TextBlock
            {
                Text = "Ova aplikacija je napravljena od strane studenta Hubljar Imad (III godina Softverskog Inženjerstva) u Zenici 2023/2024 god.",
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 18
            };

            stackPanel.Children.Add(textBlock);


        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}