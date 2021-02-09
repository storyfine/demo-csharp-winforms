using StoryFine;

namespace SFDemo
{
    class GameEpisode : ISFEpisode
    {
        public SFSearcher IS_CURRENT_TIME_EVEN;
        
        public SFEntry entry;
        public SFCheckpoint PLAYER_ENTER_FIRST;
        public SFCondition EVEN_CONDITION;
        public SFChoice IF_EVEN_CHOICE;
        public SFCheckpoint EVEN_STEP_1;
        public SFCheckpoint EVEN_STEP_2_FINAL;
        public SFCheckpoint EVEN_FINAL;
        public SFCheckpoint NOT_EVEN_FINAL;
        
        public GameEpisode(SFSearcher.LogicSearcher _ls)
        {
            IS_CURRENT_TIME_EVEN = new SFSearcher("IS_CURRENT_TIME_EVEN", _ls);
            
            entry = new SFEntry("entry");
            PLAYER_ENTER_FIRST = new SFCheckpoint("PLAYER_ENTER_FIRST",entry,false);
            EVEN_CONDITION = new SFCondition("EVEN_CONDITION",PLAYER_ENTER_FIRST,IS_CURRENT_TIME_EVEN);
            IF_EVEN_CHOICE = new SFChoice("IF_EVEN_CHOICE",EVEN_CONDITION);
            EVEN_STEP_1 = new SFCheckpoint("EVEN_STEP_1",IF_EVEN_CHOICE,false);
            EVEN_STEP_2_FINAL = new SFCheckpoint("EVEN_STEP_2_FINAL",EVEN_STEP_1,true);
            EVEN_STEP_1.Next = EVEN_STEP_2_FINAL;
            IF_EVEN_CHOICE.A = EVEN_STEP_1;
            EVEN_FINAL = new SFCheckpoint("EVEN_FINAL",IF_EVEN_CHOICE,true);
            IF_EVEN_CHOICE.B = EVEN_FINAL;
            EVEN_CONDITION.Then = IF_EVEN_CHOICE;
            NOT_EVEN_FINAL = new SFCheckpoint("NOT_EVEN_FINAL",EVEN_CONDITION,true);
            EVEN_CONDITION.Else = NOT_EVEN_FINAL;
            PLAYER_ENTER_FIRST.Next = EVEN_CONDITION;
            entry.Next = PLAYER_ENTER_FIRST;
        }
    }
}