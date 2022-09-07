using PizzaApp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Models
{
    public  class Pizza
    {
        public string imageUrl { get; set; }
        public string Nom { get; set; }
        public int Prix { get; set; }
        public string[] Ingredients { get; set; }

        public string Prixeuros { get { return Prix + "€"; } }
        public string Ingredientstr { get { return String.Join(", " ,Ingredients); } }
        public string titre { get { return Nom.Firstletter(); } }


    }
}
