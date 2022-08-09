using System;

namespace CheckersLib.BoardElements
{
    public enum MoveType
    {
        Cancel,
        Move,
        Attack,
        AttackWithContinue,
        MoveTransformation,
        AttackTransformation,
        AttackTransformationWithContinue
    }

    public static class MoveTypeMethods
    {
        public static bool IsMove(this MoveType move)
        {
            return move == MoveType.Move || 
                   move == MoveType.MoveTransformation;
        }

        public static bool IsAttack(this MoveType move)
        {
            return move == MoveType.Attack ||
                   move == MoveType.AttackTransformation ||
                   move == MoveType.AttackTransformationWithContinue ||
                   move == MoveType.AttackWithContinue;
        }

        public static bool IsContinueAttack(this MoveType move)
        {
            return move == MoveType.AttackTransformationWithContinue || 
                   move == MoveType.AttackWithContinue;
        }
    }
}
