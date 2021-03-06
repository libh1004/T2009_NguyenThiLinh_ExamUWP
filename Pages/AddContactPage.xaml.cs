using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2009_NguyenThiLinh_ExamUWP.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace T2009_NguyenThiLinh_ExamUWP.Pages
{
    public sealed partial class AddContactPage : Page
    {
        private ContactModel contactModel = new ContactModel();
        public AddContactPage()
        {
            this.InitializeComponent();
            this.Loaded += ListContact_Loaded;
        }

        private void ListContact_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ListView.ItemsSource = contactModel.FindAll();
        }
    }
}
