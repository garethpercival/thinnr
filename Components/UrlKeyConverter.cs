using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace thinnr.Components
{
    public class UrlKeyConverter : IUrlKeyConverter
    {
        public int GetIdFromKey(string key)
        {
            int.TryParse(key, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int id);
            return id;
        }

        public string GetKeyFromId(int id)
        {
            return id.ToString("x");
        }
    }
}
