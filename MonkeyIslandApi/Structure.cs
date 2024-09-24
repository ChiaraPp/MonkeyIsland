namespace MonkeyIslandApi
{
    public class Structure
    {
        public class GetReturnStructure
        {
            public int[] magicNumbers {  get; set; }
        }

        public class PostStructure 
        { 
            public int sum {  get; set; }
            public string callBackUrl { get; set; }
        }

    }
}
