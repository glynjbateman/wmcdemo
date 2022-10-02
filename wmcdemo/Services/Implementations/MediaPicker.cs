using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using wmcdemo.Services.Interfaces;

namespace wmcdemo.Services.Implementations
{
    public class MediaPicker : IMediaPicker
    {
        public async Task<Stream> SelectPhoto()
        {
            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions 
            { 
                SaveMetaData = true, 
                RotateImage = true, 
                MaxWidthHeight = 800, 
                PhotoSize = PhotoSize.MaxWidthHeight 
            });

            if(file == null)
            {
                return null;
            }

            return file.GetStreamWithImageRotatedForExternalStorage();
        }
    }
}
