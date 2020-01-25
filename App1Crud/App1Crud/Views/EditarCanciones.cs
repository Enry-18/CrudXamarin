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
    public class EditarCanciones : ContentPage
    {
        private ListView listView;
        private Entry idEntry;
        private Entry nombreEntry;
        private Entry artistaEntry;
        private Entry albumEntry;
        private Button btnGuardar;
        Cancion cancion = new Cancion();
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "cancionesDB.db3");


        public EditarCanciones()
        {
            this.Title = "Editar Información";
            
            var db = new SQLiteConnection(ruta);
            
            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Cancion>().OrderBy(x => x.Nombre).ToList();
            listView.ItemSelected += ListView_ItemSelected;
            stackLayout.Children.Add(listView);

            idEntry = new Entry();
            idEntry.Placeholder = "Id";
            idEntry.IsVisible = false;
            stackLayout.Children.Add(idEntry);

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
            btnGuardar.Text = "Actualizar";
            btnGuardar.Clicked += BtnGuardar_Clicked;
            stackLayout.Children.Add(btnGuardar);

            Content = stackLayout;
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(ruta);
            Cancion cancion = new Cancion()
            {
                Id = Convert.ToInt32(idEntry.Text),
                Nombre = nombreEntry.Text,
                Artista = artistaEntry.Text,
                Album = albumEntry.Text
            };
            db.Update(cancion);
            await Navigation.PopAsync();

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            cancion = (Cancion) e.SelectedItem;
            idEntry.Text = cancion.Id.ToString();
            nombreEntry.Text = cancion.Nombre;
            artistaEntry.Text = cancion.Artista;
            albumEntry.Text = cancion.Album;
        }
    }
}