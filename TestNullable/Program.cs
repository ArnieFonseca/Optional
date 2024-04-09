// Ignore Spelling: Nullable

namespace TestNullable;

using Functional.Either;
using Functional.Optional;

using Model;

public partial class Program
{
    static void Main()
    {
        List<string> names = ["Joe", "Paul", "Mary", "Joanne", "John"];

        OptionalUtil.Developers = LoadData();
        names.ForEach(name => UseOptional(name));

        Console.WriteLine();

        EitherUtil.Developers = LoadData();
        names.ForEach(name => UseEither(name));
            
    }

    private static void UseOptional(string name)
    {
        Optional<Developer> developer = Optional<string>.Unit(name)
                                                        .Bind(OptionalUtil.GetDeveloper)
                                                        ;

        string devName = (developer.IsHasValue)
                            ? name
                            : $"{name} (Developer Not Exists)"
                            ;

        string devlang = (developer.IsHasValue)
                            ? developer.Bind(OptionalUtil.GetSkill)
                                       .Bind(OptionalUtil.GetLanguage)
                                       .Match(x => x.Name, _ => "(No Skill)")
                            : string.Empty

                            ;

        Console.WriteLine($"Optional: {devName} {devlang}");
    }

    private static void UseEither(string name)
    {
        Either<Exception, Developer> developer = Either<Exception, string>.Unit(name)
                                                                          .Bind(EitherUtil.GetDeveloper)
                                                                          ;

        string devName = (developer.IsRight)
                            ? name
                            : $"{name} {developer.Match(r => r.Name, l => l.Message)}"
                            ;

        string devlang = (developer.IsRight)
                            ? developer.Bind(EitherUtil.GetSkill)
                                       .Bind(EitherUtil.GetLanguage)
                                       .Match(r => r.Name, l => l.Message)
                            : string.Empty
                            ;

        Console.WriteLine($"Either: {devName} {devlang}");
    }

    /// <summary>
    /// Data Loader
    /// </summary>
    /// <returns>List of Developers</returns>
    public static List<Developer> LoadData() => new()
        {
            new() {Name="John"}, 
            new() {Name="Mary", Skill=  new Skill() { Language = new Language() {Name = "C#"}} },
            new() {Name="Joanne", Skill=  new Skill() { Language = new Language() {Name = "SQL Server"}} },
            new() {Name="Paul", Skill=  new Skill() { Language = new Language() {Name = "Python"}} },
        };
}
