
using System;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        /// <summary>
        /// Premier Pokemon
        /// </summary>
        private Character _character1;
        /// <summary>
        /// Premier Pokemon
        /// </summary>
        private Character _character2;
        public Fight(Character character1, Character character2)
        {
            if (character1 == null || character2 == null)
            {
                throw new ArgumentNullException();
            }
            Character1 = character1;
            Character2 = character2;
        }

        public Character Character1 { get => _character1; private set => _character1 = value; }
        public Character Character2 { get => _character2; private set => _character2 = value;  }
        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished => !_character1.IsAlive || !_character2.IsAlive;

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="s1">L'attaque selectionné par le joueur 1</param>
        /// <param name="s2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill s1, Skill s2)
        {
            bool Char1Priority = false;
            bool Char2Priority = false;

            if (Character1.IsEquiped)
            {
                if (Character1.CurrentEquipment.SpecialEffect == SpecialEffect.RAZORCLAW)
                {
                    Char1Priority = true;
                }
            }

            if (Character2.IsEquiped)
            {
                if (Character2.CurrentEquipment.SpecialEffect == SpecialEffect.RAZORCLAW)
                {
                    Char2Priority = true;
                }
            }


            if (Char1Priority && !Char2Priority)
            {
                Char1First(s1, s2);
            } else if (!Char1Priority && Char2Priority)
            {
                Char2First(s1, s2);
            } else
            {
                NormalTurn(s1, s2);
            }

        }

        private void NormalTurn(Skill s1, Skill s2)
        {
            if (_character1.Speed >= _character2.Speed)
            {
                Char1First(s1, s2);
            }
            else
            {
                Char2First(s1, s2);
            }
            if (IsFightFinished) return;
        }

        private void Char1First(Skill s1, Skill s2)
        {
            _character2.ReceiveAttack(s1);
            if (IsFightFinished) return;
            _character1.ReceiveAttack(s2);
            if (IsFightFinished) return;
        }

        private void Char2First(Skill s1, Skill s2)
        {
            _character1.ReceiveAttack(s2);
            if (IsFightFinished) return;
            _character2.ReceiveAttack(s1);
            if (IsFightFinished) return;
        }


    }
}
