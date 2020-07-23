using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


/// <summary>
/// 
/// </summary>
public static class Colors

{
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

        foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties())
        {
            if (property.PropertyType == typeof(System.Drawing.Color))
            {
                allColors.Add((System.Drawing.Color)property.GetValue(null));
            }
        }

        List<string> NameColor = allColors.Select(c => c.Name).ToList();

        return new Dictionary<string, object> { { "Colors", allColors }, { "NameColor", NameColor } };
    }
}
