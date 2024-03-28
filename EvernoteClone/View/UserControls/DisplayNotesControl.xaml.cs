using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EvernoteClone.View.UserControls
{
    /// <summary>
    /// Interaction logic for DisplayNotesControl.xaml
    /// </summary>
    public partial class DisplayNotesControl : UserControl
    {


        public Note Notes
        {
            get { return (Note)GetValue(NotesProperty); }
            set { SetValue(NotesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NotesProperty =
            DependencyProperty.Register("Notes", typeof(Note), typeof(DisplayNotesControl), new PropertyMetadata(null,SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DisplayNotesControl displayNotesControl = d as DisplayNotesControl;
            if (displayNotesControl != null)
            {
                displayNotesControl.DataContext= displayNotesControl.Notes;
            }
            
        }

        public DisplayNotesControl()
        {
            InitializeComponent();
        }
    }
}
