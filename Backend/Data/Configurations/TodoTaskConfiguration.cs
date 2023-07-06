using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations;

public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
{
    // public void Configure(EntityTypeBuilder<TodoTask> builder)
    // {
    //     builder.Property(todoTask => todoTask.Reward)
    //     .HasPrecision(5, 2);
    // }
    public void Configure(EntityTypeBuilder<TodoTask> builder)
    {
        throw new NotImplementedException();
    }
}