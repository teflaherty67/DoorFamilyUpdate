﻿using Autodesk.Revit.DB;
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


namespace DoorFamilyUpdate
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    ///    
    public partial class frmDoorUpdate : Window
    {
        ObservableCollection<FamilyInstance> doorData { get; set; }
        
        public frmDoorUpdate(List<FamilyInstance> _dataList)
        {
            InitializeComponent();

            doorData = new ObservableCollection<FamilyInstance>(_dataList);

            grdDoorData.ItemsSource = doorData;            
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
