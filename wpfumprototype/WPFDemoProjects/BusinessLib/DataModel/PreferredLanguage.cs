using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLib.DataModel
{
    public class PreferredLanguage
    {
        private PreferredLanguage()
        {
        }
        public static PreferredLanguage Instance = new PreferredLanguage();
        public List<string> SupportedLanguages = new List<string>{
                                                     "English(United Kingdom)", "English(United Stated", "German(Germany)",
                                                     "Italian(Italy)", "French(France)", "Spainish(Spain)"
                                                 };
    }
}
