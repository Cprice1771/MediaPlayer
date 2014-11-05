using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerHelper
{
    public class SongFile
    {
        string _file;
        public string File 
        { 
            get
            {
                return _file;
            } 
            set
            {
                _file = value;
            }
        }

        public SongFile(string s)
        {
            File = s;
        }
    }
}
