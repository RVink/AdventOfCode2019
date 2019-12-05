using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class PasswordValidator
    {
        public IEnumerable<int> GetValidPasswords(int lowestPassword, int highestPassword)
        {
            var passwords = new List<int>();
            
            for (int password = lowestPassword; password <= highestPassword; password++)
            {
                if (ValidatePassword(password, lowestPassword, highestPassword))
                {
                    passwords.Add(password);
                }
            }

            return passwords;
        }

        private bool ValidatePassword(int password, int lowestPassword, int highestPassword)
        {
            bool hasSameAdjacentDigits = false;

            for (int charIndex = 0; charIndex < password.ToString().Length; charIndex++)
            {
                int currentValue = int.Parse(password.ToString()[charIndex].ToString());

                if (charIndex > 0 && currentValue < int.Parse(password.ToString()[charIndex - 1].ToString()))
                {
                    return false;
                }

                if (charIndex > 0 && currentValue == int.Parse(password.ToString()[charIndex - 1].ToString()))
                {
                    hasSameAdjacentDigits = true;
                }
            }

            return hasSameAdjacentDigits;
        }
    }
}