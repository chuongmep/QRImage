using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Class Export Dll
/// </summary>
public static class Assemblys
{
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

        Assembly assembly = Assembly.LoadFrom(dll);
        Type[] types = assembly.GetTypes();
        foreach (var type in types)
        {
            
            MethodInfo[] members = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static);
            Pathmethod.AddRange(members.Select(member => $"{assembly.GetName().Name}.{type.Name}.{member.Name}"));
        }
        return Pathmethod;
    }
    #endregion

    #region NameSpace

    /// <summary>
    /// Return NameSpace In 
    /// </summary>
    /// <param name="dll"></param>
    /// <returns></returns>
    public static List<IEnumerable<string>> NameSpace(string dll)
    {

        List<IEnumerable<string>> ClassName = new List<IEnumerable<string>>();

        Assembly assembly = Assembly.LoadFrom(dll);
        Type[] types = assembly.GetTypes();
        foreach (var type in types)
        {
            MethodInfo[] members = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static);
            ClassName.Add(members.Select(x=>$"{assembly.GetName().Name}"));
        }
        return ClassName;
    }

    #endregion
}
