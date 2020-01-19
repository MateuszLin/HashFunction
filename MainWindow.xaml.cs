using Haszownie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Haszownie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Hash hash = new Hash(113);
        private ObservableCollection<PersonGrid> data = new ObservableCollection<PersonGrid>();

        public MainWindow()
        {
            InitializeComponent();
            SampleData();
            PrepareGid();
        }


        private void PrepareGid()
        {
            for (int i = 0; i < hash.Items.Length; i++)
            {
                PersonGrid newData;

                var item = hash.Items[i];

                if (item != null)
                {
                    var keyAndValue = item.First();

                    newData = new PersonGrid()
                    {
                        Content = (keyAndValue.Value as Person).GetContent(),
                        Index = keyAndValue.Key
                    };
                }
                else
                {
                    newData = new PersonGrid()
                    {
                        Content = "EMPTY",
                        Index = i
                    };
                }

                data.Add(newData);
            }

            dataGrid.ItemsSource = data;
        }

        private void SampleData()
        {
            Person per = new Person()
            {
                Name = "Mateusz",
                Pesel = "94062704976",
                Surname = "Lin"
            };

            hash.Add(per);
        }

        private void AddNewPerson()
        {
            string pesel = peselTb.Text;

            if(!string.IsNullOrWhiteSpace(pesel))
            {
                Person person = new Person()
                {
                    Pesel = pesel,
                    Name = nameTb.Text,
                    Surname = surnameTb.Text
                };

                var position = hash.Add(person);
                AddNewPersonToItemsSouce(position, person);
                FocusRow(position);
            }
        }

        private void AddNewPersonToItemsSouce(int position, Person person)
        {
            data[position] = new PersonGrid()
            {
                Content = person.GetContent(),
                Index = position
            };
        }

        private void FindAndFocus()
        {
            string pesel = peselFindTb.Text;
            if (!string.IsNullOrWhiteSpace(pesel))
            {
                var position = hash.FindAndReturnPosition(pesel);

                if(position.HasValue)
                {
                    FocusRow(position.Value);
                }
            }
        }

        private void DeleteFromItemsSource(int position)
        {
            data[position] = new PersonGrid()
            {
                Index = position,
                Content = "EMPTY"
            };
        }

        private void RemovePerson()
        {
            var pesel = peselRemoveTb.Text;
            if (!string.IsNullOrWhiteSpace(pesel))
            {
                var position = hash.Remove(pesel);
                if (position.HasValue)
                {
                    DeleteFromItemsSource(position.Value);
                    FocusRow(position.Value);
                }
            }
        }

        private void FocusRow(int index)
        {
            var item = dataGrid.Items[index];
            dataGrid.SelectedItem = item;
            dataGrid.ScrollIntoView(item);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewPerson();
        }

        private void removebtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            FindAndFocus();
        }

        private void removebtn_Click(object sender, RoutedEventArgs e)
        {
            RemovePerson();
        }


    }
}
