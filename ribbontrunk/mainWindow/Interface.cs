using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Myprojekt
{
    class Interface
    {
        public Interface() { }
        public string Open_Dialog_File()
        {
            string file_name;
            OpenFileDialog Open_File = new OpenFileDialog();
            Open_File.Title = "Додати фото";
            Open_File.Filter = "Фото (*.jpg)|*.jpg|All Files|*.*";
            Open_File.ShowDialog();
            file_name = Open_File.FileName;
            return file_name;
        }

        public string Open_Dialog_File_Filter()
        {
            string file_name;
            OpenFileDialog Open_File = new OpenFileDialog();
            Open_File.Title = "Відкрити фільтри";
            Open_File.Filter = "Filter dokuments (*.txt)|*.txt|All Files|*.*";
            Open_File.ShowDialog();
            file_name = Open_File.FileName;
            return file_name;
        }
    }
}
