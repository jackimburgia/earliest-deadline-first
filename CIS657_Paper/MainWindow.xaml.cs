using CIS657_Paper.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CIS657_Paper.Utilities.UIExtensions;

// These websites are cited for "inspiration" for this implementation
// https://www.youtube.com/watch?v=ejPXTOcMRPA
// https://github.com/elzoughby/EDF-scheduling

namespace CIS657_Paper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            this.CycleTime.GotFocus += TextBox_GotFocus;
            this.Deadline.GotFocus += TextBox_GotFocus;
            this.ProcessingTime.GotFocus += TextBox_GotFocus;
            this.LCM.GotFocus += TextBox_GotFocus;

            this.CycleTime.PreviewMouseDown += TextBox_PreviewMouseDown;
            this.Deadline.PreviewMouseDown += TextBox_PreviewMouseDown;
            this.ProcessingTime.PreviewMouseDown += TextBox_PreviewMouseDown;
            this.LCM.PreviewMouseDown += TextBox_PreviewMouseDown;


        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var TextBox = (TextBox)sender;
            if (!TextBox.IsKeyboardFocusWithin)
            {
                TextBox.Focus();
                e.Handled = true;
            }
        }

    }
}


