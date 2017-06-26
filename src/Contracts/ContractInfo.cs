public class ContractInfo
{
    public string Description { get; set; }

    public string Amount { get; set; }

    public Customer Customer { get; set; }

    public Producer Producer { get; set; }

    public string Tx { get; set; }
}

public class Customer
{
    public string Inn { get; set; }
    public string Kpp { get; set; }
    public string Name { get; set; }
}

public class Producer
{
    public string Name { get; set; }
    public string Inn { get; set; }
    public string Kpp { get; set; }
}

