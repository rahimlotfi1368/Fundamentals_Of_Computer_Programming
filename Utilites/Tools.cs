using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilites
{
    public static class Tools
    {
        public static bool CreateAFile(string path)
        {
            bool result = false;
           
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var folder = Path.GetDirectoryName(path);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                result = true;
            }

            return result;
        }
    }
}
