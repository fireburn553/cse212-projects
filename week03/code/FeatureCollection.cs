public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; } // list was created to store the feature class and can access in the foreach

}

public class Feature //class Feature was created to get the properties inside the feature
{
    public Properties Properties { get; set; }
}

public class Properties //class Properties was created to access the properties
{
    public double Mag { get; set; } // for the magnitude with a double data type
    public string Place { get; set; } // for the place with a string data type
    public long Time { get; set; } // for time with a long data type
}