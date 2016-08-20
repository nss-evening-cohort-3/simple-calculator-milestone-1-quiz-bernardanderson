using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Constant
    {
        // Sets the private constant dictionary
        Dictionary<string, int> constantList = new Dictionary<string, int>() { ["spacer"] = 42 };

        // This checks to see if the constant already exists in the dictionary.  If it does, it returns "true" for success and
        //  the value in a KeyValuePair.  If it doesn't exist it says "false" meaning that the dictionary pull failed.
        public KeyValuePair<bool, int> ReturnConstantValue(string sentConstantLetter)
        {
            KeyValuePair<bool, int> isFoundInDictionaryValue;

            if (constantList.ContainsKey(sentConstantLetter.ToLower()))
            {
                int tempConstantValue = constantList[sentConstantLetter.ToLower()];
                isFoundInDictionaryValue = new KeyValuePair<bool, int> (true, tempConstantValue);
            }
            else
            {
                isFoundInDictionaryValue = new KeyValuePair<bool, int>(false, -1);
            }
            return isFoundInDictionaryValue;
        }

        // This sets the constant/value pair in the constantList dictionary.  If the dictionary already contains the letter,
        //  then a "false" is returned for a fail. Otherwise a "true" is returned saying that the constant was successfully set.
        public bool AssignConstantValue(string sentConstantLetter, int sentConstantValue)
        {
            bool wasTheSettingSuccessful;

            if (constantList.ContainsKey(sentConstantLetter.ToLower()))
            {
                wasTheSettingSuccessful = false;
            }
            else
            {
                constantList.Add(sentConstantLetter.ToLower(), sentConstantValue);
                wasTheSettingSuccessful = true;
            }

            return wasTheSettingSuccessful;
        }


    }
}
