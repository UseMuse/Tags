using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tags.ViewModel
{
    public class ViewModelMain : BaseInpc
    {
        public ObservableCollection<ViewModelTag> Tags { get; }
            = new ObservableCollection<ViewModelTag>();

        private ObservableCollection<ViewModelTag> _selectedTags;
        public ObservableCollection<ViewModelTag> SelectedTags
        {
            get => _selectedTags;
            private set => Set(ref _selectedTags, value);
        }
        private ViewModelTag _selectedTag = ViewModelTag.FirstTag;
        public ViewModelTag SelectedTag
        {
            get => _selectedTag;
            set => Set(ref _selectedTag, value);
        }
        private string toolTipSelectedTags = string.Empty;
        public string ToolTipSelectedTags
        {
            get => toolTipSelectedTags;
            set => Set(ref toolTipSelectedTags, value);
        }

       
        public ViewModelMain()
        {
            Tags.Add(ViewModelTag.FirstTag);
            for (int i = 1; i < 300; i++)
            {
                var t = new ViewModelTag($"Тег {i:000}");
                t.Checked += T_Checked;
                t.Unchecked += T_Checked;
                Tags.Add(t);
            }



            DropDownClosedCommand = new RelayCommand((object parameter) =>
            {
                var selectedTag = Tags.Where(t => t.IsEnabled && t.IsChecked);
                SelectedTags = new ObservableCollection<ViewModelTag>(selectedTag);
            });

            SelectionChangedCommand = new RelayCommand((object parameter) =>
            {


            });

        }

        private void T_Checked()
        {
            var ts = Tags.Where(t => t.IsEnabled && t.IsChecked);
            if (ts.Any())
            {
                ViewModelTag.FirstTag.IsChecked = true;
                ToolTipSelectedTags = string.Join(",", ts.Select(t => t.Title));
            }
            else
            {
                ViewModelTag.FirstTag.IsChecked = false;
                ToolTipSelectedTags = string.Empty;
            }
        }

        public ICommand SelectionChangedCommand { get; set; }
        public ICommand DropDownClosedCommand { get; set; }
    }
}
