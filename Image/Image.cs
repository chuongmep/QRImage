using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace QRImage.Image
{
    /// <summary>
    /// Image
    /// </summary>
    public class Image
    
    {
        private Image() { }



        #region ResizeImage

        /// <summary>
        /// Resize Image Width and Heigh
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns name = "BitMapImage"></returns>
        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion

        #region SaveAsImage

        /// <summary>
        /// Save Image as New Name
        /// </summary>
        /// <param name="path">Path have Character (\) Finnish</param>
        /// <param name="image">Image Resized Size</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Bitmap SaveAsImage(string path, Bitmap image)
        {

            try
            {
                Bitmap bmp = new Bitmap(image);
                bmp.Save(path,ImageFormat.Icon);
                return bmp;
            }
            catch (Exception)
            {
                throw new Exception("Please Check Again Name And Path");
            }

        }


        #endregion


        #region Exportmethod

        // See more : https://stackoverflow.com/questions/57222136/how-to-get-all-methods-of-a-visual-studio-solution
       
        /// <summary>
        /// Input File Dll To Read All Path Method
        /// </summary>
        /// <param name="dll"></param>
        /// <returns></returns>
        public static List<string> Exportmethod(string dll)
        {

            List<string> Pathmethod = new List<string>();

            var assembly = Assembly.LoadFrom(dll);
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var members = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static);
                foreach (MemberInfo member in members)
                {
                    Pathmethod.Add($"{assembly.GetName().Name}.{type.Name}.{member.Name}");
                    
                }

            }
            return Pathmethod;
        }
        #endregion


        #region GetFileFolder

        /// <summary>
        /// Get All File Have In Folder
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns name= "ImageList"></returns>
        public static List<String> GetFileFolder(String folderName)
        {

            DirectoryInfo Folder;
            FileInfo[] Images;

            Folder = new DirectoryInfo(folderName);
            Images = Folder.GetFiles();
            List<String> ImagesList = new List<String>();

            for (int i = 0; i < Images.Length; i++)
            {
                ImagesList.Add(String.Format(@"{0}/{1}", folderName, Images[i].Name));
                
            }


            return ImagesList;
        }

        #endregion


        #region GetImagesPath

        /// <summary>
        /// Return all Image format "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" in folder
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns name ="files"></returns>
        public static string[] GetImagesPath(String folderName)
        {

            DirectoryInfo Folder;
            FileInfo[] Images;
            Folder = new DirectoryInfo(folderName);
            Images = Folder.GetFiles();


            var filters = new string[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = GetFilesFrom(folderName, filters, false);
            return files;
            // https://stackoverflow.com/questions/2953254/cgetting-all-image-files-in-folder
        }

        #endregion

        #region GetFilesFrom
        //more: https://stackoverflow.com/questions/2953254/cgetting-all-image-files-in-folder

        /// <summary>
        /// Get File From folder with filter
        /// </summary>
        /// <param name="searchFolder"></param>
        /// <param name="filters"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
        
        #endregion
    }
}
