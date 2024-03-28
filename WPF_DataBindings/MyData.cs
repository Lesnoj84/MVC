using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DataBindings
{
    public class MyData : INotifyPropertyChanged
    {
		private string setColor;

		public string SetColor
		{
			get { return setColor; }
			set { setColor = value;
				OnPropertyChanged();
			}
		}

       

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string property = null)
        {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }



    }
}
