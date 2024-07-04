using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class Attr_controler
    {
        static async public void PopulateattrDDL(ComboBox Attr_field)
        {
            using (var context = new InvEntitie())
            {
                var attrs = context.Attrs.ToList();
                foreach (var N in attrs)
                {
                    Attr_field.Items.Add(N.Label);
                }
            }
        }
        static async public Task<int> GetAttrId(ComboBox Attr_field)
        {
            int id = -1;
            if (Attr_field.Text.Length > 0)
            {
                using (var context = new InvEntitie())
                {
                    var attrs = context.Attrs.ToList();
                    foreach (var N in attrs)
                    {
                        if (N.Label == Attr_field.Text)
                        {
                            id = N.Code; break;
                        }
                    }
                }
            }
            return id;
        }
        static async public Task<string> GetAttrLabel(int id)
        {

            string label = "";

            using (var context = new InvEntitie())
            {
                var attrs = context.Attrs.ToList();
                foreach (var N in attrs)
                {
                    if (N.Code == id)
                    {
                        label = N.Label; break;
                    }
                }

            }
            return label;
        }
    }
}
