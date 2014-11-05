using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    class FileExtensionException : Exception
    {
        public FileExtensionException(string message) : base(message)
        {
        }
    }
}
