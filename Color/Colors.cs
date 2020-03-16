using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace QRImage.Color
{
    /// <summary>
    /// 
    /// </summary>
    public class Colors
    
    {
        private Colors() { }

        /// <summary>
        /// Select Color ByName Input String Color
        /// </summary>
        /// <param name="NameColor"></param>
        /// <returns></returns>
        public static System.Drawing.Color SelectColorByName(string NameColor)
        {
            System.Drawing.Color Color = System.Drawing.Color.FromName(NameColor);
            return Color;
        }

        /// <summary>
        /// Return All Color
        /// </summary>
        /// <returns name = "ListColor"></returns>
       
        public static IDictionary GetAllColors()
        {
            List<System.Drawing.Color> allColors = new List<System.Drawing.Color>();

            List<string> NameColor = new List<string>();
            foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties())
            {
                if (property.PropertyType == typeof(System.Drawing.Color))
                {
                    allColors.Add((System.Drawing.Color)property.GetValue(null));
                }
            }

            foreach (System.Drawing.Color c in allColors) NameColor.Add(c.Name);

            return new Dictionary<string,object>{{"Colors",allColors},{"NameColor",NameColor}};
        }
    }

}
