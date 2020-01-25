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
    public class EliminarCanciones : ContentPage
    {
        ListView listView;
        private Button btnEliminar;
        Cancion cancion = new Cancion();
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "cancionesDB.db3");

        public EliminarCanciones()
        {
            this.Title = "Eliminar Canción";
            var db = new SQLiteConnection(ruta);
            StackLayout stackLayout = new StackLayout();
            listView = new ListView();
            listView.ItemsSource = db.Table<Cancion>().OrderBy(x => x.Nombre).ToList();
            listView.ItemSelected += ListView_ItemSelected;
            stackLayout.Children.Add(listView);
            
            btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.Clicked += BtnEliminar_Clicked;
            
            stackLayout.Children.Add(btnEliminar);
            
            Content = stackLayout;
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(ruta);
            db.Table<Cancion>().Delete(x => x.Id == cancion.Id);
            await Navigation.PopAsync();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            cancion = (Cancion)e.SelectedItem;
        }
    }
}