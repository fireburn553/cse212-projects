using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: create an array of type double. This will hold the multiples.
        double[] multiples = new double[length];

        // Step 2: loop to generate multiples
        for (int i = 0; i < length; i++)
        {
            // Step 3: inside the loop declare a product variable to store the result of the multiple and multiple the number by (i + 1) to get the correct multiple.
            double product = number * (i + 1);
            // Step 4: Then add/store product to the array of multiples
            multiples[i] = product;
        }
        //Step 5: return the array of multiples
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Step 1: Create List of type int named end (temporary Storage). Get the index of amount of element as starting up to the last elements in the List and store it to the temporary List name end by using GetRange() function.
        List<int> end = data.GetRange(data.Count - amount, amount);

        //Step 2: Remove the the index of amount of element as starting up to the last elements in the original List by using RemoveRange() function. To avoid duplication of data.
        data.RemoveRange(data.Count - amount, amount);

        //Step 3: Insert the end list to the beginning of the origianl List by using the InsertRange() function.
        data.InsertRange(0, end);


    }
}
