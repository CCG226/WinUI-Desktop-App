using LetsGoDexTracker.PokemonModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoDexTracker.Service;
using LetsGoDexTracker.ViewModels.Commands;
using LetsGoDexTracker.ViewModels.DataAccess;

namespace LetsGoDexTracker.ViewModels
{
    public class UserDexVM: INotifyPropertyChanged//view model for the MyDex page
    {
        public ObservableCollection<Pokemon> myPokedex { get; set; }//list of all pokemon 

        private string caughtText;//text displayed at the top of the page about how many pokemon have been caught so far by the user 
        public string CaughtText
        {
            get { return caughtText; }
            set
            {
                caughtText = value;
                OnPropertyChanged("CaughtText");
            }
        }

        public int CaughtSoFar { get; set; }//count of pokemon caught so far 
       


        public UserDexVM()
        {
            myPokedex = PokemonDataAccess.Dex;//all pokemon displayed on listview 
            
            SelectedCommand = new SelectedCommand(this);//command for my custom checkbox
           
            
            foreach(Pokemon p in myPokedex)//count pokemon caught so far during intialization by iterating through every pokemon pokedex record from the database 
            {
                if(p.isChecked == "/Assets/isChecked.png")//if record has been isChecked image(green check mark) user must have checked them off an a previous run of the application
                {
                    CaughtSoFar++;//count if checked 
                }
            }
            CaughtText = $"Pokedex Count: {CaughtSoFar}/171";//display text of count 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }

        public void SwapMarks(Pokemon pokemon)//pokemon object is the pokemon objects checkboc that was clicked by user
        {
            if (pokemon.isChecked == "/Assets/isChecked.png")//if checked 
            {
                pokemon.isChecked = "/Assets/isNotChecked.png";//uncheck
                CaughtSoFar--;//decrement count of caught so far by one 
            }
            else//if unchecked
            {
                pokemon.isChecked = "/Assets/isChecked.png";//check 
                CaughtSoFar++;//increment count 
            }
            for(int i = 0; i < myPokedex.Count; i++)//find pokemon in the pokedex that's checkbox was clicked by matching ids
            {
                if(pokemon.Id == myPokedex[i].Id)
                {
                    myPokedex[i] = pokemon;//to update record 
                  
                }
            }
          
            OnPropertyChanged("myPokedex");
           
            CaughtText = $"Pokedex Count: {CaughtSoFar}/171";//update text
           
            PokemonDataAccess.DataUpdate(pokemon);//update database to save caughtSoFar information 
        }

        public SelectedCommand SelectedCommand { get; set; }

    }
}
