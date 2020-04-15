using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class QuestionTextValidator
    {
        public bool Validate (string questionText)
        {
            bool isValid = false;
            Regex regex = new Regex(@"^[a-zA-Z ÁÉÍÓÖŐÚÜŰáéíóöőúüű][a-zA-Z0-9 ÁÉÍÓÖŐÚÜŰáéíóöőúüű!?,.\-()]{1,300}$");
            if (regex.IsMatch(questionText))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
