using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;


namespace PizzaApp
{
    public partial class MainPage : ContentPage
    {
        List<Pizza> pizza;
        public MainPage()
        {
            InitializeComponent();
            // string PizzaJson = "[{\"nom\":\"4 fromages\",\"ingredients\":[\"cantal\",\"mozzarella\",\"fromage de chèvre\",\"gruyère\"],\"prix\":11,\"imageUrl\":\"https://www.galbani.fr/wp-content/uploads/2017/07/pizza_filant_montage_2_3.jpg\"},{\"nom\":\"tartiflette\",\"ingredients\":[\"pomme de terre\",\"oignons\",\"crème fraiche\",\"lardons\",\"mozzarella\"],\"prix\":14,\"imageUrl\":\"https://cdn.pizzamatch.com/1/35/1375105305-pizza-napolitain-630.JPG?1375105310\"},{\"nom\":\"margherita\",\"ingredients\":[\"sauce tomate\",\"mozzarella\",\"basilic\"],\"prix\":7,\"imageUrl\":\"https://www.misteriosocultos.com/wp-content/uploads/2018/12/pizza.jpg\"},{\"nom\":\"indienne\",\"ingredients\":[\"curry\",\"mozzarella\",\"poulet\",\"poivron\",\"oignon\",\"coriandre\"],\"prix\":10,\"imageUrl\":\"https://assets.afcdn.com/recipe/20160519/15342_w1024h768c1cx3504cy2338.jpg\"},{\"nom\":\"mexicaine\",\"ingredients\":[\"boeuf\",\"mozzarella\",\"maïs\",\"tomates\",\"oignon\",\"coriandre\"],\"prix\":13,\"imageUrl\":\"https://fac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2FFAC.2Fvar.2Ffemmeactuelle.2Fstorage.2Fimages.2Fminceur.2Fastuces-minceur.2Fminceur-choix-pizzeria-47943.2F14883894-1-fre-FR.2Fminceur-comment-faire-les-bons-choix-a-la-pizzeria.2Ejpg/750x562/quality/80/crop-from/center/minceur-comment-faire-les-bons-choix-a-la-pizzeria.jpeg\"},{\"nom\":\"chèvre et miel\",\"ingredients\":[\"miel\",\"mozzarella\",\"fromage de chèvre\",\"roquette\"],\"prix\":10,\"imageUrl\":\"http://gfx.viberadio.sn/var/ezflow_site/storage/images/news/conso-societe/les-4-aliments-a-eviter-de-consommer-le-soir-00018042/155338-1-fre-FR/Les-4-aliments-a-eviter-de-consommer-le-soir.jpg\"},{\"nom\":\"napolitaine\",\"ingredients\":[\"sauce tomate\",\"mozzarella\",\"anchois\",\"câpres\"],\"prix\":9,\"imageUrl\":\"https://www.fourchette-et-bikini.fr/sites/default/files/pizza_tomate_mozzarella.jpg\"},{\"nom\":\"kebab\",\"ingredients\":[\"poulet\",\"oignons\",\"sauce tomate\",\"sauce kebab\",\"mozzarella\"],\"prix\":11,\"imageUrl\":\"https://res.cloudinary.com/serdy-m-dia-inc/image/upload/f_auto/fl_lossy/q_auto:eco/x_0,y_0,w_3839,h_2159,c_crop/w_576,h_324,c_scale/v1525204543/foodlavie/prod/recettes/pizza-au-chorizo-et-fromage-cheddar-en-grains-2421eadb\"},{\"nom\":\"louisiane\",\"ingredients\":[\"poulet\",\"champignons\",\"poivrons\",\"oignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":12,\"imageUrl\":\"http://www.fraichementpresse.ca/image/policy:1.3167780:1503508221/Pizza-dejeuner-maison-basilic-et-oeufs.jpg?w=700&$p$w=13b13d9\"},{\"nom\":\"orientale\",\"ingredients\":[\"merguez\",\"champignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":11,\"imageUrl\":\"https://www.atelierdeschefs.com/media/recette-e30299-pizza-pepperoni-tomate-mozza.jpg\"},{\"nom\":\"hawaïenne\",\"ingredients\":[\"jambon\",\"ananas\",\"sauce tomate\",\"mozzarella\"],\"prix\":12,\"imageUrl\":\"https://www.atelierdeschefs.com/media/recette-e16312-pizza-quatre-saisons.jpg\"},{\"nom\":\"reine\",\"ingredients\":[\"jambon\",\"champignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":8,\"imageUrl\":\"https://static.cuisineaz.com/400x320/i96018-pizza-reine.jpg\"}]";
            pizza = new List<Pizza>();
            const string Url = "https://drive.google.com/uc?export=download&id=1m-3sjysS92xF5taIrZXUdgePqOTIL3LN";
           // string Pizzajson = "";

            
            
                using (var webclient = new WebClient())
                {
                try
                {
                    // Pizzajson = webclient.DownloadString(Url);
                    webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                    {
                        Console.WriteLine("Donnees telecharger" +e.Result);
                        string Pizzajson = e.Result;
                        pizza = JsonConvert.DeserializeObject<List<Pizza>>(Pizzajson);

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            
                            Listview.ItemsSource = pizza;
                        });

                       
                    };
                   webclient.DownloadStringAsync(new Uri(Url));
                }
                catch(Exception ex)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Erreur", "une erereur s'est produite:" + ex.Message, "OK");
                    });

                    return;
                    
                }





                }
            
           
           
                
             
          // pizza = JsonConvert.DeserializeObject<List<Pizza>>(Pizzajson);


            
            /*pizza.Add(new Pizza { Nom = "vegetarienne", Prix = 4, Ingredients = new string[] { "tomate", "poivron", "oigon" },imgurl= "https://media-cdn.tripadvisor.com/media/photo-s/1b/bc/a6/c1/pizza-vegetarienne.jpg" });
            pizza.Add(new Pizza { Nom = "montagnarde", Prix = 5, Ingredients = new string[] { "reblochon", "pomme de terre", "oigon" ," creme fraiche" }, imgurl= "https://de.rc-cdn.community.thermomix.com/recipeimage/c8thrbj4-e380a-276301-cfcd2-h0fzvgm0/af7d6164-da56-4a82-8279-b7e8d1d0a1f4/main/pizza-mozzarella-tomate.jpg" });
            pizza.Add(new Pizza { Nom = "Carnivore", Prix = 5, Ingredients = new string[] { "tomate" , "viande hachee", "mozarella" }, imgurl= "https://www.greekgoesketo.com/img_3754/" });*/


           // Listview.ItemsSource= pizza;


        }

        private void Webclient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
