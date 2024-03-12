using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_DataBinding_II
{
    class PhoneDependencyObject : DependencyObject
    {
       

        public static readonly DependencyProperty PriceProperty;
        public static readonly DependencyProperty TitleProperty; 
        
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        static PhoneDependencyObject()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PhoneDependencyObject));
            
            FrameworkPropertyMetadata metadata = new();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(PhoneDependencyObject),metadata, new ValidateValueCallback(ValidateValue));


        }

        static int firstValueInput = 0;
        private static object CorrectValue(DependencyObject d, object baseValue)
        {

           

            if (firstValueInput==0)
            {
                firstValueInput = (int)d.GetValue(PriceProperty);
            }

            int currentValue = (int)baseValue;
            if (currentValue >= 1000) return 1000;
            else if (currentValue <= 0)
            {

                currentValue = firstValueInput;


                return currentValue ;

            }

            return currentValue;
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;

            if (currentValue >= 0) return true;
            else if (currentValue <= 0) return true;
         
            return false;

           
        }

    }
}
