using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public static class GateDataController
{
    //You may use the following two functions by calling


    //GateDataController.getGateData(<level>)
    //Returns the gateObject class that you can use which specifies the gate count and random data for it

    //GateDataController.doCalculation(<people>, <gpa>, <calculation>)
    //Returns a changeData class which you can access the new data to set people and gpa to


    //GateDataController.setGateData(<gate>,<gateObject>)
    //Sets up a new gate so that it has the right data and that it shows the right text

    //Get the data for a new gate
    //Enter a level 0<=level<=max
    //Returns the gateObject class
    public static gateObject getGateData(int level)
    {
        // Load the CSV file as a TextAsset (from Resources folder)
        string filePath = Path.Combine(Application.dataPath,"Minigames","cs-get-degrees","StreamingAssets" ,"gates.csv");

        string[][] csvData;
        int rowCount = 0;
        int finalCount = 0;
        List<string[]> workingList = new List<string[]>();
        string[][] finalList;

        if (File.Exists(filePath))
        {
            List<string[]> tempData = new List<string[]>();
            // Read the file content
            string[] rows = File.ReadAllLines(filePath);

            // Parse each row
            foreach (string row in rows)
            {
                string[] columns = row.Split(',');
                tempData.Add(columns);

                /*// Output each column value
                foreach (string column in columns)
                {
                    Debug.Log(column);
                }*/
            }
            rowCount = tempData.Count;
            csvData = tempData.ToArray();

            for (int i = 1; i < rowCount; i++)
            {
                if (Int32.Parse(csvData[i][2]) == level) {
                    workingList.Add(csvData[i]);
                }
            }
            finalCount = workingList.Count;
            finalList = workingList.ToArray();

            int[] gateData = new int[] {1,1,1,2,2,3};
            int gateCount = UnityEngine.Random.Range(1, 4);
            List<gateData> gates = new List<gateData>();
            for (int i=0; i<gateCount;i++)
            {
                gates.Add(makeGate(finalList,finalCount));
            }
            gateObject returnData = new gateObject(gates, gateCount);
            return returnData;

        }
        else
        {
            Debug.LogError("CSV file not found!");
        }


        return new gateObject(new List<gateData>(), 1);
    }


    //Give the current number of people or gpa with the calculation
    //Returns the number to set the gpa and people to
    public static changeData doCalculation(int people, int gpa, calcualation calc)
    {
        int tot = 0;
        string op = calc.calc;
        if (String.Equals(op, "plus"))
        {
            tot += calc.amount;
        } else if (String.Equals(op, "minus"))
        {
            tot -= calc.amount;
        }
        if (calc.people)
        {
            people += tot;
        } else
        {
            gpa += tot;
        }
        return new changeData(people,tot);
    }

    //Sets the gate data for the collision
    //Makes the text of the canvas on the gate show
    public static void setUpGate(GameObject gate, gateObject gateO)
    {
        for (int i=0; i<gateO.gateCount;i++)
        {
            GameObject collide = gate.GetComponentsInChildren<Transform>()[i].gameObject;
            //collide.GetComponent<BarrierStructure>().gateData = gateO.gates.ToArray()[0];
            TextMeshProUGUI gateText = collide.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Canvas>()[0].GetComponentsInChildren<TextMeshProUGUI>()[0];
            gateText.text = gateO.gates.ToArray()[i].gateText;
        }
    }

    //DO NOT TOUCH BELOW THIS LINE
    //============================================================================
    //============================================================================
    //============================================================================
    //============================================================================
    //DO NOT TOUCH BELOW THIS LINE

    //PRIVATE DO NOT USE
    public static gateData makeGate(string[][] finalList, int finalCount)
    {
        //Partitioning for randomness
        int totalPartition = 0;
        List<calcualation> calcList = new List<calcualation>();
        for (int j = 0; j < finalCount; j++)
        {
            for (int k = 0; k < Int32.Parse(finalList[j][4]); k++)
            {
                int isGpa = UnityEngine.Random.Range(0, 100);
                bool people;
                people = isGpa > Int32.Parse(finalList[k][8]);
                int amount = 0;
                if (people)
                {
                    amount = UnityEngine.Random.Range(Int32.Parse(finalList[k][11]), Int32.Parse(finalList[k][12]));
                }
                else
                {
                    amount = UnityEngine.Random.Range(Int32.Parse(finalList[k][9]), Int32.Parse(finalList[k][10]));
                }
                calcualation newCalc = new calcualation(finalList[k][1], amount, people);
                calcList.Add(newCalc);
                totalPartition++;
            }
        }
        int finalSelection = UnityEngine.Random.Range(0, totalPartition);
        calcualation finalCalc = calcList.ToArray()[finalSelection];
        gateData returnGate = new gateData(finalCalc.people, finalCalc, convertCalculationToText(finalCalc));
        return returnGate;
    }

    public static string convertCalculationToText(calcualation calc)
    {
        string op = calc.calc;
        string item = calc.people ? "friend" : "gpa";
        int am = calc.amount;
        if (String.Equals(item, "friend") && am > 1)
        {
            item = "friends";
        }
        if (op == "plus")
        {
            return "+ " + am.ToString() + " " + item;
        }
        if (op == "sub")
        {
            return "- " + am.ToString() + " " + item;
        }
        return "ERROR";
    }
}



public class gateData
{
    public bool people;
    public calcualation calculation;
    public string gateText;
    public gateData(bool p, calcualation c, string gateText)
    {
        this.people = p;
        this.calculation = c;
        this.gateText = gateText;
    }
}

public class gateObject
{
    public int gateCount;
    public List<gateData> gates = new List<gateData>();
    public gateObject(List<gateData> gates, int gCount)
    {
        this.gateCount = gCount;
        this.gates = gates;
    }
}

public class calcualation
{
    public string calc;
    public int amount;
    public bool people;
    public calcualation(string c, int amount, bool people)
    {
        this.calc = c;
        this.amount = amount;
        this.people = people;
    }
}

public class changeData
{
    public int newPeople;
    public int newGpa;
    public changeData(int p, int g)
    {
        this.newPeople = p;
        this.newGpa = g;
    }
}


