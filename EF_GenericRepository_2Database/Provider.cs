

namespace EF_GenericRepository_2Database
{
    public record Provider(string Name, string Assembly)
    {
        public static readonly Provider MSSql = new(nameof(MSSql), typeof(MSSql.Marker).Assembly.GetName().Name!);
        public static readonly Provider Postgres = new(nameof(Postgres), typeof(Postgres.Marker).Assembly.GetName().Name!);
    }

}
