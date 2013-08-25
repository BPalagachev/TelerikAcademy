using CodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Data
{
    public class CodeJewelsContext : DbContext
    {
        public CodeJewelsContext()
            :base("CodeJewelsDb")
        {
        }

        public DbSet<CodeJewel> CodeJewels { get; set; }
    }
}
