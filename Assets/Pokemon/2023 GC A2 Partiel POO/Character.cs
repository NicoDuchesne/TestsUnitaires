﻿using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        private int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        private int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        private int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        private int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        private TYPE _baseType;
        /// <summary>
        /// Vie actuelle
        /// </summary>
        private int _currentHealth;
        /// <summary>
        /// Vie actuelle
        /// </summary>
        private Equipment _currentEquipment;
        /// <summary>
        /// Effet actuel
        /// </summary>
        private StatusEffect _currentStatus;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            _currentHealth = baseHealth;
        }

        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                if (_currentHealth < 0)
                {
                    _currentHealth = 0;
                }
                CheckOverHealth();
            }
        }
        public TYPE BaseType { get => _baseType; }
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                int result = _baseHealth;
                if (IsEquiped)
                {
                    result += _currentEquipment.BonusHealth;
                }
                return result;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                int result = _baseAttack;
                if (IsEquiped)
                {
                    result += _currentEquipment.BonusAttack;
                }
                return result;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                int result = _baseDefense;
                if (IsEquiped)
                {
                    result += _currentEquipment.BonusDefense;
                }
                return result;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                int result = _baseSpeed;
                if (IsEquiped)
                {
                    result += _currentEquipment.BonusSpeed;
                }
                return result;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get => _currentEquipment; private set => _currentEquipment = value; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get => _currentStatus; private set => _currentStatus = value; }

        public bool IsAlive => _currentHealth > 0;
        public bool IsEquiped => _currentEquipment != null;

        public void CheckOverHealth()
        {
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

    /// <summary>
    /// Application d'un skill contre le personnage
    /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
    /// Vous pouvez adapter au besoin
    /// </summary>
    /// <param name="s">skill attaquant</param>
    /// <exception cref="NotImplementedException"></exception>
    public void ReceiveAttack(Skill s)
        {
            int skillDamage = s.Power - Defense;
            CurrentHealth = CurrentHealth - skillDamage;
            CurrentStatus = StatusEffect.GetNewStatusEffect(s.Status);
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if(newEquipment == null)
            {
                throw new ArgumentNullException();
            }
            CurrentEquipment = newEquipment;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
            CheckOverHealth();
        }

        public void Heal(int healing)
        {
            CurrentHealth = CurrentHealth + healing;
        }

        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)

    }
}
