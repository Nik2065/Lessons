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
using System.Windows.Shapes;
using System.Linq;
using HelloWpf.Entities;

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for DepartmentsWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            LoadDepartmentList();
            LoadEmployeeList();
        }

        private void LoadDepartmentList()
        {
            var items = Store.DepartmentList;

            CbDepartments.Items.Clear();
            foreach (var department in items)
            {
                CbDepartments.Items.Add(department);
            }
        }

        private void LoadEmployeeList()
        {
            var empList = Store.EmployeeList;
            var depList = Store.DepartmentList;

            Clear();

            var newEmpList = from e in empList
                join d in depList
                on e.DepartmentId equals d.Id into dd
                from d in dd.DefaultIfEmpty()
                         select new TableViewEmployee{Id = e.Id, Name = e.Name, Department = d};

            DgEmployeers.ItemsSource = newEmpList;

        }

        private void Clear()
        {
            //DgEmployeers.Items..Clear();
            //DgEmployeers.Columns.Clear();
        }

        private void BtnDeleteEmployee_OnClickDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            //узнаем выбранную строку
            var selectedItem = DgEmployeers.SelectedItem;

            if (selectedItem != null)
            {
                var item = (TableViewEmployee)selectedItem;
                var e1 = Store.EmployeeList.FirstOrDefault(r => r.Id == item.Id);
                Store.EmployeeList.Remove(e1);

                LoadEmployeeList();
            }
        }

        private void BtnSaveEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            //узнаем выбранную строку
            var selectedItem = DgEmployeers.SelectedItem;
            if (selectedItem != null)
            {
                var tItem = (TableViewEmployee)selectedItem;
                var e1 = Store.EmployeeList.FirstOrDefault(r => r.Id == tItem.Id);
                if (e1 != null)
                {
                    e1.Name = TbEmployeeName.Text;

                    if (CbDepartments.SelectedItem != null)
                    {
                        var selected = (Department) CbDepartments.SelectedItem;
                        var d = Store.DepartmentList.FirstOrDefault(r => r.Id == selected.Id);
                        if (d != null)
                        {
                            e1.Department = d;
                            e1.DepartmentId = d.Id;
                        }
                    }
                }
                LoadEmployeeList();
            }
                
        }

        private void BtnEditEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            //узнаем выбранную строку
            var selectedItem = DgEmployeers.SelectedItem;

            if (selectedItem != null)
            {
                var item = (TableViewEmployee)selectedItem;
                //if (item != null)
                {
                    TbEmployeeName.Text = item.Name;
                    CbDepartments.SelectedValue = item.Department;
                }
            }
        }

        private void TbAddEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            var newEmp = new Employee();
            newEmp.Name = TbEmployeeName.Text;
            var selected = (Department)CbDepartments.SelectedItem;
            if (selected != null)
            {
                newEmp.Department = selected;
                newEmp.DepartmentId = selected.Id;
            }
            newEmp.Id = Store.GenerateEmployeeId();

            Store.EmployeeList.Add(newEmp);
            LoadEmployeeList();
        }
    }
}
