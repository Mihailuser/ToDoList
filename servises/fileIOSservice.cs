using listofwork.Models;
using Newtonsoft.Json;
using System;

using System.Xaml;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.XmlTransform;

namespace listofwork.servises
{
    class FileIOSservice
    {




        private readonly string PATH;
        public FileIOSservice(string path)
        {
            PATH = path;
        }
        public BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var filetext = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(filetext);

            }
        }
        public void SaveData(object tododataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(tododataList);
                writer.Write(output);
            }

        }
    }
}
