using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public static class BlockInformations
{
    /// <summary>
    /// 
    /// </summary>
    private static readonly Dictionary<BlockType, bool[,]> childPositionData = new Dictionary<BlockType, bool[,]>()
    {
        // -----------  1 ----------
        {BlockType.Z1T01,new bool[1,1]
        {
            {true}
        }},
        
        // -----------  2 ----------
        {BlockType.Z2T01A0,new bool[1,2]
        {
            {true,true}
        }},
               
        {BlockType.Z2T01A90,new bool[2,1]
        {
            {true},
            {true}
        }},

        {BlockType.Z2T02A0,new bool[2,2]
        {
            {false,true},
            {true,false}
        }},

        {BlockType.Z2T02A90,new bool[2,2]
        {
            {true,false},
            {false,true}
        }},

        // -----------  3 ----------
       {BlockType.Z3T01A0,new bool[1,3]
        {
            {true,true,true}
        }},

        {BlockType.Z3T01A90,new bool[3,1]
        {
            {true},
            {true},
            {true}
        }},

        {BlockType.Z3T02A0,new bool[2,2]
        {
            {true,false},
            {true,true}
        }},

        {BlockType.Z3T02A90,new bool[2,2]
        {
            {true,true},
            {true,false}
        }},

        {BlockType.Z3T02A180,new bool[2,2]
        {
            {true,true},
            {false,true}
        }},

        {BlockType.Z3T02A270,new bool[2,2]
        {
            {false,true},
            {true,true}
        }},
        
        // -----------  4 ----------
        {BlockType.Z4T01A0,new bool[1,4]
        {
            {true,true,true,true}
        }},

        {BlockType.Z4T01A90,new bool[4,1]
        {
            {true},
            {true},
            {true},
            {true}
        }},

        {BlockType.Z4T02A0,new bool[3,3]
        {
            {false,false,true},
            {false,false,true},
            {false,true,true}
        }},

        {BlockType.Z4T02A90,new bool[3,3]
        {
            {false,false,false},
            {true,false,false},
            {true,true,true}
        }},

        {BlockType.Z4T02A180,new bool[3,3]
        {
            {true,true,false},
            {true,false,false},
            {true,false,false}
        }},

        {BlockType.Z4T02A270,new bool[3,3]
        {
            {true,true,true},
            {false,false,true},
            {false,false,false}
        }},

        {BlockType.Z4T03A0,new bool[2,3]
        {
            {true,true,true},
            {false,true,false}
        }},

        {BlockType.Z4T03A90,new bool[3,2]
        {
            {false,true},
            {true,true},
            {false,true}
        }},

        {BlockType.Z4T03A180,new bool[2,3]
        {
            {false,true,false},
            {true,true,true}
        }},

        {BlockType.Z4T03A270,new bool[3,2]
        {
            {true,false},
            {true,true},
            {true,false}
        }},

        {BlockType.Z4T04A0,new bool[3,3]
        {
            {true,false,false},
            {true,false,false},
            {true,true,false}
        }},

        {BlockType.Z4T04A90,new bool[3,3]
        {
            {true,true,true},
            {true,false,false},
            {false,false,false}
        }},

        {BlockType.Z4T04A180,new bool[3,3]
        {
            {false,true,true},
            {false,false,true},
            {false,false,true}
        }},

        {BlockType.Z4T04A270,new bool[3,3]
        {
            {false,false,false},
            {false,false,true},
            {true,true,true}
        }},

        {BlockType.Z4T05A0,new bool[2,3]
        {
            {false,true,true},
            {true,true,false}
        }},

        {BlockType.Z4T05A90,new bool[3,2]
        {
            {true,false},
            {true,true},
            {false,true}
        }},

        {BlockType.Z4T06A0,new bool[2,3]
        {
            {true,true,false},
            {false,true,true}
        }},

        {BlockType.Z4T06A90,new bool[3,2]
        {
            {false,true},
            {true,true},
            {true,false}
        }},

        {BlockType.Z4T07,new bool[2,2]
        {
            {true,true},
            {true,true}
        }},

       // -----------  5 ----------
        {BlockType.Z5T01A0,new bool[1,5]
        {
            {true,true,true,true,true}
        }},

        {BlockType.Z5T01A90,new bool[5,1]
        {
            {true},
            {true},
            {true},
            {true},
            {true}
        }},

        {BlockType.Z5T02A0,new bool[2,4]
        {
            {true,false,false,false },
            {true,true,true, true}
        }},

        {BlockType.Z5T02A90,new bool[4,2]
        {
            {true,true },
            {true,false },
            {true,false },
            {true,false}
        }},

        {BlockType.Z5T02A180,new bool[2,4]
        {
            {true,true,true,true},
            {false,false,false,true }
        }},

        {BlockType.Z5T02A270,new bool[4,2]
        {
            {false,true },
            {false,true },
            {false,true },
            {true,true}
        }},

        {BlockType.Z5T03A0,new bool[2,4]
        {
            {false,true,false,false },
            {true,true,true, true}
        }},

        {BlockType.Z5T03A90,new bool[4,2]
        {
            {true,false },
            {true,true },
            {true,false },
            {true,false}
        }},

        {BlockType.Z5T03A180,new bool[2,4]
        {
            {true,true,true,true},
            {false,false,true,false }
        }},

        {BlockType.Z5T03A270,new bool[4,2]
        {
            {false,true },
            {false,true },
            {true,true },
            {false,true}
        }},

        {BlockType.Z5T04A0,new bool[2,4]
        {
            {false,false,true,false },
            {true,true,true, true}
        }},

        {BlockType.Z5T04A90,new bool[4,2]
        {
            {true,false },
            {true,false },
            {true,true },
            {true,false}
        }},

        {BlockType.Z5T04A180,new bool[2,4]
        {
            {true,true,true,true},
            {false,true,false,false }
        }},

        {BlockType.Z5T04A270,new bool[4,2]
        {
            {false,true },
            {true,true },
            {false,true },
            {false,true}
        }},


        {BlockType.Z5T05A0,new bool[2,4]
        {
            {false,false,false,true },
            {true,true,true, true}
        }},

        {BlockType.Z5T05A90,new bool[4,2]
        {
            {true,false },
            {true,false },
            {true,false },
            {true,true}
        }},

        {BlockType.Z5T05A180,new bool[2,4]
        {
            {true,true,true,true},
            {true,false,false,false }
        }},

        {BlockType.Z5T05A270,new bool[4,2]
        {
            {true,true },
            {false,true },
            {false,true },
            {false,true}
        }},

        {BlockType.Z5T06A0,new bool[2,3]
        {
            {true,true,false},
            {true,true,true}
        }},

        {BlockType.Z5T06A90,new bool[3,2]
        {
            {true,true},
            {true,true},
            {true,false}
        }},

        {BlockType.Z5T06A180,new bool[2,3]
        {
            {true,true,true},
            {false,true,true}
        }},

        {BlockType.Z5T06A270,new bool[3,2]
        {
            {false,true},
            {true,true},
            {true,true}
        }},

        {BlockType.Z5T07A0,new bool[2,3]
        {
            {true,false,true},
            {true,true,true}
        }},

        {BlockType.Z5T07A90,new bool[3,2]
        {
            {true,true},
            {true,false},
            {true,true}
        }},

        {BlockType.Z5T07A180,new bool[2,3]
        {
            {true,true,true},
            {true,false,true}
        }},

        {BlockType.Z5T07A270,new bool[3,2]
        {
            {true,true},
            {false,true},
            {true,true}
        }},

        {BlockType.Z5T08A0,new bool[2,3]
        {
            {false,true,true},
            {true,true,true}
        }},

        {BlockType.Z5T08A90,new bool[3,2]
        {
            {true,false},
            {true,true},
            {true,true}
        }},

        {BlockType.Z5T08A180,new bool[2,3]
        {
            {true,true,true},
            {true,true,false}
        }},

        {BlockType.Z5T08A270,new bool[3,2]
        {
            {true,true},
            {true,true},
            {false,true}
        }},

        {BlockType.Z5T09A0,new bool[3,3]
        {
            {true,true,true},
            {false,true,false},
            {false,true,false}
        }},

        {BlockType.Z5T09A90,new bool[3,3]
        {
            {false,false,true},
            {true,true,true},
            {false,false,true}
        }},

        {BlockType.Z5T09A180,new bool[3,3]
        {
            {false,true,false},
            {false,true,false},
            {true,true,true}
        }},

        {BlockType.Z5T09A270,new bool[3,3]
        {
            {true,false,false},
            {true,true,true},
            {true,false,false}
        }},


        {BlockType.Z5T10A0,new bool[3,3]
        {
            {true,false,false},
            {true,true,true},
            {false,true,false}
        }},

        {BlockType.Z5T10A90,new bool[3,3]
        {
            {false,true,true},
            {true,true,false},
            {false,true,false}
        }},

        {BlockType.Z5T10A180,new bool[3,3]
        {
            {false,true,false},
            {true,true,true},
            {false,false,true}
        }},

        {BlockType.Z5T10A270,new bool[3,3]
        {
            {false,true,false},
            {false,true,true},
            {true,true,false}
        }},

        {BlockType.Z5T11A0,new bool[3,3]
        {
            {true,false,false},
            {true,true,true},
            {false,false,true}
        }},

        {BlockType.Z5T11A90,new bool[3,3]
        {
            {false,true,true},
            {false,true,false},
            {true,true,false}
        }},

        {BlockType.Z5T12A0,new bool[3,3]
        {
            {false,false,true},
            {true,true,true},
            {true,false,false}
        }},

        {BlockType.Z5T12A90,new bool[3,3]
        {
            {true,true,false},
            {false,true,false},
            {false,true,true}
        }},

        {BlockType.Z5T13A0,new bool[3,3]
        {
            {false,false,true},
            {true,true,true},
            {false,true,false}
        }},

        {BlockType.Z5T13A90,new bool[3,3]
        {
            {false,true,false},
            {true,true,false},
            {false,true,true}
        }},

        {BlockType.Z5T13A180,new bool[3,3]
        {
            {false,true,false},
            {true,true,true},
            {true,false,false}
        }},

        {BlockType.Z5T13A270,new bool[3,3]
        {
            {true,true,false},
            {false,true,true},
            {false,true,false}
        }},

        {BlockType.Z5T14,new bool[3,3]
        {
            {true,false,true},
            {false,true,false},
            {true,false,true}
        }},

        {BlockType.Z5T15A0,new bool[3,3]
        {
            {true,false,false},
            {true,true,false},
            {false,true,true}
        }},

        {BlockType.Z5T15A90,new bool[3,3]
        {
            {false,true,true},
            {true,true,false},
            {true,false,false}
        }},

        {BlockType.Z5T15A180,new bool[3,3]
        {
            {true,true,false},
            {false,true,true},
            {false,false,true}
        }},

        {BlockType.Z5T15A270,new bool[3,3]
        {
            {false,false,true},
            {false,true,true},
            {true,true,false}
        }},

       {BlockType.Z5T16A0,new bool[3,3]
        {
            {true,false,false},
            {true,false,false},
            {true,true,true}
        }},

        {BlockType.Z5T16A90,new bool[3,3]
        {
            {true,true,true},
            {true,false,false},
            {true,false,false}
        }},

        {BlockType.Z5T16A180,new bool[3,3]
        {
            {true,true,true},
            {false,false,true},
            {false,false,true}
        }},

        {BlockType.Z5T16A270,new bool[3,3]
        {
            {false,false,true},
            {false,false,true},
            {true,true,true}
        }},

        {BlockType.Z5T17,new bool[3,3]
        {
            {false,true,false},
            {true,true,true},
            {false,true,false}
        }},

        {BlockType.Z5T18A0,new bool[3,3]
        {
            {true,false,true},
            {true,true,false},
            {false,true,false}
        }},

        {BlockType.Z5T18A90,new bool[3,3]
        {
            {false,true,true},
            {true,true,false},
            {false,false,true}
        }},

        {BlockType.Z5T18A180,new bool[3,3]
        {
            {false,true,false},
            {false,true,true},
            {true,false,true}
        }},

        {BlockType.Z5T18A270,new bool[3,3]
        {
            {true,false,false},
            {false,true,true},
            {true,true,false}
        }},

        {BlockType.Z5T19A0,new bool[3,3]
        {
            {true,false,true},
            {false,true,true},
            {false,true,false}
        }},

        {BlockType.Z5T19A90,new bool[3,3]
        {
            {false,false,true},
            {true,true,false},
            {false,true,true}
        }},

        {BlockType.Z5T19A180,new bool[3,3]
        {
            {false,true,false},
            {true,true,false},
            {true,false,true}
        }},

        {BlockType.Z5T19A270,new bool[3,3]
        {
            {true,true,false},
            {false,true,true},
            {true,false,false}
        }},

        {BlockType.None,new bool[1,1]
        {
            {true}
        }},
    };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="blockType"></param>
    /// <returns></returns>
    public static bool[,] GetChildPositionData(BlockType blockType)
    {
        return childPositionData[blockType];
    }
}
