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
using Delus.Components;
namespace Delus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        AgentDelusEntities _context = new AgentDelusEntities();
        public AgentPage()
        {
            InitializeComponent();
            List<AgentType> listGenres = _context.AgentType.ToList();
            listGenres.Insert(0, new AgentType { Title = "Все типы" });
            TypeSortCb.ItemsSource = listGenres;
            TypeSortCb.SelectedIndex = 0;
            RefreshData();
            //ListProduct.ItemsSource = DBConnect.db.Agent.ToList();
           
        }
        private void RefreshData()
        {
            List<Agent> listBooks = _context.Agent.ToList();
            if (TypeSortCb.SelectedIndex != 0)
            {
                AgentType selectedGenre = (AgentType)TypeSortCb.SelectedItem;
                listBooks = listBooks.Where(x => x.AgentTypeID == selectedGenre.ID).ToList();
            }

            if (SortCb.SelectedItem != null)
            {
                switch ((SortCb.SelectedItem as ComboBoxItem).Tag)
                {
                  
                    case "1":

                        listBooks = listBooks.OrderBy(x => x.Title).ToList();
                        listBooks = listBooks.OrderBy(x => x.proc).ToList();
                        listBooks = listBooks.OrderBy(x => x.Priority).ToList();
                        break;
                    case "2":

                        listBooks = listBooks.OrderByDescending(x => x.Title).ToList();
                        listBooks = listBooks.OrderByDescending(x => x.proc).ToList();
                        listBooks = listBooks.OrderByDescending(x => x.Priority).ToList();

                        break;
                   

                }

            }
            var searchString = NameDisSearchTb.Text;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listBooks = listBooks.Where(x => x.Title.ToLower().Contains(searchString.ToLower()) || x.Email.ToLower().Contains(searchString.ToLower()) || x.Phone.ToLower().Contains(searchString.ToLower())).ToList();
            }
            //listDishes = listDishes.OrderByDescending(x => x.ServingPrice).ToList();
            ListProduct.ItemsSource = listBooks;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TypeSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DBConnect.db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                ListProduct.ItemsSource = DBConnect.db.Agent.ToList();
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selBook = (sender as Button).DataContext as Agent;
            Navigation.NextPage(new Nav("Редактирование агента", new AddEditAgent(selBook)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selBook = (sender as Button).DataContext as Agent;
            if (MessageBox.Show("Вы точно хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var inredientStagesToRemove = DBConnect.db.ProductSale.Where(ios => ios.AgentID == selBook.ID);
                DBConnect.db.ProductSale.RemoveRange(inredientStagesToRemove);

                DBConnect.db.Agent.Remove(selBook);
                DBConnect.db.SaveChanges();
                MessageBox.Show("Данные удалены");
                ListProduct.ItemsSource = DBConnect.db.Agent.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Добавление агента", new AddEditAgent(new Agent())));
        }
    }
}
