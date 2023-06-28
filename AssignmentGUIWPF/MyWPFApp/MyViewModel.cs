using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using MyWPFApp;
using System.Linq;
using System.Windows;

namespace MyWPFApp
{

    class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees 
        {
            get { return employees; }
            set
            {
                employees = value;
               this.RaisePropertyChanged(nameof(Employees));
            }
                
        }
        public Employee SelectedEmployee { get; set; }
        public RelayCommand AddButton { get; set; }
        public RelayCommand DeleteButton { get; set; }
        public int SearchId { get; set; }
        private string nameSearch;

        public string NameSearch
        {
            get { return nameSearch;; }
            set { nameSearch = value;
                RaisePropertyChanged(nameof(NameSearch));
            }
        }

        public RelayCommand SearchByNameCommand { get; set; }
        public RelayCommand SearchByIdCommand { get; set; }
        public RelayCommand ClearSearch { get; set; }
        private string newName;

        public string NewName
        {
            get { return newName; }
            set { newName = value;
                RaisePropertyChanged(nameof(NewName));
            }
        }
        private int newId;

        public int NewId
        {
            get { return newId; }
            set { newId = value;
                RaisePropertyChanged(nameof(NewId));
            }
        }
        private DateTime newDob;

        public DateTime NewDob
        {
            get { return newDob; }
            set { newDob = value;
                RaisePropertyChanged(nameof(NewDob));
            }
        }
        private Visibility addVisibility;

        public Visibility AddVisibility
        {
            get { return addVisibility; }
            set
            {
                addVisibility = value;
                RaisePropertyChanged(nameof(AddVisibility));
            }
        }
        public RelayCommand AddEmployeeButton { get; set; }

        public RelayCommand CancelAddEmployeeButton { get; set; }



        public MyViewModel()
        {
            Employees = new ObservableCollection<Employee>(){ new Employee(){Id = 1, Name="Sagar", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 2, Name="Abhijeet", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 3, Name="Sayali", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 4, Name="Kajol", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 5, Name="Vishal", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 6, Name="Sakshi", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 7, Name="Naman", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 8, Name="Asmita", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 9, Name="Mudit", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 10, Name="Rohit", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 11, Name="Karan", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 12, Name="Pranit", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 13, Name="Rajat", Dob = new DateTime(2022, 06, 25)},
                                                            };

            AddVisibility = Visibility.Collapsed;
            AddButton = new RelayCommand(AddEmployee, CanAddEmployee);
            DeleteButton = new RelayCommand(DeleteEmployee, CanDeleteEmployee);
            SearchByIdCommand = new RelayCommand(SearchEmpId, CanSearchId);
            SearchByNameCommand = new RelayCommand(SearchByName, CanSearchByName);
            ClearSearch = new RelayCommand(ClearAllSearch, CanClear);
            AddEmployeeButton = new RelayCommand(AddNew, CanAddNew);
            CancelAddEmployeeButton = new RelayCommand(CancelAddButton, CanCancelAddButton);
        }

        private bool CanCancelAddButton(object arg)
        {
            return true;
        }

        private void CancelAddButton(object obj)
        {
            this.AddVisibility = Visibility.Collapsed;
        }

        public void AddNew(object o)
        {
            Employee employee = new Employee() { Name = this.NewName, Dob = this.NewDob, Id = this.NewId};
            employees.Add(employee);
            this.NewName = string.Empty;
            this.NewId = 0;
        }
        public bool CanAddNew(object pa)
        {
            if(this.newName!=string.Empty)
            {
                return true;
            }
            return false;
        }
        public void ClearAllSearch(object parameter)
        {
            this.SearchId=0;
            this.NameSearch=string.Empty;
            getAllEmployees();
        }
        public void getAllEmployees()
        {
            this.Employees  = new ObservableCollection<Employee>() { new Employee(){Id = 1, Name="Sagar", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 2, Name="Abhijeet", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 3, Name="Sayali", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 4, Name="Kajol", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 5, Name="Vishal", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 6, Name="Sakshi", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 7, Name="Naman", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 8, Name="Asmita", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 9, Name="Mudit", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 10, Name="Rohit", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 11, Name="Karan", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 12, Name="Pranit", Dob = new DateTime(2022, 06, 25)},
                                                            new Employee(){Id = 13, Name="Rajat", Dob = new DateTime(2022, 06, 25)},
                                                            };
        }

        public bool CanClear(object parameter)
        {
            return true;
        }

        public void SearchEmpId(object parameter)
        {
            var v = Employees.Where(x => x.Id==this.SearchId);
            
        }

        public bool CanSearchId(object parameter)
        {
            return true;
        }
        public void SearchByName(object parameter)
        {
            
            var vs = Employees.Where(x => x.Name.Contains(this.NameSearch)).ToList();
            Employees = new ObservableCollection<Employee>(vs);
        }

        public bool CanSearchByName(object parameter)
        {
            return true;
        }

        public void AddEmployee(object parameter)
        {
            this.AddVisibility = Visibility.Visible;
        }

        public bool CanAddEmployee(object parameter)
        {
            return true;
        }

        public void DeleteEmployee(object parameter)
        {
            Employees.Remove(SelectedEmployee);
        }

        public bool CanDeleteEmployee(object parameter)
        {
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
    }
}