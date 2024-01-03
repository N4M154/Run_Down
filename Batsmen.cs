

namespace scoreboard
{
    public class Batsman
    {
        public string Name { get; set; }
        public int Runs { get; set; }

        public Batsman(string name)
        {
            Name = name;
            Runs = 0;
        }

        public void AddRuns(int runs)
        {
            Runs += runs;
        }
    }
}
