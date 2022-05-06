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
    public class UserDexVM: INotifyPropertyChanged
    {
        public ObservableCollection<Pokemon> myPokedex { get; set; }

        private string caughtText;
        public string CaughtText
        {
            get { return caughtText; }
            set
            {
                caughtText = value;
                OnPropertyChanged("CaughtText");
            }
        }

        public int CaughtSoFar { get; set; }
       


        public UserDexVM()
        {
            myPokedex = PokemonDataAccess.Dex;
            
            SelectedCommand = new SelectedCommand(this);
           
            
            foreach(Pokemon p in myPokedex)
            {
                if(p.isChecked == "/Assets/isChecked.png")
                {
                    CaughtSoFar++;
                }
            }
            CaughtText = $"Pokedex Count: {CaughtSoFar}/171";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }

        public void SwapMarks(Pokemon pokemon)
        {
            if (pokemon.isChecked == "/Assets/isChecked.png")
            {
                pokemon.isChecked = "/Assets/isNotChecked.png";
                CaughtSoFar--;
            }
            else
            {
                pokemon.isChecked = "/Assets/isChecked.png";
                CaughtSoFar++;
            }
            for(int i = 0; i < myPokedex.Count; i++)
            {
                if(pokemon.Id == myPokedex[i].Id)
                {
                    myPokedex[i] = pokemon;
                  
                }
            }
          
            OnPropertyChanged("myPokedex");
           
            CaughtText = $"Pokedex Count: {CaughtSoFar}/171";
           
            PokemonDataAccess.DataUpdate(pokemon);
        }

        public SelectedCommand SelectedCommand { get; set; }

    }
}
