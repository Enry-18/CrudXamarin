using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1Crud.Views
{
    public class Principal : ContentPage
    {
        public Principal()
        {
            this.Title = "Opciones";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Agregar";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);
           

            Button btnVer = new Button();
            btnVer.Text = "Lista de canciones";
            btnVer.Clicked += Button_Ver_Clicked;
            stackLayout.Children.Add(btnVer);

            Button btnEditar = new Button();
            btnEditar.Text = "Editar";
            btnEditar.Clicked += Button_Editar_Clicked;
            stackLayout.Children.Add(btnEditar);

            Button btnELiminar = new Button();
            btnELiminar.Text = "Eliminar canción";
            btnELiminar.Clicked += Button_ELiminar_Clicked;
            stackLayout.Children.Add(btnELiminar);


            Content = stackLayout;
        }

        private async void Button_ELiminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarCanciones());
        }

        private async void Button_Editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarCanciones());
        }

        private async void Button_Ver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCanciones());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarCancion());
        }
    }
}