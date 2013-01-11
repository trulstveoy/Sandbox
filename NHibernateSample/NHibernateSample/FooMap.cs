using FluentNHibernate.Mapping;
using NHibernateSample.Dto;

namespace NHibernateSample
{
    public class FooMap : ClassMap<Foo>
    {
         public FooMap()
         {
             Table("Foo");
             Id(x => x.Id);
             Map(x => x.A);
             Map(x => x.B);
         }
    }
}