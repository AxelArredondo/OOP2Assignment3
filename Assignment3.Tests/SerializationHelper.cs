using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            // Convert linked list to List<User> before serialization
            List<User> userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, userList);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                List<User> userList = (List<User>)serializer.ReadObject(stream);
                ILinkedListADT list = new Assignment3.Utility.SLL(); // You may need to adjust this namespace
                foreach (var user in userList)
                {
                    list.AddLast(user);
                }
                return list;
            }
        }
    }
}
