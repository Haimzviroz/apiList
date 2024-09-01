namespace mvcList.Models
{
    /// <summary>
    /// מתכון
    /// </summary>
    public class recipesList
    {
        public int id { get; set; }
        public string name { get; set; }
        /// <summary>
        /// rרכיבים
        /// </summary>
        public List<string> components { get; set; }
        /// <summary>
        /// פעולות
        /// </summary>
        public List<string> operations { get; set; }
        public string PhotoUrl { get; set; }

    }
}
