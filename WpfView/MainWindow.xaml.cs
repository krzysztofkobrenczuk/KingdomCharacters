using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WarriorsDomain.Classes;
using WarriorsDomain.DataModel;

namespace WpfView
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class MainWindow : Window
    {
        private readonly ConnectedRepository _repo = new ConnectedRepository();
        private Warrior _currentWarrior;
        private bool _isLoading;
        private bool _isWarriorListChanging;
       private ObjectDataProvider _warriorViewSource;
       // private CollectionViewSource _warriorViewSource;
        private ObservableCollection<WarriorEquipment> _observableEquipment
            = new ObservableCollection<WarriorEquipment>();



        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _isLoading = true;
            warriorListBox.ItemsSource = _repo.WarriorsInMemory();
            SortWarriorList();
            bloodComboBox.ItemsSource = _repo.GetBloodList();
            _warriorViewSource = ((ObjectDataProvider)(FindResource("warriorViewSource")));
           // _warriorViewSource = ((CollectionViewSource)(this.FindResource("warriorViewSource")));


           // System.Windows.Data.CollectionViewSource warriorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("warriorViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // warriorViewSource.Source = [generic data source]
           // System.Windows.Data.CollectionViewSource bloodViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bloodViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bloodViewSource.Source = [generic data source]
            warriorListBox.SelectedIndex = 0;
            _isLoading = false;

        }

        public void SortWarriorList()
        {
            var dataView =
                CollectionViewSource.GetDefaultView(warriorListBox.ItemsSource);

            dataView.SortDescriptions.Clear();
            var sd = new SortDescription("Name", ListSortDirection.Ascending);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
            warriorListBox.SelectedItem = _currentWarrior;
        }

        private void warriorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool continueProcess;

            if (_isLoading)
            {
                continueProcess = true;
            }
            else
            {
                continueProcess = ShouldRefresh;
            }
            if (!continueProcess) return;
            _currentWarrior = _repo.GetWarriorWithEquipment(
                  ((int)warriorListBox.SelectedValue)
                );
            RefreshWarrior();
            _isWarriorListChanging = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _repo.Save();
            SortWarriorList();
        }


        private bool ShouldRefresh
        {
            get
            {
                var continueProcess = true;
                if(_currentWarrior != null)
                {
                    if (_currentWarrior.isDirty)
                    {
                        switch(MessageBox.Show("Save current warrior?", "Warrior Entry", MessageBoxButton.YesNoCancel))
                        {
                            case MessageBoxResult.Cancel:
                                continueProcess = false;
                                break;
                            case MessageBoxResult.Yes:
                                _repo.Save();
                                break;
                            case MessageBoxResult.No:
                                break;

                        }
                    }
                }
                return
                    continueProcess;
            }
        }

        private void RefreshWarrior()
        {
            _isWarriorListChanging = true;
            
            _warriorViewSource.ObjectInstance = _currentWarrior;
            _observableEquipment = new ObservableCollection<WarriorEquipment>(_currentWarrior.EquipmentOwned);
            equipmentOwnedDataGrid.ItemsSource = _observableEquipment;
            _observableEquipment.CollectionChanged += EquipmentCollectionChanged;

            bloodComboBox.SelectedValue = _currentWarrior.BloodId;
            _currentWarrior.isDirty = false;
            _isWarriorListChanging = false;
        }

        //Because wpf can't guess if just want to remove equipment from Warrior or delete completely from database
        private void EquipmentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
             if(_isLoading || _isWarriorListChanging)
            {
                return;
            }
             if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                _repo.DeleteEquipment(e.OldItems);
                SetWarriorDirty();
            }
             if(e.Action == NotifyCollectionChangedAction.Add)
            {
                _currentWarrior.EquipmentOwned.AddRange(e.NewItems.Cast<WarriorEquipment>());
                SetWarriorDirty();
            }
        }


        private void equipmentOwnedDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetWarriorDirty();
        }


        private void SetWarriorDirty()
        {
            if(!_isLoading && !_isWarriorListChanging)
            {
                _currentWarrior.isDirty = true;
            }
        }

        private void bloodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(!_isLoading && !_isWarriorListChanging)
            {
                _currentWarrior.BloodId = (int)bloodComboBox.SelectedValue;
            }
            SetWarriorDirty();
        }

        private void btnNewWarrior_Click(object sender, RoutedEventArgs e)
        {
            if (ShouldRefresh)
            {
                _currentWarrior = _repo.NewWarrior();
                RefreshWarrior();
            }
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetWarriorDirty();
        }

        private void servedInKingdomCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetWarriorDirty();
        }
        private void servedInKingdomCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetWarriorDirty();
        }

        private void dateOfBirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetWarriorDirty();
        }
        private void equipmentOwnedDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            SetWarriorDirty();
        }
    }
}
