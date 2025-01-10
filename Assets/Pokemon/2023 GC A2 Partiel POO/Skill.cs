
namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition abstraite d'une compétence.
    /// </summary>
    public abstract class Skill
    {
        /// <summary>
        ///le type du skill
        /// </summary>
        protected TYPE _type;
        /// <summary>
        /// La puissance du skill
        /// </summary>
        protected int _power;
        /// <summary>
        /// Le status infligé par le skill
        /// </summary>
        protected StatusPotential _status;
        public Skill(TYPE type, int power, StatusPotential status)
        {
            Type = type;
            Power = power;
            Status = status;
        }

        /// <summary>
        /// Le type de l'attaque, à prendre en compte lors de la résolution des résistance/faiblesses
        /// </summary>
        public TYPE Type { get => _type; private set => _type = value; }
        /// <summary>
        /// La puissance du coup, à prendre en compte lors de la résolution des dégâts
        /// </summary>
        public int Power { get => _power; private set => _power = value; }
        /// <summary>
        /// Le statut infligé à la cible à la suite de l'attaque
        /// </summary>
        public StatusPotential Status { get => _status; private set => _status = value; }

    }

}
