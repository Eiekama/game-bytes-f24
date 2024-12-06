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
        //string filePath = Path.Combine(Application.dataPath,"Minigames","cs-get-degrees","StreamingAssets" ,"gates.csv");
        string data = @"id,operation,level,levelProb,portionRequest,combine,combineProb,combineID,gpaProb,minGpa,maxGpa,minFri,maxFri$
                        0,plus,1,50,4,TRUE,20,1 & 2,50,10,200,1,10$
                        1,sub,1,50,2,TRUE,20,2,50,10,400,1,10$
                        2,mult,2,50,2,TRUE,20,3,50,0,200,0,3$
                        3,div,2,50,2,TRUE,20,0 & 1 & 2,50,10,200,1,3$
                        4,exp,3,30,1,TRUE,20,1,50,0,200,0,4$
                        5,sqrt,3,30,1,TRUE,20,1,50,2,3,2,3$
                        6,log,4,15,1,TRUE,20,1,50,1,10,1,10$
                        7,e,4,15,1,TRUE,20,1,50,1,10,1,3$
                        8,naln,4,10,1,TRUE,20,1,50,1,20,1,20$
                        9,sin,5,30,1,TRUE,20,1,50,1,20,1,20$
                        9,cos,5,30,1,TRUE,20,1,50,1,20,1,20$
                        9,tan,5,30,1,TRUE,20,1,50,1,20,1,20$
                        10,con,6,30,1,TRUE,20,1,50,1,1,1,1";
        string[][] csvData;
        int rowCount = 0;
        int finalCount = 0;
        List<string[]> workingList = new List<string[]>();
        string[][] finalList;

        List<string[]> tempData = new List<string[]>();
        // Read the file content
        string[] rows = data.Split(new char[] {'$'});

        // Parse each row
        foreach (string row in rows)
        {
            string[] columns = row.Split(',');
            tempData.Add(columns);
            //Debug.Log(row);
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
            if (Int32.Parse(csvData[i][2]) <= level)
            {
                workingList.Add(csvData[i]);
            }
        }
        finalCount = workingList.Count;
        finalList = workingList.ToArray();

        int[] gateData = new int[] { 1, 1, 1, 2, 2, 3 };
        int gateCount = UnityEngine.Random.Range(1, 4);
        List<gateData> gates = new List<gateData>();
        for (int i = 0; i < gateCount; i++)
        {
            gates.Add(makeGate(finalList, finalCount));
        }
        gateObject returnData = new gateObject(gates, gateCount);
        return returnData;


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
            tot += (int)calc.amount;
        } else if (String.Equals(op, "sub"))
        {
            tot -= (int)calc.amount;
        }
        if (calc.people)
        {
            people += tot;
            if (String.Equals(op, "mult"))
            {
                people = (int)(people *  calc.amount);
            }
            else if (String.Equals(op, "div"))
            {
                if (calc.amount != 0)
                {
                    people = (int)(people * calc.amount);
                }
            }
            else if (String.Equals(op, "exp"))
            {
                people = (int)Math.Pow(people, calc.amount);
            }
            else if (String.Equals(op, "sqrt"))
            {
                people = (int)Math.Pow(people, 1.00 / (double)calc.amount);
            }
            else if (String.Equals(op, "naln"))
            {
                if (calc.amount != 0)
                {
                    people = (int)(calc.amount * Math.Log(people));
                }
            }
            else if (String.Equals(op, "e"))
            {
                people = (int)(calc.amount * Math.Pow(2.718281828459045f, people));
            }
            else if (String.Equals(op, "log"))
            {
                people = (int)(calc.amount * Math.Log10(people));
            }
            else if (String.Equals(op, "sin"))
            {
                people = (int)(calc.amount * Math.Sin(people));
            }
            else if (String.Equals(op, "cos"))
            {
                people = (int)(calc.amount * Math.Cos(people));
            }
            else if (String.Equals(op, "tan"))
            {
                people = (int)(calc.amount * Math.Tan(people));
            }
        }
        else
        {
            gpa += tot;
            if (String.Equals(op, "mult"))
            {
                gpa *= (int)(calc.amount/100);
            }
            else if (String.Equals(op, "div"))
            {
                if (calc.amount != 0) { gpa = ((int)((float)gpa / (calc.amount / 100.0f))); }
            }
            else if (String.Equals(op, "exp"))
            {
                gpa = (int)Math.Pow(people, (calc.amount/100.0));
            }
            else if (String.Equals(op, "sqrt"))
            {
                gpa = (int)Math.Pow(people, 1.00 / (double)calc.amount);
            }
            else if (String.Equals(op, "naln"))
            {
                if (calc.amount != 0) gpa = (int)((calc.amount) * Math.Log(gpa));
            }
            else if (String.Equals(op, "e"))
            {
                gpa = (int)(calc.amount * Math.Pow(2.718281828459045f, gpa));
            }
            else if (String.Equals(op, "log"))
            {
                gpa = (int)(calc.amount * Math.Log10(gpa));
            }
            else if (String.Equals(op, "sin"))
            {
                gpa = (int)(calc.amount * Math.Sin(gpa));
            }
            else if (String.Equals(op, "cos"))
            {
                gpa = (int)(calc.amount * Math.Cos(gpa));
            }
            else if (String.Equals(op, "tan"))
            {
                gpa = (int)(calc.amount * Math.Tan(gpa));
            }
        }
        if (people < 0)
        {
            people = 0;
        }
        if (gpa < 0)
        {
            gpa = 0;
        }
        if (gpa > 400)
        {
            gpa = 400;
        }
        return new changeData(people,gpa);
    }

    //Sets the gate data for the collision
    //Makes the text of the canvas on the gate show
    public static void setUpGate(GameObject gate, gateObject gateO)
    {
        for (int i=0; i<gateO.gateCount;i++)
        {
            BarrierStructure bs = gate.GetComponentsInChildren<BarrierStructure>()[i];
            bs.setGateData(gateO.gates.ToArray()[i]);
            /*GameObject gates = collide.GetComponentsInChildren<Transform>()[4].gameObject;
            Debug.Log(gates.name);
            GameObject canvas = gates.GetComponentInChildren<Canvas>().gameObject;
            TextMeshProUGUI gateText = canvas.GetComponentInChildren<TextMeshProUGUI>();*/
            TextMeshProUGUI gateText = bs.gameObject.GetComponentInChildren<TextMeshProUGUI>();
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
                people = isGpa > Int32.Parse(finalList[j][8]);
                int amount = 0;
                if (people)
                {
                    amount = UnityEngine.Random.Range(Int32.Parse(finalList[j][11]), Int32.Parse(finalList[j][12]));
                }
                else
                {
                    amount = UnityEngine.Random.Range(Int32.Parse(finalList[j][9]), Int32.Parse(finalList[j][10]));
                }
                calcualation newCalc = new calcualation(finalList[j][1], amount, people);
                calcList.Add(newCalc);
                totalPartition++;
            }
        }
        int finalSelection = UnityEngine.Random.Range(0, totalPartition);
        calcualation finalCalc = calcList.ToArray()[finalSelection];
        gateData returnGate = new gateData(finalCalc.people, finalCalc, convertCalculationToText(finalCalc));
        return returnGate;
    }

    private static string strConvert(int d, bool gpa, bool noFormat = false)
    {
        if (!gpa || noFormat)
        {
            return d.ToString();
        } else
        {
            return (d/100.0).ToString("0.00");
        }
    }

    private static string string_to_exponent(string input)
    {  
        string[] superscripts = { "⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹", "˙"};
        string total = "";
        char[] split = input.ToCharArray();
        for (int i=0; i<split.Length; i++)
        {
            if (split[i]=='.')
            {
                total += superscripts[10];
            } else
            {
                total += superscripts[Int32.Parse(split[i].ToString())];
            }

        }
        return total;

    }

    private static string hide_one(string input)
    {
        if (input == "1" || input == "1.00")
        {
            return "";
        }
        return input;
    }

    public static string convertCalculationToText(calcualation calc)
    {
        string op = calc.calc;
        string item = calc.people ? "friend" : "gpa";
        int am = (int)calc.amount;

        if (String.Equals(item, "friend") && am > 1)
        {
            item = "friends";
        }
        if (op == "plus")
        {
            return "+ " + strConvert(am, item=="gpa") + " " + item;
        }
        if (op == "sub")
        {
            return "- " + strConvert(am, item == "gpa") + " " + item;
        }
        if (op == "mult")
        {
            return "* " + strConvert(am, item == "gpa") + " " + item;
        }
        if (op == "div")
        {
            return "/ " + strConvert(am, item == "gpa") + " " + item;
        }
        if (op == "exp")
        {
            return "x" + string_to_exponent(strConvert(am, item == "gpa")) + " " + item;
        }
        if (op == "sqrt")
        {
            if (am == 3)
            {
                return "∛" + "x " + item;
            }
            return "√" + "x " + item;
        }
        if (op == "e")
        {
            return hide_one(strConvert(am, item == "gpa", true)) + "eˣ " + item;
        }
        if (op == "naln")
        {
            return hide_one(strConvert(am, item == "gpa", true)) + "ln|x| " + item;
        }
        if (op == "log")
        {
            return hide_one(strConvert(am, item == "gpa", true)) + "log(x) " + item;
        }
        if (op == "sin")
        {
            return hide_one(strConvert(am, item == "gpa", true)) + "sin(x) " + item;
        }
        if (op == "cos")
        {
            return hide_one(strConvert(am, item == "gpa", true)) + "cos(x) " + item;
        }
        if (op == "tan")
        {
            return hide_one(strConvert(am, item == "gpa", true)) + "tan(x) " + item;
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
    public float amount;
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


