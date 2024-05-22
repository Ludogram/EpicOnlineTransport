using System;
using System.Text;

public class RandomString {

    // Generates a random string with a given size.    
    public static string Generate(int size) {
        var builder = new StringBuilder(size);

        Random random = new Random();

        // Unicode/ASCII Letters/Num are divided into two blocks
        // (Letters 65–90 / 97–122):

        // char is a single Unicode character  =
        char offsetLetter = 'A';
        const int lettersOffset = 26; // A...Z or a..z: length=26  
        char offsetNum = '0';
        const int numOffset = 10; // 0..9: length=10
        
        for (var i = 0; i < size; i++) {
            char @char;
            if(random.Next(0,2) == 0) {
                @char = (char) random.Next(offsetLetter, offsetLetter + lettersOffset);
            } else {
                @char = (char) random.Next(offsetNum, offsetNum + numOffset);
            }

            builder.Append(@char);
        }

        return builder.ToString();
    }
}
