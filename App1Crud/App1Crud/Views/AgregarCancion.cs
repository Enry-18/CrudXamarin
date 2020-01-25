using App1Crud.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1Crud.Views
{
    public class AgregarCancion : ContentPage
    {
        private Entry nombreEntry;
        private Entry artistaEntry;
        private Entry albumEntry;
        private Button btnGuardar;

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"cancionesDB.db3");
        public AgregarCancion()
        {
            this.Title = "Agregar";
            StackLayout stackLayout = new StackLayout();

            nombreEntry = new Entry();
            nombreEntry.Keyboard = Keyboard.Text;
            nombreEntry.Placeholder = "Nombre de la canción";
            stackLayout.Children.Add(nombreEntry);

            artistaEntry = new Entry();
            artistaEntry.Keyboard = Keyboard.Text;
            artistaEntry.Placeholder = "Nombre del artista";
            stackLayout.Children.Add(artistaEntry);

            albumEntry = new Entry();
            albumEntry.Keyboard = Keyboard.Text;
            albumEntry.Placeholder = "Nombre del álbum";
            stackLayout.Children.Add(albumEntry);

            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Clicked += BtnGuardar_Clicked;
            stackLayout.Children.Add(btnGuardar);
            Content = stackLayout;
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(ruta);
            db.CreateTable<Cancion>();
            var ultimaPK = db.Table<Cancion>().OrderByDescending(c => c.Id).FirstOrDefault();
            Cancion cancion = new Cancion
            {
                Id = (ultimaPK == null ? 1 : ultimaPK.Id + 1),
                Nombre = nombreEntry.Text,
                Artista = artistaEntry.Text,
                Album = albumEntry.Text
            };
            db.Insert(cancion);
            await DisplayAlert(null, cancion.Nombre + " Guardada correctamente", "Ok");
            await Navigation.PopAsync();
        }
    }
}