using System


class ObjectValidator : Device
{
    public bool Validate(Device deviceObj, out List<string> errors)
    {
        bool isValid = true;
        if(deviceObj.Id = "")
        {
            errors.add("ID is required");
            isValid = false;
        }
        if(deviceObj.Code > 100 || deviceObj.Code < 10)
        {
            errors.Add("Code Value Must Be Within 10-100");
            isValid = false;
        }
        if(deviceObj.Description.Length > 100)    {
            errors.Add("Max of 100 Charcters are allowed");
            isValid = false;
        }
        return isValid;
        
    }
}

class RequiredAttribute : System.Attribute 
{
    public ErrorMessage{get;set;}
}

class RnageAttribute : System.Attribute
{
    private readonly int _min;
    private readonly int _max;
 
    public CodeRangeAttribute(int min, int max)
    {
        _min = min;
        _max = max;
    }
 
    public override bool IsValid(object value)
    {
        if (value is int code)
        {
            return code >= _min && code <= _max;
        }
 
        return false;
    }
}

class MaxLengthAttribute : System.Attribute 
{
    String ErrorMessage
}

class Device
{

[Required(ErrorMessage="ID Property Requires Value")]

  public string Id{ get;set;}
  
  [Range(10,100,"Code Value Must Be Within 10-100")]
  public int Code{get;set;}
  [MaxLength(100,"Max of 100 Charcters are allowed")]
  
  public string Description{get;set}
  
}

class Program{
    static void Main(){
        Device deviceObj=new Device();
        List<string> errors;
        bool isValid=ObjectValidator.Validate(deviceObj,out List<string> errors);
        if(!isValid){
            foreach (string item in errors)
            {
            System.Console.WriteLine(item);
                
            }
        }
    }
}
