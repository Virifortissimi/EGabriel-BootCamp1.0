﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data
{
    public class bookMap
    {
        public bookMap(EntityTypeBuilder<book> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.ISBN).IsRequired();
            entityBuilder.Property(t => t.Publisher).IsRequired();
            entityBuilder.HasOne(e => e.Author).WithMany(e => e.Books).HasForeignKey(e => e.AuthorId);
        }
    }
}
