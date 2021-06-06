using ADO.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ADO
{
    class ParametersParser: IParser<string[]>
    {
        public string[] Parse(string str)
        {
            var result = new List<string>();
            string pat = @"@(?:[\w#_$]{1,128}|(?:(\[)).{1,128}?(?(1)]))";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(str);
            while (m.Success)
            {
                result.Add(m.Value);
                m = m.NextMatch();
            }
            return result.ToArray(); ;
        }
    }
}
