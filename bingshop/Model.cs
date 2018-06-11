namespace bingshop
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Models")
        {

        }


        protected override 
            void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
