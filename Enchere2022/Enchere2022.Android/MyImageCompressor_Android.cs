using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Enchere2022.Droid;
using Enchere2022.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(MyImageCompressor_Android))]
namespace Enchere2022.Droid
{
    class MyImageCompressor_Android : MyImageCompressor
    {
        public MyImageCompressor_Android() { }

        public string ImageCompressor(byte[] bitmapBytes)
        {
            Bitmap bitmap = BitmapFactory.DecodeByteArray(bitmapBytes, 0, bitmapBytes.Length);

            Bitmap resizedImage = Bitmap.CreateScaledBitmap(bitmap, 300, 300, false);
            var stream = new System.IO.MemoryStream();

            resizedImage.Compress(Bitmap.CompressFormat.Webp, 100, stream);
            byte[] imageBytes = stream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}