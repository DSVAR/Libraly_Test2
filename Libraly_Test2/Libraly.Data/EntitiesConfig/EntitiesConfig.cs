using Libraly.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraly.Data.EntitiesConfig
{
    public class EntitiesConfig
    {
        public class EntitiesConfiguration:IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.Property(b => b.Id).ValueGeneratedOnAdd();
            }
        }
    }
}