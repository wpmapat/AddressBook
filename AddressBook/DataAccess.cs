using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace AddressBook
{
    public class DataAccess
    {
        //we are generating a filepath 
        public string filepath = ApplicationData.Current.LocalFolder.Path+"\\AddressBook.json";
        //declaring a new collection "Contacts" of List type
        public List<Contact> Contacts;

        //Constructor
        public DataAccess()
        {
            if (File.Exists(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                //Read a File
                using (StreamReader file = new StreamReader(File.OpenRead(filepath)))
                {
                    Contacts = serializer.Deserialize(file, typeof(List<Contact>)) as List<Contact>;
                }
            }
            else
            {
                Contacts = new List<Contact>();
            }
        }
        /// <summary>
        /// After creating a new contact this method will add it to contacts collection and write it json file.
        /// </summary>
        /// <param name="c"></param>
        public void CreateContact(Contact c)
        {
            Contacts.Add(c);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;

            //Write to json file
            using (StreamWriter file = File.CreateText(filepath))
            {
                serializer.Serialize(file, Contacts);
            }
        }
        /// <summary>
        /// this method will get all contacts fron json file
        /// </summary>
        /// <returns></returns>
        public List<Contact>GetAllContacts()
        {
            return Contacts;
        }
        /// <summary>
        /// this method will delete a contact from the contact list
        /// </summary>
        /// <param name="c"></param>
        public void DeleteContact(Contact c)
        {
            Contacts.Remove(c);
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter file = File.CreateText(filepath))
            {
                serializer.Serialize(file, Contacts);
            }
        }
        //public void UpdateContact(Contact c)
        //{

        //}
    }
}
