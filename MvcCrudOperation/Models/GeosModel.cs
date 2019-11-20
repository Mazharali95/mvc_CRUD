using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudOperation.Models
{
    public class GeosModel
    {
        public List<GeosModel> users { get; set; }
        public int? IdDepartment { get; set; }

        public int id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DeptName { get; set; }

    }
}
