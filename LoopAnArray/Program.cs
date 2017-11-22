/* 
 * Program Name:    Loop An Array
 * Author:          Alfred Massardo
 * Date:            November 13, 2017
 * 
 * Description:     A simple console application that will ask the user how big an array they wish to create. 
 *                  It will then ask them to input a number which will represent the point they would like to finish 
 *                  looping the array in a for loop. So, this program does nothing but show how to use array and how
 *                  to exit an array properly, when a condition has been met.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAnArray
{
    class Program
    {
        static void Main(string[] args)
        {

            ///////////////
            // Constants
            ///////////////

            // Income threshold levels
            const int numberMinimum = 1;                // Constant that holds the array size minimum
            const int numberMaximum = 10000;            // Constant that holds the array size minimum
            const string messageError = "\nError!\n";   // Constant that holds the error portion of the message

            ///////////////
            // Variables
            ///////////////

            int numberToStart = 0;      // Variable to hold the number to start at, input by user
            int numberToEnd = 0;        // Variable to hold the number to end at, input by user
            int arrayLength = 0;        // Variable to hold the array size, input by user
            int numberToStop = 0;       // Variable to hold the number to stop at, input by user

            string messageArrayStart = "Please enter an array start number\n\t(between {0:n0} and {1:n0}): "; //Variable to hold the starting message.
            string messageArrayEnd = "Please enter an array end number\n\t(between {0:n0} and {1:n0}).\n\t And not equal to or less than the start number {2:n0}: "; //Variable to hold the ending message.
            string messageArrayStop = "Please enter an array stop number\n\t(between {0:n0} and {1:n0}).\n\t And not equal to or less than the start number {2:n0}.\n\t And not equal to or greater than the end number {3:n0}: "; //Variable to hold the ending message.
            string messageOutput = string.Empty;

            ///////////////
            // Input
            ///////////////

            // Prompt and store to input number to be in the first element of the array 
            // after the user input is converted to a integer and 
            // it is validated agianst the number minimum and maximum range
            // and we also know it is a number.
            // using the do loop is good here because we know we want to to happen at least
            // once and then test (while). Rather than test and then do.
            // https://msdn.microsoft.com/en-us/library/kefxt662(v=vs.100).aspx 
            do
            {

                // display the current message
                Console.Write(messageArrayStart, numberMinimum, numberMaximum); // prompt the user for the number to start the array at in the first element.

                // Tenary Operator in c# - ?: . Or, another typoe of "if" statment
                // This is a condition statement/if statement with two possibilities 
                // true ? do this : else do that; 
                // in its simplest form. You can nest them, but legibility becomes an issue.
                // (true condition) ? do this (true) : do that (false) 
                // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator  
                // messageArrayStart.IndexOf checks to see if a input string is in the string. If it is i the string
                // it returns its position. If it is not in the string it return -1.
                // https://msdn.microsoft.com/en-us/library/k8b1470s(v=vs.110).aspx
                // Add a "Error!" (messageError constant) to the beginning of the message, if it is not already there.
                //                  (------------------------ Tenary Operator ------------------------)
                messageArrayStart = (messageArrayStart.IndexOf(messageError) == -1 ? messageError : "") + messageArrayStart;
            }
            while ((!(Int32.TryParse(Console.ReadLine(), out numberToStart)))   // check that the input is an integer
                    || ((numberToStart < numberMinimum)                         // compare the input against the minimum constant
                    || (numberToStart > numberMaximum)));                       // compare the input against the maximum constant


            // Prompt and store to input number to represent the last number 
            // and length of the array
            // it is validated agianst the number minimum and maximum range
            // and we also know it is a number.
            // Also, validate that it is not less that the start number (numberStart)
            do
            {

                // display the current message
                Console.Write(messageArrayEnd, numberMinimum, numberMaximum, numberToStart); // prompt the user for the number to start the array at in the first element.

                // Add a "Error!" (messageError constant) to the beginning of the message, if it is not already there.
                messageArrayEnd = (messageArrayEnd.IndexOf(messageError) == -1 ? messageError : "") + messageArrayEnd;
            }
            while ((!(Int32.TryParse(Console.ReadLine(), out numberToEnd)))     // check that the input is an integer
                    || ((numberToEnd < numberMinimum)                           // compare the input against the minimum constant
                    || (numberToEnd > numberMaximum)                            // compare the input against the maximum constant
                    || (numberToEnd <= numberToStart)));                        // compare the input against the start number constant

            // Prompt and store to input number to represent the last number 
            // and length of the array
            // it is validated agianst the number minimum and maximum range
            // and we also know it is a number.
            // Also, validate that it is not less that the start number (numberStart)
            do
            {

                // display the current message
                Console.Write(messageArrayStop, numberMinimum, numberMaximum, numberToStart, numberToEnd); // prompt the user for the number to start the array at in the first element.

                // Add a "Error!" (messageError constant) to the beginning of the message, if it is not already there.
                messageArrayEnd = (messageArrayEnd.IndexOf(messageError) == -1 ? messageError : "") + messageArrayEnd;
            }
            while ((!(Int32.TryParse(Console.ReadLine(), out numberToStop)))     // check that the input is an integer
                    || ((numberToStop < numberMinimum)                           // compare the input against the minimum constant
                    || (numberToStop > numberMaximum)                            // compare the input against the maximum constant
                    || (numberToStop <= numberToStart)
                    || (numberToStop >= numberToEnd)
                    ));                        // compare the input against the start number constant

            ///////////////
            // Processing
            ///////////////

            // Determine the Array Length by subtracting the number start an end points 
            // that the user input.
            arrayLength = ((1 + numberToEnd) - numberToStart);

            // Create the array
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
            int[] arrayNumbers = new int[arrayLength];

            // declare an initialize a new variable
            // to be used as the array index
            int indexBuildArray = 0;

            // Loop through the array
            // as long as the indexBuildArray is less than the
            // length of the array, the loop will continue
            while (indexBuildArray < arrayLength)
            {

                // for the current index that the indexBuildArray sets the
                // array to...
                // add the indexBuildArray to the numberToStart and put the result
                // into the current element of the array
                arrayNumbers[indexBuildArray] = (numberToStart + indexBuildArray);

                // increment the index, so you do not end up with 
                // to move to the next element of the array 
                // and avoid an endless loop. 
                indexBuildArray++;

            }

            ///////////////
            // Output
            /////////////// 

            // build the output message
            // loop through the array by
            // initializing the incrementor (index) to 0 which is the first element of the array (int index = 0)
            // keep looping while the index is less than the length of the array (index < arrayNumbers.Length)
            // keep incrementing the incrementor/index by one for every loop (index++)
            for (int index = 0; index < arrayNumbers.Length; index++)
            {
                // concatinate the message
                messageOutput += "\nIndex " + index.ToString("n0") + "  holds the value " + arrayNumbers[index] + ".";

                // if the current element has a number that is
                // equal to the number the user input to stop 
                // at (numberToStop),
                // then set the index to the length
                // of the array to stop the loop.
                if (arrayNumbers[index] == numberToStop)
                {
                    // Set the index to be equal to 
                    // the size of the array, which is
                    // greater than index < arrayNumbers.Length
                    // so the loop will stop naturally.
                    index = arrayNumbers.Length;
                }

            }

            // Show the user the final message
            Console.Write(messageOutput);

            // Ask the user to press any key to end the program
            // \n - use the newline escape character to move the output to the next line.
            Console.Write("\nPress any key to end this application...");

            // Use the Console ReadKey to pause the program until the user presses any key
            // to end the application.
            Console.ReadKey();
        }
    }
}
