using System.Runtime.Serialization;

namespace ZooManagement.Helpers
 {
    public enum Sex
    {
        [EnumMember(Value = "Male")]
        Male = 0,
        [EnumMember(Value = "Female")]
        Female = 1
    }
 }  
