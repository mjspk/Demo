using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Demo.Helpers
{
    public static class PictureSourceHelper
    {
        private static FileResult photo;

        public static async Task<string> GetPicture()
        {
            try 
            {
                var result = await App.Current.MainPage.DisplayActionSheet("ChoosePictureSource", "", null, new string[] { "Camera","Gallery" });
                if (result == null)
                    return string.Empty;
                photo = result == "Camera" && MediaPicker.IsCaptureSupported ? await MediaPicker.CapturePhotoAsync() : await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    using (var stream = await photo.OpenReadAsync())
                    using (var newStream = File.OpenWrite(newFile))
                        await stream.CopyToAsync(newStream);
                    return newFile;
                }
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Not Supported", "Capturing Pictures not Supported", "Ok");
            }
            return string.Empty;
        }
        public static async Task<byte[]> PathToBytes(string path)
        {
            try
            {
                 
                using (var stream = File.OpenWrite(path))
                using (var newStream =new MemoryStream())
                {
                    await stream.CopyToAsync(newStream);
                    return newStream.ToArray();
                }
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Loading error", ex.Message, "Ok");
            }
            return null;
        }

    }
}
