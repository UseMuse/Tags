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
        private ObservableCollection<ViewModelTag> _tags;
        public ObservableCollection<ViewModelTag> Tags
        {
            get => _tags;
            private set => Set(ref _tags, value);
        }

        private ObservableCollection<ViewModelTag> _selectedTags;
        public ObservableCollection<ViewModelTag> SelectedTags
        {
            get => _selectedTags;
            private set => Set(ref _selectedTags, value);
        }

        public ViewModelMain()
        {
            var t1 = new ViewModelTag("Тег 1");
            var t2 = new ViewModelTag("Тег 2");
            var t3 = new ViewModelTag("Тег 3");
            var tags = new List<ViewModelTag>() { ViewModelTag.FirstTag, t1, t2, t3 };

            Tags = new ObservableCollection<ViewModelTag>(tags);
            DropDownClosedCommand = new RelayCommand((object parameter) =>
            {
                var selectedTag = Tags.Where(t => t.IsChecked);
                SelectedTags = new ObservableCollection<ViewModelTag>(selectedTag);
            });
            SelectionChangedCommand = new RelayCommand((object parameter) =>
            {

               

            });

        }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand DropDownClosedCommand { get; set; }
    }
}
