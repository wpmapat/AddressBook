﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddOrUpdateAContact : Page
    {
        Contact contact = new Contact();
        public AddOrUpdateAContact()
        {
            
            this.InitializeComponent();
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //On clicking Cancel button user gets navigate to mainpage where all contacts will get display.
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "New contact has been added.";
            contact.FirstName = FName.Text;
            contact.LastName = LName.Text;
            contact.Address = Address.Text;
            contact.EmailAddress = Email.Text;
            contact.PhNo = PhoneNumber.Text;
            DataAccess dataAccess = new DataAccess();
            dataAccess.CreateContact(contact);
        }
    }
}
