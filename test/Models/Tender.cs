using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;

namespace test.Models
{
    public partial class Tender
    {
        public int Id { get; set; }
        public string tender { get; set; }
        public string description { get; set; }
        public string oganizator { get; set; }
        public string view { get; set; }
        public string category { get; set; }
        public decimal initial_rate { get; set; }
        public string currency { get; set; }
        public DateTime date { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_finish { get; set; }

    }

    public class TenderContext : DbContext
    {

        public DbSet<Tender> Tenders { get; set; }

    }
    public partial class Tend
    {
        public IEnumerable<Tender> Tenders { get; set; }
        public SelectList Oganizators { get; set; }
       
    }

 

}