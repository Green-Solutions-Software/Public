using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Ingredient : Entity
    {
        public long IngredientID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
