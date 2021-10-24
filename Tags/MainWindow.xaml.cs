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
using Tags.ViewModel;

namespace Tags
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int previousSelection = 0; //Give it a default selection value

        private bool promptUserForRollBackComboboxsSelectionPreviousOne = true;

        private void ComboboxTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            BindingExpression be = comboBox.GetBindingExpression(ComboBox.SelectedValueProperty);

            if (comboBox.SelectedValue != null && comboBox.SelectedIndex != previousSelection)
            {
                string msg = "Click Yes to leave previous selection, click No to stay with your selection.";
                if (promptUserForRollBackComboboxsSelectionPreviousOne
                    && MessageBox.Show(msg, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes == false)  //User have clicked No to cancel the selection
                {
                    comboBox.SelectedIndex = previousSelection; //roll back the combobox's selection to previous one

                }
                else //User want to go with the newest selection
                {
                    be?.UpdateSource(); //Update the property,so your ViewModel will continue to do something
                    previousSelection = (int)comboBox.SelectedIndex;
                }
            }
        }
    }
}
