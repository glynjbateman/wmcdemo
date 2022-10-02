using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace wmcdemo.Services.Interfaces
{
    public interface IMediaPicker
    {
        Task<Stream> SelectPhoto();
    }
}
