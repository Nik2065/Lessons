﻿using System.Linq;
using System.Windows;
using HelloWpf.Entities;

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
        public DepartmentWindow()
        {
            InitializeComponent();
            LoadDepartmentList();
        }

        private void LoadDepartmentList()
        {
            var items = Store.DepartmentList;

            LbDepartments.Items.Clear();
            foreach (var department in items)
            {
                LbDepartments.Items.Add(department);
            }
        }

        private void BtnDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (LbDepartments.SelectedItem != null)
            {
                var selectedItem = (Department) LbDepartments.SelectedItem;
                Store.DepartmentList.Remove(selectedItem);
                LoadDepartmentList();
            }
        }

        private void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            var d = new Department
            {
                Id = GenerateDepartmentId(),
                Name = TbDepartmentName.Text
            };

            Store.DepartmentList.Add(d);
            LoadDepartmentList();
        }

        private int GenerateDepartmentId()
        {
            int newId = 0;
            if (Store.DepartmentList != null && Store.DepartmentList.Count>0)
            {
                var maxId = Store.DepartmentList.Select(e => e.Id).Max();
                newId = maxId++;
            }
            return newId;
        }
    }
}
