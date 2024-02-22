using static System.Console;

internal class Hanterare
{
    bool fortsättProgrammet = true;
    string? programVal;

    public void ProgramHanterare()      // Huvudfunktionen som sköter vad som ska ske i programmet
    {
        do
        {
            WriteLine("[X]\n[X] Vänligen välj något av följande alternativ:\n"
                    + "[X] 1. Gå till elementhanteraren.\n"
                    + "[X] 2. Avsluta programmet.\n"
                    + "[X]");
            Write("[X] ");
            programVal = ReadLine()!;
            Clear();

            switch (programVal)     // Switch case med fallback ifall inmatningen inte stämmer överens med 1 eller 2, 1 == använd programmet, 2 == avsluta programmet
            {
                case "1":
                    Write("[X] Laddar elementhanteraren");      // Animation
                    for (int index = 0; index < 3; index++)
                    {
                        Thread.Sleep(600);
                        Write(". ");
                    }

                    Thread.Sleep(300);
                    Clear();
                    InData.Inmatningar();       // Kalla på Inmatningar funktionen i InData klassen

                    break;
                case "2":
                    Write("[X] Avslutar programmet");       // Animation
                    for (int index = 0; index < 3; index++)
                    {
                        Thread.Sleep(600);
                        Write(". ");
                    }

                    WriteLine();
                    Thread.Sleep(300);
                    fortsättProgrammet = false;     // Avsluta programmet

                    break;
                default:
                    WriteLine("[X] Felaktig inmatning, vänligen försök igen.");
                    break;
            }
        } while (fortsättProgrammet);
    }
}