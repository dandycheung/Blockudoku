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
        {BlockType.Single,new bool[1,1]
        {
            {true}
        }},
        
        {BlockType.DoubleLine2x1ZeroDegree,new bool[1,2]
        {
            {true,true}
        }},
        
        {BlockType.TripleLine3x1ZeroDegree,new bool[1,3]
        {
            {true,true,true}
        }},
        
        {BlockType.QuadrupleLine4x1ZeroDegree,new bool[1,4]
        {
            {true,true,true,true}
        }},
        
        {BlockType.QuintetLine5x1ZeroDegree,new bool[1,5]
        {
            {true,true,true,true,true}
        }},
        
        {BlockType.DoubleLine1x2NintyDegree,new bool[2,1]
        {
            {true},
            {true}
        }},
        
        {BlockType.TripleLine1x3NintyDegree,new bool[3,1]
        {
            {true},
            {true},
            {true}
        }},
        
        {BlockType.QuadrupleLine1x4NintyDegree,new bool[4,1]
        {
            {true},
            {true},
            {true},
            {true}
        }},
        
        {BlockType.QuintetLine1x5NintyDegree,new bool[5,1]
        {
            {true},
            {true},
            {true},
            {true},
            {true}
        }},
        
        {BlockType.ShortL2x2ZeroDegree,new bool[2,2]
        {
            {true,false},
            {true,true}
        }},
        
        {BlockType.ShortL2x2NintyDegree,new bool[2,2]
        {
            {true,true},
            {true,false}
        }},
        
        {BlockType.ShortL2x2HundredAndEightyDegree,new bool[2,2]
        {
            {true,true},
            {false,true}
        }},
        
        {BlockType.ShortL2x2TwoHundredAndSeventyDegree,new bool[2,2]
        {
            {false,true},
            {true,true}
        }},
        
        {BlockType.LongL3x3ZeroDegree,new bool[3,3]
        {
            {true,false,false},
            {true,false,false},
            {true,true,true}
        }},
        
        {BlockType.LongL3x3NintyDegree,new bool[3,3]
        {
            {true,true,true},
            {true,false,false},
            {true,false,false}
        }},
 
        {BlockType.LongL3x3HundredAndEightyDegree,new bool[3,3]
        {
            {true,true,true},
            {false,false,true},
            {false,false,true}
        }},
 
        {BlockType.LongL3x3TwoHundredAndSeventyDegree,new bool[3,3]
        {
            {false,false,true},
            {false,false,true},
            {true,true,true}
        }},

        {BlockType.ShortT2x3ZeroDegree,new bool[2,3]
        {
            {true,true,true},
            {false,true,false}
        }},
        
        {BlockType.ShortT3x2NintyDegree,new bool[3,2]
        {
            {false,true},
            {true,true},
            {false,true}
        }},
        
        {BlockType.ShortT2x3HundredAndEightyDegree,new bool[2,3]
        {
            {false,true,false},
            {true,true,true}
        }},
        
        {BlockType.ShortT3x2TwoHundredAndSeventyDegree,new bool[3,2]
        {
            {true,false},
            {true,true},
            {true,false}
        }},

        {BlockType.Shorth2x3ZeroDegree,new bool[2,3]
        {
            {true,true,false},
            {false,true,true}
        }},

        {BlockType.Shorth3x2NintyDegree,new bool[3,2]
        {
            {false,true},
            {true,true},
            {true,false}
        }},

        {BlockType.Shorth2x3HundredAndEightyDegree,new bool[2,3]
        {
            {false,true,true},
            {true,true,false}
        }},

        {BlockType.Shorth3x2TwoHundredAndSeventyDegree,new bool[3,2]
        {
            {true,false},
            {true,true},
            {false,true}
        }},

        {BlockType.LongT3x3ZeroDegree,new bool[3,3]
        {
            {true,true,true},
            {false,true,false},
            {false,true,false}
        }},
        
        {BlockType.LongT3x3NintyDegree,new bool[3,3]
        {
            {false,false,true},
            {true,true,true},
            {false,false,true}
        }},

        {BlockType.LongT3x3HundredAndEightyDegree,new bool[3,3]
        {
            {false,true,false},
            {false,true,false},
            {true,true,true}
        }},

        {BlockType.LongT3x3TwoHundredAndSeventyDegree,new bool[3,3]
        {
            {true,false,false},
            {true,true,true},
            {true,false,false}
        }},

        {BlockType.Cross2x2ZeroDegree,new bool[2,2]
        {
            {false,true},
            {true,false}
        }},
        
        {BlockType.Cross2x2HundredAndEightyDegree,new bool[2,2]
        {
            {true,false},
            {false,true}
        }},
        
        {BlockType.Square2x2,new bool[2,2]
        {
            {true,true},
            {true,true}
        }},
        
        {BlockType.Cross3x3,new bool[3,3]
        {
            {false,true,false},
            {true,true,true},
            {false,true,false}
        }},
        
        {BlockType.Square3x3,new bool[3,3]
        {
            {true,true,true},
            {true,true,true},
            {true,true,true}
        }}

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
