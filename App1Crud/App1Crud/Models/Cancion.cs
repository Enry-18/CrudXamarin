using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1Crud.Models
{
    public class Cancion
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }

        public override string ToString()
        {
            return this.Nombre + ", " + this.Artista + "( " + this.Album + " )";
        }

    }
}
