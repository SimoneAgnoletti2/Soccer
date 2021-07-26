using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Soccer.Controls;
using Soccer.Models;
using Soccer.Resources;
using Soccer.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soccer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anteprima : ContentPage
    {
        public Anteprima()
        {
            InitializeComponent();
                
            primo.Source = ImageSource.FromResource("Soccer.Immagini.01.png");
            rimani.Text = LangAppResources.keeplogin;
            login.Text = LangAppResources.login;
            signup.Text = LangAppResources.signup;
            nick.Text = "";
            nick.Placeholder = LangAppResources.insertusername;
            pass.Text = "";
            pass.Placeholder = LangAppResources.insertpassword;
            connectionerror.Source = ImageSource.FromResource("Soccer.Immagini.connectionerror.png");
            rimani.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked()),
            });

        }

        public async void ButtonClickedLogin(object sender, EventArgs e)
        {
            act.IsRunning = true;
            if (nick.Text != null && pass.Text != null)
            {
                if (nick.Text.Replace(" ", "").ToLower() != "" && pass.Text.Replace(" ", "").ToLower() != "")
                {
                    DatabaseUser dbu = new DatabaseUser();
                    Utente us = new Utente();
                    us.Nome = nick.Text.Replace(" ", "").ToLower();
                    us.Password = pass.Text.Replace(" ", "").ToLower();
                    if (check.IsChecked)
                    {
                        us.Mantain = 1;
                        await dbu.setMantainUserDisable();
                    }
                    else
                    {
                        us.Mantain = 0;
                    }

                    int enter = await dbu.existUser(us);


                    if (enter > 0)
                    {
                        await dbu.updateUserMantain(us.Nome, us.Mantain); 
                        Preferences.Set("Nome", us.Nome);
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        act.IsRunning = false;
                        await DisplayAlert("Errore", "Username o password non validi!", "OK");
                        nick.Text = "";
                        pass.Text = "";
                        nick.Placeholder = LangAppResources.insertusername;
                        pass.Placeholder = LangAppResources.insertpassword;
                    }
                }
                else
                {
                    act.IsRunning = false;
                    await DisplayAlert("Errore", "Inserire un Username e una password validi", "OK");
                    nick.Text = "";
                    pass.Text = "";
                    nick.Placeholder = LangAppResources.insertusername;
                    pass.Placeholder = LangAppResources.insertpassword;
                }
            }
            else
            {
                act.IsRunning = false;
                await DisplayAlert("Errore", "Inserire un Username e una password validi", "OK");
                nick.Text = "";
                pass.Text = "";
                nick.Placeholder = LangAppResources.insertusername;
                pass.Placeholder = LangAppResources.insertpassword;
            }

        }

        public async void ButtonClickedSignin(object sender, EventArgs e)
        {
            act.IsRunning = true;
            bool popola = false;
            if (nick.Text != null && pass.Text != null)
            {
                if (nick.Text.Replace(" ", "").ToLower() != "" && pass.Text.Replace(" ", "").ToLower() != "")
                {
                    Utente us = new Utente();
                    us.Nome = nick.Text.Replace(" ", "").ToLower();
                    us.Password = pass.Text.Replace(" ", "").ToLower();
                    if (check.IsChecked)
                    {
                        us.Mantain = 1;
                    }
                    else
                    {
                        us.Mantain = 0;
                    }

                    bool inserimento = await enterUser(us);

                    if (inserimento)
                    {
                        DatabaseUser dbu = new DatabaseUser(); await dbu.CreateTableUser();
                        await dbu.InsUser(us);
                        Preferences.Set("Nome", us.Nome);
                        popola = await popolaDb();
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        act.IsRunning = false;
                        await DisplayAlert("Errore", "NickName già scelto!", "OK");
                        nick.Text = "";
                        pass.Text = "";
                        nick.Placeholder = LangAppResources.insertusername;
                        pass.Placeholder = LangAppResources.insertpassword;
                    }
                }
                else
                {
                    act.IsRunning = false;
                    await DisplayAlert("Errore", "Inserire un NickName valido", "OK");
                    nick.Text = "";
                    pass.Text = "";
                    nick.Placeholder = LangAppResources.insertusername;
                    pass.Placeholder = LangAppResources.insertpassword;
                }
            }
            else
            {
                act.IsRunning = false;
                await DisplayAlert("Errore", "Inserire un NickName valido", "OK");
                nick.Text = "";
                pass.Text = "";
                nick.Placeholder = LangAppResources.insertusername;
                pass.Placeholder = LangAppResources.insertpassword;
            }

        }

        public void OnFocusedUser(object sender, EventArgs e)
        {
            lblUser.TextColor = Color.FromHex("#ff4a00");
        }

        public void OnFocusedPass(object sender, EventArgs e)
        {
            lblPass.TextColor = Color.FromHex("#ff4a00");
        }

        public void OnFocusedUserOut(object sender, EventArgs e)
        {
            lblUser.TextColor = Color.FromHex("#8c8c8c");
        }

        public void OnFocusedPassOut(object sender, EventArgs e)
        {
            lblPass.TextColor = Color.FromHex("#8c8c8c");
        }

        public void OnLabelClicked()
        {
            if (check.IsChecked)
                check.IsChecked = false;
            else
                check.IsChecked = true;
        }

        public async Task<bool> popolaDb()
        {
            await popolaDbCountries();
            return true;
        }

        public async Task<bool> enterUser(Utente u)
        {
            DatabaseUser dbu = new DatabaseUser();
            SqlConnection connection;
            string connectionString;
            connectionString = @"Data Source=pinexp.ns0.it\MIOSERVER,65004;" + "Initial Catalog=Soccer;" + @"User id=sa;" + "Password=Pinexp93;";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "SELECT Count(*) FROM Utente WHERE Nome =  '" + u.Nome + "' AND Password = '" + u.Password + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int exist = reader.GetInt32(0);
                            reader.Close();

                            if (exist == 0)
                            {
                                command = new SqlCommand("INSERT INTO Utente (Nome,Password,Saldo,AddressIp) values (@Nome, @Password, @Saldo, @AddressIp)", connection);
                                command.Parameters.AddWithValue("@Nome", u.Nome);
                                command.Parameters.AddWithValue("@Password", u.Password);
                                command.Parameters.AddWithValue("@Saldo", 100);
                                command.Parameters.AddWithValue("@AddressIp", u.Ip);

                                command.ExecuteNonQuery();

                                if (dbu.TableExist("Utente"))
                                {
                                    await dbu.InsUser(u);
                                    return true;
                                }
                                else
                                {
                                    await dbu.CreateTableUser();
                                    await dbu.InsUser(u);
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    connection.Close();
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task popolaDbCountries()
        {
            DatabasePaesi dbc = new DatabasePaesi();

            if(!dbc.TableExist("Paese"))
            {
                await dbc.CreateTablePaese();
            }
            else
            {
                await dbc.DropTablePaese();
                await dbc.CreateTablePaese();
            }

            Paese paese = new Paese();

            SqlConnection connection;
            string connectionString;
            connectionString = @"Data Source=pinexp.ns0.it\MIOSERVER,65004;" + "Initial Catalog=Soccer;" + @"User id=sa;" + "Password=Pinexp93;";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "SELECT Id, Nome, LinkImage, Valida FROM Paese WHERE Valida = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paese = new Paese();
                            paese.Id = reader.GetInt32(0);
                            paese.Nome = reader.GetString(1);
                            paese.LinkImage = reader.GetString(2);
                            paese.Valido = reader.GetInt32(3);
                            paese.Preferito = 0;
                            await dbc.InsPaese(paese);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        //public async Task popolaDbLeague()
        //{
        //    bool nextpage = true;
        //    int page = 1;

        //    DatabaseLeagues dbc = new DatabaseLeagues();
        //    if (!dbc.TableExist("Leagues"))
        //    {
        //        await dbc.CreateTableLeagues();
        //    }

        //    try
        //    {
        //        while (nextpage == true)
        //        {
        //            var client = new HttpClient();
        //            var request = new HttpRequestMessage
        //            {
        //                Method = HttpMethod.Get,
        //                RequestUri = new Uri("https://elenasport-io1.p.rapidapi.com/v2/league?page=" + page),
        //                Headers =
        //                {
        //                    { "x-rapidapi-key", "8a76f5d365mshde309b1e6b5886bp1c5d9djsnfcfe04571bcb" },
        //                    { "x-rapidapi-host", "elenasport-io1.p.rapidapi.com" },
        //                },
        //            };
        //            using (var response = await client.SendAsync(request))
        //            {
        //                response.EnsureSuccessStatusCode();
        //                var body = await response.Content.ReadAsStringAsync();

        //                var paginata = JsonConvert.DeserializeObject<RootLeague>(body);

        //                foreach (League c in paginata.data)
        //                {
        //                    await dbc.InsLeague(c);
        //                }
        //                if (!paginata.pagination.hasNextPage)
        //                {
        //                    nextpage = false;
        //                }
        //                page++;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public async Task popolaDbSeason(string token)
        //{
        //    bool nextpage = true;
        //    int page = 1;

        //    DatabaseSeason dbc = new DatabaseSeason();
        //    if (!dbc.TableExist("Seasons"))
        //    {
        //        await dbc.CreateTableSeason();
        //    }

        //    try
        //    {
        //        while (nextpage == true)
        //        {
        //            var client = new HttpClient();
        //            var request = new HttpRequestMessage
        //            {
        //                Method = HttpMethod.Get,
        //                RequestUri = new Uri("https://elenasport-io1.p.rapidapi.com/v2/season?page=" + page),
        //                Headers =
        //                {
        //                    { "x-rapidapi-key", "8a76f5d365mshde309b1e6b5886bp1c5d9djsnfcfe04571bcb" },
        //                    { "x-rapidapi-host", "elenasport-io1.p.rapidapi.com" },
        //                },
        //            };
        //            using (var response = await client.SendAsync(request))
        //            {
        //                response.EnsureSuccessStatusCode();
        //                var body = await response.Content.ReadAsStringAsync();

        //                var paginata = JsonConvert.DeserializeObject<RootSeason>(body);

        //                foreach (Season c in paginata.data)
        //                {
        //                    await dbc.InsSeason(c);
        //                }
        //                if (!paginata.pagination.hasNextPage)
        //                {
        //                    nextpage = false;
        //                }
        //                page++;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}