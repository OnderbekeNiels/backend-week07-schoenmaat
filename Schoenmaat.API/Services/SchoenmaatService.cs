using System;

namespace Schoenmaat.API
{
    public class SchoenmaatService
    {
        public double calcShoenmaat(double voetlengte)
        {
            if (voetlengte < 2)
            {
                throw new ArgumentException("Voetlengte moet minimum 2 centimer bedragen");
            }
            else if (voetlengte > 50)
            {
                throw new ArgumentException("Voetlengte moet mag maximum 50 centimer bedragen");
            }
            else
            {
                return (3 / 2) * (voetlengte + 1.5);
            }

        }
    }
}
