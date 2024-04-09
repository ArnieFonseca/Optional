using Functional.Optional;

using Model;

namespace TestNullable;

public static  class OptionalUtil 
{
    public static  IEnumerable<Developer> Developers { get; set; }
     
    /// <summary>
    /// Retrieve a Developer or Nothing
    /// </summary>
    /// <param name="name">The name of the developer</param>
    /// <returns>An Optional Developer</returns>
    public static Optional<Developer> GetDeveloper(string name)
    {
        Developer? dev = Developers.FirstOrDefault(x => x.Name == name);
        return (dev != null) ? new Some<Developer>(dev) : new None<Developer>();
    }
    /// <summary>
    /// Retrieve the Developer Skill or Nothing
    /// </summary>
    /// <param name="developer">The developer type uses to get its skill</param>
    /// <returns>An Optional of Skill</returns>
    public static Optional<Skill> GetSkill(Developer developer) => (developer.Skill != null)
            ? new Some<Skill>(developer.Skill)
            : new None<Skill>();
    /// <summary>
    /// Retrieve the Developer Skill Language or Nothing
    /// </summary>
    /// <param name="skill">Type of Skill</param>
    /// <returns>An Optional Language</returns>
    public static Optional<Language> GetLanguage(Skill skill) => (skill.Language) != null
            ? new Some<Language>(skill.Language)
            : new None<Language>();
    
}
