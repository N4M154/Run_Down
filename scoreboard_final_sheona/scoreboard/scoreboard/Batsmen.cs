

namespace scoreboard
{
    public class Batsman
    {
        public string Name { get; private set; }
        private int runs;
        public Batsman(string name)
        {
            Name = name;
            runs = 0;
        }
        //public Batsman() { }

        public int Runs
        {
            get { return runs; }
        }
        public void AddRuns(int score)
        {
            runs += score;
        }
        
    }
}
