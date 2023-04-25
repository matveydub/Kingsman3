using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kingsman.DB;

namespace Kingsman.ClassHelper
{
    public class ServiceCartClass
    {
        public static List<Service> serviceCart { get; set; } = new List<DB.Service>();
    }
}
