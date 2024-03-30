// Ignore Spelling: Nullable

namespace TestNullable;

using Functional.Optional;
using Model;

public class Program
{
    static void Main()
    {
        var names = new List<string>() { "Joe", "Paul", "Mary", "Joanne", "John" };
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
    /// <summary>
    /// Retrieve a Developer or Nothing
    /// </summary>
    /// <param name="name">The name of the developer</param>
    /// <returns>An Optional Developer</returns>
    static Optional<Developer> GetDeveloper(string name)
    {
        Developer? dev = LoadData().FirstOrDefault(x => x.Name == name);
        return (dev != null) ? new Some<Developer>(dev) :  new None<Developer>();  
    }
    /// <summary>
    /// Retrieve the Developer Skill or Nothing
    /// </summary>
    /// <param name="developer">The developer type uses to get its skill</param>
    /// <returns>An Optional of Skill</returns>
    static Optional<Skill> GetSkill(Developer developer) => (developer.Skill != null)
            ? new Some<Skill>(developer.Skill)
            : new None<Skill>();
    /// <summary>
    /// Retrieve the Developer Skill Language or Nothing
    /// </summary>
    /// <param name="skill">Type of Skill</param>
    /// <returns>An Optional Language</returns>
    static Optional<Language> GetLanguage(Skill skill) => (skill.Language) != null
            ? new Some<Language>(skill.Language)
            : new None<Language>();
    /// <summary>
    /// Data Loader
    /// </summary>
    /// <returns>List of Developers</returns>
    static List<Developer> LoadData() => new()
        {
            new() {Name = "John"},
            new() {Name="Mary", Skill=  new Skill() { Language = new Language() {Name = "C#"}} },
            new() {Name="Joanne", Skill=  new Skill() { Language = new Language() {Name = "SQL Server"}} },
            new() {Name="Paul", Skill=  new Skill() { Language = new Language() {Name = "Python"}} },
        };
}
