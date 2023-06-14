using Delus.Components;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Delus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditAgent.xaml
    /// </summary>
    public partial class AddEditAgent : Page
    {
        Components.Agent agent;
        public AddEditAgent(Components.Agent _agent)
        {
            InitializeComponent();
            agent = _agent;
            DataContext = agent;
            TypeCb.ItemsSource = DBConnect.db.AgentType.ToList();
            TypeCb.DisplayMemberPath = "Title";
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog()
            //{
            //    Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            //};
            //if (openFileDialog.ShowDialog().GetValueOrDefault())
            //{
            //    agent.Logo = Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName));
            //    AgentImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            //}
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                agent.Logo = imagePath;
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                AgentImage.Source = bitmap;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (agent.ID == 0)
            {
                DBConnect.db.Agent.Add(agent);

            }

            DBConnect.db.SaveChanges();
            MessageBox.Show("Успешно сохранено!");
            Navigation.BackPage();
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
