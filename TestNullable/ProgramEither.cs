using Functional.Either;

using Model;

namespace TestNullable;

public  static class EitherUtil
{
    public static IEnumerable<Developer> Developers { get; set; }
    /// <summary>
    /// Retrieve a Developer
    /// </summary>
    /// <param name="name">The name of the developer</param>
    /// <returns>An Exception or a Developer</returns>
    public static Either<Exception, Developer> GetDeveloper(string name)
    {
        Developer? dev = Developers.FirstOrDefault(x => x.Name == name);
        return (dev != null)
            ? new Right<Exception, Developer>(dev)
            : new Left<Exception, Developer>(new Exception("(Developer not exists)"))
            ;
    }
    /// <summary>
    /// Retrieve the Developer Skill
    /// </summary>
    /// <param name="developer">The developer type uses to get its skill</param>
    /// <returns>An Exception or Skill</returns>
    public static Either<Exception, Skill> GetSkill(Developer developer) => (developer.Skill != null)
            ? new Right<Exception, Skill>(developer.Skill)
            : new Left<Exception, Skill>(new Exception("(No skill)"));
    /// <summary>
    /// Retrieve the Developer Skill Language
    /// </summary>
    /// <param name="skill">Type of Skill</param>
    /// <returns>An Exception or Skill Language</returns>
    public static Either<Exception, Language> GetLanguage(Skill skill) => (skill.Language) != null
                ? new Right<Exception, Language>(skill.Language)
                : new Left<Exception, Language>(new Exception("(No Language found)"));

}
