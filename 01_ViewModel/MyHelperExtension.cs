using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_ViewModel
{
    public static class MyHelperExtension
    {
        public static MvcHtmlString textBoxCreate(this HtmlHelper htmlHelper, string name, string value)
        {
            string input = "<input name =\"" + name + "\"";
            input += "value =\"" + value + "\"/>"; 
            return new MvcHtmlString(input);
        }

        public static string TersCevir(this string str)
        {
            string newstr = "";

            for (int i = str.Length; i >= 0; i--)
            {
                newstr += str[i];
            }
            return newstr;
        }
    }
}