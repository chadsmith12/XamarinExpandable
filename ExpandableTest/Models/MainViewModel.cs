using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpandableTest.Models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _headerSelectedComand;

        public MainViewModel()
        {
            var selectedCategories = GenerateDataItems()
                .Select(x => new SelectCategoryViewModel {Category = x.Category, Selected = false}).GroupBy(sc => new {sc.Category.CategoryId}).Select(g => g.First()).ToList();

            Categories = new ObservableCollection<ObservableGroup<SelectCategoryViewModel, Item>>();
            foreach (var item in selectedCategories)
            {
                Categories.Add(new ObservableGroup<SelectCategoryViewModel, Item>(item, new List<Item>()));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ObservableGroup<SelectCategoryViewModel, Item>> Categories { get; set; }

        public ICommand HeaderSelectedCommand => _headerSelectedComand ?? (_headerSelectedComand = new Command<ObservableGroup<SelectCategoryViewModel, Item>>((group) =>
        {
            if (group == null)
            {
                return;
            }

            group.Key.Selected = !group.Key.Selected;
            if (group.Key.Selected)
            {
                var items = GenerateDataItems().Where(item => item.Category.CategoryId == group.Key.Category.CategoryId);
                foreach (var groupItem in items)
                {
                    group.Add(groupItem);
                }
            }
            else
            {
                group.Clear();
            }
        }));

        public IList<Item> GenerateDataItems()
        {
            var category1 = new Category {CategoryId = 1, CategoryTitle = "Category 1"};
            var category2 = new Category { CategoryId = 2, CategoryTitle = "Category 2" };
            var category3 = new Category { CategoryId = 3, CategoryTitle = "Category 3" };
            var category4 = new Category { CategoryId = 4, CategoryTitle = "Category 4" };
            var category5 = new Category { CategoryId = 5, CategoryTitle = "Category 5" };
            var dataItems = new ObservableCollection<Item>()
            {
                new Item
                {
                    ItemId = 1,
                    ItemTitle = "Item 1",
                    Category = category1
                },
                new Item
                {
                    ItemId = 2,
                    ItemTitle = "Item 2",
                    Category = category1
                },
                new Item
                {
                    ItemId = 3,
                    ItemTitle = "Item 3",
                    Category = category2
                },
                new Item
                {
                    ItemId = 4,
                    ItemTitle = "Item 4",
                    Category = category2
                },
                new Item
                {
                    ItemId = 5,
                    ItemTitle = "Item 5",
                    Category = category3
                },
                new Item
                {
                    ItemId = 6,
                    ItemTitle = "Item 6",
                    Category = category4
                },
                new Item
                {
                    ItemId = 7,
                    ItemTitle = "Item 7",
                    Category = category5
                },
                new Item
                {
                    ItemId = 8,
                    ItemTitle = "Item 8",
                    Category = category5
                },
            };

            return dataItems;
        }
    }
}
