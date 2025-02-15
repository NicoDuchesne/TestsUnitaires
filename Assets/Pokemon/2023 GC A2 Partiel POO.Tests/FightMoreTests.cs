﻿using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using System;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
        // si on selectionne une attack qui a 0 PP on inflige 0

        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
        // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
        // de ces anciens TU pour ta nouvelle situation.

        [Test]
        public void NoOverHeal()
        {
            var pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);

            //Can't Overheal
            pikachu.Heal(100);
            Assert.That(pikachu.CurrentHealth, Is.EqualTo(100));

            //Don't stay overhealed after unequipping
            var e = new Equipment(100, 90, 70, 12);
            pikachu.Equip(e);
            pikachu.Heal(300);
            Assert.That(pikachu.CurrentHealth, Is.EqualTo(200));
            pikachu.Unequip();
            Assert.That(pikachu.CurrentHealth, Is.EqualTo(100));
        }

        [Test]
        public void TestRazorClawEffect()
        {
            //Dans pokemon Razor Claw est un equipement qui permet d'attaquer en premier
            Character pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
            Character mewtwo = new Character(100, 50, 30, 200, TYPE.NORMAL);

            //0 speed equipment but RazorClaw Special effect
            Equipment razorClaw = new Equipment(100, 90, 70, 0, SpecialEffect.RAZORCLAW);
            pikachu.Equip(razorClaw);

            //First Fight
            Fight f = new Fight(pikachu, mewtwo);
            MegaPunch mp = new MegaPunch();
            f.ExecuteTurn(mp, mp);

            //Pikachu wins thanks to razorClaw 
            Assert.That(pikachu.IsAlive, Is.EqualTo(true));
            Assert.That(mewtwo.IsAlive, Is.EqualTo(false));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));

            ////Second Fight but no razorClaw for pikachu
            mewtwo.Heal(1000);
            pikachu.Unequip();
            f = new Fight(pikachu, mewtwo);
            f.ExecuteTurn(mp, mp);

            ////This Time Pikachu looses
            Assert.That(pikachu.IsAlive, Is.EqualTo(false));
            Assert.That(mewtwo.IsAlive, Is.EqualTo(true));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));

        }
    }
}
