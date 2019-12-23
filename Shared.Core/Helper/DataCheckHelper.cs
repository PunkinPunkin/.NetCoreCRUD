using System.Collections.Generic;

namespace Shared.Helper
{
    public class DataCheckHelper
    {
        public static string PropertyNullOrWhiteSpace(Dictionary<string, object> propertys)
        {
            string emptyFields = string.Empty;
            foreach (var p in propertys)
            {
                if (p.Value == null)
                {
                    emptyFields += string.Format("{0},", p.Key);
                    continue;
                }
                if (string.IsNullOrWhiteSpace(p.Value.ToString()))
                {
                    emptyFields += string.Format("{0},", p.Key);
                    continue;
                }
            }
            return emptyFields.TrimEnd(',');
        }
    }
}
