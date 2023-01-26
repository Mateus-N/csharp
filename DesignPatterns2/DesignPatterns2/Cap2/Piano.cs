namespace DesignPatterns2.Cap2;

internal class Piano
{
    public void Toca(IList<INota> musica)
    {
        foreach (INota nota in musica)
        {
            Console.Beep(nota.Frequencia, 600);
        }
    }
}
