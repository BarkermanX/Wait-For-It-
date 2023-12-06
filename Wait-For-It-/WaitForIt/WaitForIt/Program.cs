
string strFilePath = "TestData.txt";
List<String> lstLines = new List<string>();
List<Race> lstRaces = new List<Race>();

using (StreamReader sr = new StreamReader(strFilePath))
{
    // Read the file line by line
    string line;
    while ((line = sr.ReadLine()) != null)
    {
        lstLines.Add(line);
        
    }
}

decimal[] aTime = lstLines[0]
            .Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1) // Skip the first element ("Time:")
            .Select(decimal.Parse)
            .ToArray();

decimal[] aDistance = lstLines[1]
            .Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1) // Skip the first element ("Distance:")
            .Select(decimal.Parse)
            .ToArray();

decimal iArraySize = aDistance.Length;

for(int iLoop = 0; iLoop< iArraySize; iLoop++)
{
    Race objRace = new Race(aTime[iLoop], aDistance[iLoop]);
    lstRaces.Add(objRace);
}

//Your toy boat has a starting speed of zero millimeters per millisecond.
//For each whole millisecond you spend at the beginning of the race holding down the button,
//the boat's speed increases by one millimeter per millisecond.



//Hold the button for 1 millisecond at the start of the race. Then, the boat will travel at a speed of 1 millimeter per millisecond for 6 milliseconds, reaching a total distance traveled of 6 millimeters.
//Hold the button for 2 milliseconds, giving the boat a speed of 2 millimeters per millisecond. It will then get 5 milliseconds to move, reaching a total distance of 10 millimeters.
//Hold the button for 3 milliseconds. After its remaining 4 milliseconds of travel time, the boat will have gone 12 millimeters.
//Hold the button for 4 milliseconds. After its remaining 3 milliseconds of travel time, the boat will have gone 12 millimeters.
//Hold the button for 5 milliseconds, causing the boat to travel a total of 10 millimeters.
//Hold the button for 6 milliseconds, causing the boat to travel a total of 6 millimeters.
//Hold the button for 7 milliseconds. That's the entire duration of the race. You never let go of the button. The boat can't move until you let go of the button. Please make sure you let go of the button so the boat gets to move. 0 millimeters.

decimal iMarginError = 1;

foreach (Race objRace in lstRaces)
{
    for(decimal iButtonHold=1; iButtonHold < objRace.RaceTime; iButtonHold++)
    {
        decimal iFinishDistance = Helper.getFinishDistance(iButtonHold, iButtonHold, objRace.RaceTime);

        if (iFinishDistance > objRace.RecordDistance)
        {
            objRace.lstButonHoldTimeToBeatRecord.Add(iButtonHold);
        }
    }

    iMarginError = iMarginError * objRace.lstButonHoldTimeToBeatRecord.Count;
}






decimal iReturn = Helper.getFinishDistance(1, 1, 7);
iReturn = Helper.getFinishDistance(2, 2, 7);
iReturn = Helper.getFinishDistance(3, 3, 7);
iReturn = Helper.getFinishDistance(4, 4, 7);
iReturn = Helper.getFinishDistance(5, 5, 7);
iReturn = Helper.getFinishDistance(6, 6, 7);
iReturn = Helper.getFinishDistance(7, 7, 7);

Console.WriteLine("END");


public class Race
{
    public decimal RaceTime;
    public decimal RecordDistance;
    public List<decimal> lstButonHoldTimeToBeatRecord = new List<decimal>();

    public Race(decimal iRaceTime, decimal iRecordDistance)
    {
        RaceTime = iRaceTime;
        RecordDistance = iRecordDistance;
    }
} 


public static class Helper
{
    public static decimal getFinishDistance(decimal iTimeHeldButton, decimal iSpeed, decimal iRaceTime)
    {
        decimal iMovingTime = iRaceTime - iTimeHeldButton;
        return iMovingTime * iSpeed;
    } 

    public static decimal getdecimal()
    {
        return 0;
    }
}