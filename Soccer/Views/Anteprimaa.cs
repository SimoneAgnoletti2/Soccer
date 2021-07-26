using Soccer;
using Soccer.Controls;
using Soccer.Models;
using Soccer.Resources;
using Soccer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soccer.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class Anteprimaa : ContentPage
    {
        Label lblUser = new Label();
        ActivityIndicator act = new ActivityIndicator();
        Entry nick = new Entry();
        Entry pass = new Entry();
        CheckBox check = new CheckBox();
        Button login = new Button();
        Button signup = new Button();
        Label lblPass = new Label();
        public Anteprimaa()
        {

            BindingContext = new AnteprimaViewModels(Navigation);

            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(20, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(5, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(6, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(6, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(5, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(10, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(10, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            },
                ColumnDefinitions =
            {
                new ColumnDefinition {Width = new GridLength(10, GridUnitType.Star) },
                new ColumnDefinition {Width = new GridLength(20, GridUnitType.Star) },
                new ColumnDefinition {Width = new GridLength(40, GridUnitType.Star) },
                new ColumnDefinition {Width = new GridLength(20, GridUnitType.Star) },
                new ColumnDefinition {Width = new GridLength(10, GridUnitType.Star) },
            }
            };

            grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            grid.VerticalOptions = LayoutOptions.FillAndExpand;
            grid.BackgroundColor = Color.White;

            //IMMAGINE LOGO
            Image primo = new Image();
            primo.Aspect = Aspect.AspectFit;
            primo.HorizontalOptions = LayoutOptions.FillAndExpand;
            primo.VerticalOptions = LayoutOptions.CenterAndExpand;
            primo.Source = ImageSource.FromResource("Soccer.Immagini.01.png");

            Grid.SetRow(primo, 0);
            Grid.SetColumn(primo, 0);
            Grid.SetColumnSpan(primo, 5);
            grid.Children.Add(primo);


            //ACTIVITYINDICATOR
            act = new ActivityIndicator();
            act.Color = Color.FromHex("#ff4a00");
            act.HorizontalOptions = LayoutOptions.CenterAndExpand;
            act.VerticalOptions = LayoutOptions.CenterAndExpand;

            Grid.SetRow(act, 1);
            Grid.SetColumn(act, 0);
            Grid.SetColumnSpan(act, 5);
            grid.Children.Add(act);


            //LABEL USERNAME
            StackLayout stack = new StackLayout();
            stack.BackgroundColor = Color.White;
            stack.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack.VerticalOptions = LayoutOptions.FillAndExpand;

            lblUser = new Label();
            lblUser.Text = "Username";
            lblUser.TextColor = Color.FromHex("#8c8c8c");
            lblUser.TextTransform = TextTransform.Uppercase;
            lblUser.FontSize = 15;
            lblUser.HorizontalOptions = LayoutOptions.Start;
            lblUser.VerticalOptions = LayoutOptions.Start;
            stack.Children.Add(lblUser);

            Grid.SetRow(stack, 2);
            Grid.SetColumn(stack, 1);
            Grid.SetColumnSpan(stack, 3);
            grid.Children.Add(stack);




            //ENTRY USERNAME
            StackLayout stack2 = new StackLayout();
            stack2.BackgroundColor = Color.Red;
            stack2.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack2.VerticalOptions = LayoutOptions.FillAndExpand;

            StackLayout stack3 = new StackLayout();
            stack3.BackgroundColor = Color.White;
            stack3.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack3.VerticalOptions = LayoutOptions.FillAndExpand;

            nick = new Entry();
            nick.Text = "";
            nick.TextColor = Color.Black;
            nick.Placeholder = "Inserisci il tuo Username";
            nick.PlaceholderColor = Color.Black;
            nick.FontSize = 15;
            nick.BackgroundColor = Color.White;
            nick.HorizontalOptions = LayoutOptions.Start;
            nick.VerticalOptions = LayoutOptions.FillAndExpand;
            nick.Focused += OnFocusedUser;
            nick.Unfocused += OnFocusedUserOut;
            stack3.Children.Add(nick);
            stack2.Children.Add(stack3);


            Grid.SetRow(stack2, 3);
            Grid.SetColumn(stack2, 1);
            Grid.SetColumnSpan(stack2, 3);
            grid.Children.Add(stack2);




            //LABEL PASSWORD
            StackLayout stack4 = new StackLayout();
            stack4.BackgroundColor = Color.White;
            stack4.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack4.VerticalOptions = LayoutOptions.FillAndExpand;

            lblPass = new Label();
            lblPass.Text = "Password";
            lblPass.TextColor = Color.FromHex("#8c8c8c");
            lblPass.TextTransform = TextTransform.Uppercase;
            lblPass.FontSize = 15;
            lblPass.HorizontalOptions = LayoutOptions.Start;
            lblPass.VerticalOptions = LayoutOptions.Start;
            stack4.Children.Add(lblPass);

            Grid.SetRow(stack4, 4);
            Grid.SetColumn(stack4, 1);
            Grid.SetColumnSpan(stack4, 4);
            grid.Children.Add(stack4);


            //ENTRY PASSWORD
            StackLayout stack5 = new StackLayout();
            stack5.BackgroundColor = Color.Black;
            stack5.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack5.VerticalOptions = LayoutOptions.FillAndExpand;

            StackLayout stack6 = new StackLayout();
            stack6.BackgroundColor = Color.White;
            stack6.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack6.VerticalOptions = LayoutOptions.FillAndExpand;

            pass = new Entry();
            pass.Text = "";
            pass.TextColor = Color.Black;
            pass.Placeholder = "Inserisci la password";
            pass.PlaceholderColor = Color.Black;
            pass.IsPassword = true;
            pass.FontSize = 15;
            pass.BackgroundColor = Color.White;
            pass.HorizontalOptions = LayoutOptions.Start;
            pass.VerticalOptions = LayoutOptions.FillAndExpand;
            pass.Focused += OnFocusedPass;
            pass.Unfocused += OnFocusedPassOut;
            stack6.Children.Add(pass);
            stack5.Children.Add(stack6);

            Grid.SetRow(stack5, 5);
            Grid.SetColumn(stack5, 1);
            Grid.SetColumnSpan(stack5, 4);
            grid.Children.Add(stack5);


            //CHECKBOX
            StackLayout stack7 = new StackLayout();
            stack7.BackgroundColor = Color.Black;
            stack7.HorizontalOptions = LayoutOptions.StartAndExpand;
            stack7.VerticalOptions = LayoutOptions.CenterAndExpand;
            check = new CheckBox();
            check.BackgroundColor = Color.White;
            check.Color = Color.FromHex("#ff4a00");
            stack7.Children.Add(check);

            Grid.SetRow(stack7, 6);
            Grid.SetColumn(stack7, 1);
            grid.Children.Add(stack7);


            //LABEL CHECKBOX
            StackLayout stack8 = new StackLayout();
            stack8.BackgroundColor = Color.White;
            stack8.HorizontalOptions = LayoutOptions.StartAndExpand;
            stack8.VerticalOptions = LayoutOptions.CenterAndExpand;
            stack8.Margin = new Thickness(30, 0, 0, 0);
            Label rimani = new Label();
            rimani.BackgroundColor = Color.White;
            rimani.TextColor = Color.FromHex("#8c8c8c");
            rimani.FontSize = 15;
            rimani.Text = LangAppResources.keeplogin;
            rimani.HorizontalOptions = LayoutOptions.StartAndExpand;
            rimani.VerticalOptions= LayoutOptions.Start;
            rimani.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked()),
            });
            stack8.Children.Add(rimani);

            Grid.SetRow(stack8, 6);
            Grid.SetColumn(stack8, 1);
            Grid.SetColumnSpan(stack8, 4);
            grid.Children.Add(stack8);

            //BUTTON LOGIN
            login = new Button();
            login.CornerRadius = 20;
            login.Text = LangAppResources.login;
            login.BackgroundColor = Color.FromHex("ff4a00");
            login.TextColor = Color.White; ; 
            login.HorizontalOptions = LayoutOptions.FillAndExpand;
            login.VerticalOptions = LayoutOptions.FillAndExpand;

            Button login2 = new Button();
            login2.CornerRadius = 20;
            login2.Text = LangAppResources.login;
            login2.BackgroundColor = Color.FromHex("ff4a00");
            login2.TextColor = Color.White; ;
            login2.HorizontalOptions = LayoutOptions.FillAndExpand;
            login2.VerticalOptions = LayoutOptions.FillAndExpand;
            login2.Clicked += ButtonClickedLogin;

            Grid.SetRow(login, 7);
            Grid.SetColumn(login, 1);
            Grid.SetColumnSpan(login, 3);
            grid.Children.Add(login);

            Grid.SetRow(login2, 7);
            Grid.SetColumn(login2, 1);
            Grid.SetColumnSpan(login2, 3);
            grid.Children.Add(login2);




            //BUTTON REGISTRATI
            signup = new Button();
            signup.CornerRadius = 20;
            signup.Text = LangAppResources.signup;
            signup.BackgroundColor = Color.White; 
            signup.TextColor = Color.FromHex("ff4a00");
            signup.BorderColor = Color.FromHex("ff4a00");
            signup.BorderWidth = 2;
            signup.HorizontalOptions = LayoutOptions.FillAndExpand;
            signup.VerticalOptions = LayoutOptions.FillAndExpand;

            Button signup2 = new Button();
            signup2.CornerRadius = 20;
            signup2.Text = LangAppResources.signup;
            signup2.BackgroundColor = Color.White;
            signup2.TextColor = Color.FromHex("ff4a00");
            signup2.BorderColor = Color.FromHex("ff4a00");
            signup2.BorderWidth = 2;
            signup2.HorizontalOptions = LayoutOptions.FillAndExpand;
            signup2.VerticalOptions = LayoutOptions.FillAndExpand;
            signup2.Clicked += ButtonClickedSignin;

            Grid.SetRow(signup, 8);
            Grid.SetColumn(signup, 1);
            Grid.SetColumnSpan(signup, 3);
            grid.Children.Add(signup); 
            
            Grid.SetRow(signup2, 8);
            Grid.SetColumn(signup2, 1);
            Grid.SetColumnSpan(signup2, 3);
            grid.Children.Add(signup2);



            Content = grid;
        }

        public async void ButtonClickedLogin(object sender, EventArgs e)
        {
            if (nick.Text != null && pass != null)
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
                    string url = "http://pinexp.altervista.org/Scommesse/User/GetAutenticazione.php/?Name=" + us.Nome + "&Password" + us.Password;
                    WebRequest req = WebRequest.Create(url);
                    var risposta = req.GetResponse();

                    string url2 = "http://pinexp.altervista.org/Scommesse/Schedine/Insert.php/?Name=" + us.Nome + "&Giocate=0&Vinte=0";
                    WebRequest req2 = WebRequest.Create(url2);
                    var risposta2 = req2.GetResponse();

                    StreamReader sr = new StreamReader(risposta.GetResponseStream());
                    string risp = sr.ReadLine();

                    StreamReader sr2 = new StreamReader(risposta2.GetResponseStream());
                    string risp2 = sr2.ReadLine();

                    if (risp == "OK" && risp2 == "OK")
                    {
                        act.IsRunning = true;
                        DatabaseUser dbu = new DatabaseUser(); await dbu.CreateTableUser();
                        await dbu.InsUser(us);
                        await Task.Delay(6000);
                        sr.Close();
                        sr.Close();
                        Preferences.Set("Nome", us.Nome);
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await DisplayAlert("Errore", "Username o password non validi!", "OK");
                        nick.Text = "";
                        pass.Text = "";
                        nick.Placeholder = "Inserisci il tuo Username";
                        pass.Placeholder = "Inserisci la tua password";
                    }
                }
                else
                {
                    await DisplayAlert("Errore", "Inserire un Username e una password validi", "OK");
                    nick.Text = "";
                    pass.Text = "";
                    nick.Placeholder = "Inserisci il tuo Username";
                    pass.Placeholder = "Inserisci la tua password";
                }
            }
            else
            {
                await DisplayAlert("Errore", "Inserire un Username e una password validi", "OK");
                nick.Text = "";
                pass.Text = "";
                nick.Placeholder = "Inserisci il tuo Username";
                pass.Placeholder = "Inserisci la tua password";
            }

        }

        public async void ButtonClickedSignin(object sender, EventArgs e)
        {
            if (nick.Text != null && pass != null)
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
                    string url = "http://pinexp.altervista.org/Scommesse/User/Insert.php/?Name=" + us.Nome + "&Password=" + us.Password + "&Saldo=100";
                    WebRequest req = WebRequest.Create(url);
                    var risposta = req.GetResponse();

                    string url2 = "http://pinexp.altervista.org/Scommesse/Schedine/Insert.php/?Name=" + us.Nome + "&Giocate=0&Vinte=0";
                    WebRequest req2 = WebRequest.Create(url2);
                    var risposta2 = req2.GetResponse();

                    StreamReader sr = new StreamReader(risposta.GetResponseStream());
                    string risp = sr.ReadLine();

                    StreamReader sr2 = new StreamReader(risposta2.GetResponseStream());
                    string risp2 = sr2.ReadLine();

                    if (risp == "OK" && risp2 == "OK")
                    {
                        act.IsRunning = true;
                        DatabaseUser dbu = new DatabaseUser(); await dbu.CreateTableUser();
                        await dbu.InsUser(us);
                        await Task.Delay(6000);
                        sr.Close();
                        sr.Close();
                        Preferences.Set("Nome", us.Nome);
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await DisplayAlert("Errore", "NickName già scelto!", "OK");
                        nick.Text = "";
                        pass.Text = "";
                        nick.Placeholder = "Inserisci il tuo Username";
                        pass.Placeholder = "Inserisci la tua password";
                    }
                }
                else
                {
                    await DisplayAlert("Errore", "Inserire un NickName valido", "OK");
                    nick.Text = "";
                    pass.Text = "";
                    nick.Placeholder = "Inserisci il tuo Username";
                    pass.Placeholder = "Inserisci la tua password";
                }
            }
            else
            {
                await DisplayAlert("Errore", "Inserire un NickName valido", "OK");
                nick.Text = "";
                pass.Text = "";
                nick.Placeholder = "Inserisci il tuo Username";
                pass.Placeholder = "Inserisci la tua password";
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
    }
}