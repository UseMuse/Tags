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
        private bool handleSelection = true;
        private void ComboboxTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                MessageBoxResult result = MessageBox.Show("Continue change?", "Continue change?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    ComboBox combo = (ComboBox)sender;
                    handleSelection = false;

                    if (e.RemovedItems.Count > 0)
                    {
                        combo.SelectedItem = e.RemovedItems[0];
                    }
                    else
                    {
                        combo.SelectedItem = null;

                        // тут планировался откат текста к тому, что был, но обновление почему-то не срабатывает...
                        combo.Text = "Теги";
                    }

                    return;
                }
            }
            handleSelection = true;
        }
        //private int previousSelection = 0; //Give it a default selection value

        //private bool promptUser = true; //to be replaced with your own property which will indicates whether you want to show the messagebox or not.

        //private void ComboboxTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;
        //    BindingExpression be = comboBox.GetBindingExpression(ComboBox.SelectedValueProperty);

        //    if (comboBox.SelectedValue != null && comboBox.SelectedIndex != previousSelection)
        //    {
        //        if (promptUser) //if you want to show the messagebox..
        //        {
        //            string msg = "Click Yes to leave previous selection, click No to stay with your selection.";
        //            if (MessageBox.Show(msg, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) //User want to go with the newest selection
        //            {

        //                be?.UpdateSource(); //Update the property,so your ViewModel will continue to do something
        //                previousSelection = (int)comboBox.SelectedIndex;
        //            }
        //            else //User have clicked No to cancel the selection
        //            {
        //                comboBox.SelectedIndex = previousSelection; //roll back the combobox's selection to previous one
        //            }
        //        }
        //        else //if don't want to show the messagebox, then you just have to update the property as normal.
        //        {
        //            be?.UpdateSource();
        //            previousSelection = (int)comboBox.SelectedIndex;
        //        }
        //    }
        //}

    }
}
