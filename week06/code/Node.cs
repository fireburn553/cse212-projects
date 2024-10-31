public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // If the value is equal to the data, automatically return
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // If the value is equal to the data, automatically return true
        if (value == Data)
        {
            return true;
        }

        //if the value is less than the current node, it will go and find in the left subtree
        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        else
        {//if the value is greater than the current node, it will go and find in the right subtree
            return Right != null && Right.Contains(value);
        }

    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        //Declare variable for the left and right for comparison later
        int hLeft;
        int hRight;

        //If left is not null then it will call recursively the GetHeight function
        if (Left is not null)
        {
            hLeft = Left.GetHeight();
        }
        else //else the value of the hLeft is 0
        {
            hLeft = 0;
        }

        //If right is not null then it will call recursively the GetHeight function
        if (Right is not null)
        {
            hRight = Right.GetHeight();
        }
        else //else the value of the hRight is 0
        {
            hRight = 0;
        }

        //I used the Math.Max function to compare the value of the variable and will add 1 to it.
        return Math.Max(hLeft, hRight) + 1; // Replace this line with the correct return statement(s)
    }
}