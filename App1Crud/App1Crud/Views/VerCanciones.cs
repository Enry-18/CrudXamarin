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
    public class VerCanciones : ContentPage
    {
        private ListView listView;
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "cancionesDB.db3");

        public VerCanciones()
        {
            this.Title = "Música";
            var db = new SQLiteConnection(ruta);
            StackLayout stackLayout = new StackLayout();
            listView = new ListView();
            listView.ItemsSource = db.Table<Cancion>().OrderBy(x => x.Nombre).ToList();
            stackLayout.Children.Add(listView);
            Content = stackLayout;
        }
    }
}