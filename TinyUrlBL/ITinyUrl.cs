using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrlBL
{
    public interface ITinyUrl
    {
        public string GenerateTinyUrl(string text);
    }
}
