// Ignore Spelling: Nullable

namespace TestNullable;

using Functional.Optional;
using Model;

public class Program
{
    static void Main()
    {
        var names = new List<string>() { "Ravi", "Arnie", "Melinda", "Dina", "Tram" };
        foreach (string name in names)
        {
            Optional<Developer> developer = Optional<string>.Unit(name)
                                            .Bind(GetDeveloper);

            string devName = developer.Match(x => x.Name, _ => "Developer Not Exists");
            string devlang = developer.Bind(GetSkill)
                                   .Bind(GetLanguage)
                                   .Match(x => x.Name, _ => "No Skill")                                
                                   ;

            Console.WriteLine($"{devName} - {devlang}");

        }
    }
    static Optional<Developer> GetDeveloper(string name)
    {
        Developer? dev = LoadData().FirstOrDefault(x => x.Name == name);
        return (dev != null) ? new Some<Developer>(dev) :  new None<Developer>();  
    }
    static Optional<Skill> GetSkill(Developer developer) => (developer.Skill != null)
            ? new Some<Skill>(developer.Skill)
            : new None<Skill>();
    static Optional<Language> GetLanguage(Skill skill) => (skill.Language) != null
            ? new Some<Language>(skill.Language)
            : new None<Language>();
    static List<Developer> LoadData() => new()
        {
            new() {Name = "Arnie"},
            new() {Name="Dina", Skill=  new Skill() { Language = new Language() {Name = "C#"}} },
            new() {Name="Melinda", Skill=  new Skill() { Language = new Language() {Name = "SQL Server"}} },
            new() {Name="Tram", Skill=  new Skill() { Language = new Language() {Name = "Python"}} },
        };
}
