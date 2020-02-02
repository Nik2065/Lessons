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
using HelloWpf.Entities;

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialiseLists();
        }

        private void InitialiseLists()
        {
            Store.DepartmentList = new List<Department>();
            Store.DepartmentList.Add(new Department { Id = 0, Name = "Департамент 1" });
            Store.DepartmentList.Add(new Department { Id = 1, Name = "Департамент 2" });
            Store.DepartmentList.Add(new Department { Id = 2, Name = "Департамент 3" });

            Store.EmployeeList = new List<Employee>();
            Store.EmployeeList.Add(new Employee { Id = 0, Name = "Василий Петрович" });
            Store.EmployeeList.Add(new Employee { Id = 1, Name = "Леонид Васильевич" });
            Store.EmployeeList.Add(new Employee { Id = 2, Name = "Александр Антонович" });
        }


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnDepartmenItem_Click(object sender, RoutedEventArgs e)
        {
            var depW = new DepartmentWindow();
            depW.ShowDialog();
        }

        private void BtnEmployeeItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeWindow();
            window.ShowDialog();
        }
    }
}
